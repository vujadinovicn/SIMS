using System.Collections.Generic;
using TollStations.Core.TollPayments.Model;

namespace TollStations.Core.TollPayments
{
    public interface ITollPaymentService
    {
        TollPayment Add(TollPaymentDTO tollPaymentDTO);
        List<TollPayment> GetAll();
        Dictionary<int, TollPayment> GetAllById();
        TollPayment GetById(int id);
    }
}