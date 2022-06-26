using System.Collections.Generic;
using TollStations.Core.TollPayments.Model;

namespace TollStations.Core.TollPayments.Repository
{
    public interface ITollPaymentRepository
    {
        List<TollPayment> TollPayments { get; set; }
        Dictionary<int, TollPayment> TollPaymentsById { get; set; }

        TollPayment Add(TollPayment payment);
        List<TollPayment> GetAll();
        Dictionary<int, TollPayment> GetAllById();
        TollPayment GetById(int id);
        void LoadFromFile();
        void Save();
    }
}