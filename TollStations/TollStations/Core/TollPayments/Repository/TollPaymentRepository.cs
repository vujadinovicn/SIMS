using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.TollCards.Repository;
using TollStations.Core.TollPayments.Model;

namespace TollStations.Core.TollPayments.Repository
{
    class TollPaymentRepository
    {
        private String _fileName = @"..\..\..\Data\tollpayments.json";

        private int _maxId;

        private ITollCardRepository tollCardRepository;
        private ICashierRepository cashierRepository;
        public List<TollPayment> TollPayments { get; set; }
        public Dictionary<int, TollPayment> TollPaymentsById { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public TollPaymentRepository(ITollCardRepository tollCardRepository, ICashierRepository cashierRepository)
        {
            this.TollPayments = new List<TollPayment>();
            this.TollPaymentsById = new Dictionary<int, TollPayment>();
            this._maxId = 0;
            this.tollCardRepository = tollCardRepository;
            this.cashierRepository = cashierRepository;
            this.LoadFromFile();
        }

        private TollPayment Parse(JToken? tollPayment)
        {
            Currency currency;
            Enum.TryParse<Currency>((string)tollPayment["state"], out currency);
            return new TollPayment((int)tollPayment["id"], (DateTime)tollPayment["time"], currency, (double)tollPayment["amount"], cashierRepository.GetById((int)tollPayment["cashier"]), tollCardRepository.GetById((int)tollPayment["tollCard"]));
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


        public void Save()
        {
            var allLocations = JsonSerializer.Serialize(this.TollPayments, _options);
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
