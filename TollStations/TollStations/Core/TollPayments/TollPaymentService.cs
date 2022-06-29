using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollPayments.Model;
using TollStations.Core.TollPayments.Repository;

namespace TollStations.Core.TollPayments
{
    public class TollPaymentService : ITollPaymentService
    {
        ITollPaymentRepository _tollPaymentRepository;
        public TollPaymentService(ITollPaymentRepository tollPaymentRepository)
        {
            _tollPaymentRepository = tollPaymentRepository;
        }
        public List<TollPayment> GetAll()
        {
            return _tollPaymentRepository.GetAll();
        }

        public Dictionary<int, TollPayment> GetAllById()
        {
            return _tollPaymentRepository.GetAllById();
        }

        public TollPayment GetById(int id)
        {
            return _tollPaymentRepository.GetById(id);
        }

        public TollPayment Add(TollPaymentDTO tollPaymentDTO)
        {
            TollPayment tollPayment = new TollPayment(tollPaymentDTO);
            return _tollPaymentRepository.Add(tollPayment);
        }
    }
}
