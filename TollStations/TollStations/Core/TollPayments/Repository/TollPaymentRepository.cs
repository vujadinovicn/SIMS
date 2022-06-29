using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Repository;
using TollStations.Core.TollCards.Repository;
using TollStations.Core.TollGates;
using TollStations.Core.TollGates.Repository;
using TollStations.Core.TollPayments.Model;

namespace TollStations.Core.TollPayments.Repository
{
    class TollPaymentRepository : ITollPaymentRepository
    {
        private String _fileName = @"..\..\..\Data\tollPayments.json";

        private int _maxId;

        private ITollCardRepository tollCardRepository;
        private ICashierRepository cashierRepository;
        private ITollGateRepository tollGateRepository;
        public List<TollPayment> TollPayments { get; set; }
        public Dictionary<int, TollPayment> TollPaymentsById { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public TollPaymentRepository(ITollCardRepository tollCardRepository, ICashierRepository cashierRepository, ITollGateRepository tollGateRepository)
        {
            this.TollPayments = new List<TollPayment>();
            this.TollPaymentsById = new Dictionary<int, TollPayment>();
            this._maxId = 0;
            this.tollCardRepository = tollCardRepository;
            this.cashierRepository = cashierRepository;
            this.tollGateRepository = tollGateRepository;
            this.LoadFromFile();
        }

        private TollPayment Parse(JToken? tollPayment)
        {
            Currency currency;
            Enum.TryParse<Currency>((string)tollPayment["currency"], out currency);
            VehicleType vehicleType;
            Enum.TryParse<VehicleType>((string)tollPayment["vehicleType"], out vehicleType);
            TollGate tollGate = tollGateRepository.GetById((int)tollPayment["tollGate"]);
            TollPayment loadedTollPayment = new TollPayment((int)tollPayment["id"], (DateTime)tollPayment["time"], currency, (double)tollPayment["amount"], cashierRepository.GetById((int)tollPayment["cashier"]), tollCardRepository.GetById((int)tollPayment["tollCard"]), tollGate, vehicleType);
            tollGate.TollPayments.Add(loadedTollPayment);
            return loadedTollPayment;
        }

        public void LoadFromFile()
        {
            var tollPayments = JArray.Parse(File.ReadAllText(_fileName));
            foreach (var payment in tollPayments)
            {
                TollPayment loadedPyment = Parse(payment);
                if (loadedPyment.Id > _maxId)
                {
                    _maxId = loadedPyment.Id;
                }
                this.TollPayments.Add(loadedPyment);
                this.TollPaymentsById[loadedPyment.Id] = loadedPyment;
            }
        }
        private List<dynamic> PrepareForSerialization()
        {
            List<dynamic> reducedTollPayments = new List<dynamic>();
            foreach (var tollPayment in this.TollPayments)
            {
                reducedTollPayments.Add(new
                {
                    id = tollPayment.Id,
                    time = tollPayment.Time,
                    currency = tollPayment.Currency,
                    amount = tollPayment.Amount,
                    cashier = tollPayment.Cashier.Id,
                    tollCard = tollPayment.TollCard.Id,
                    tollGate = tollPayment.TollGate.Id,
                    vehicleType = tollPayment.VehicleType.ToString()
                });
            }
            return reducedTollPayments;
        }

        public void Save()
        {
            var allLocations = JsonSerializer.Serialize(PrepareForSerialization(), _options);
            File.WriteAllText(this._fileName, allLocations);
        }

        public List<TollPayment> GetAll()
        {
            return this.TollPayments;
        }

        public Dictionary<int, TollPayment> GetAllById()
        {
            return this.TollPaymentsById;
        }

        public TollPayment GetById(int id)
        {
            if (TollPaymentsById.ContainsKey(id))
                return TollPaymentsById[id];
            return null;
        }

        public TollPayment Add(TollPayment payment)
        {
            this._maxId++;
            int id = this._maxId;
            payment.Id = id;

            this.TollPayments.Add(payment);
            this.TollPaymentsById.Add(payment.Id, payment);
            Save();
            return payment;
        }
    }
}
