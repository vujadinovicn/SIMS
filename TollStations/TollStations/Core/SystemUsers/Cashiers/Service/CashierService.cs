using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.SystemUsers.Cashiers.Repository;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.SystemUsers.Cashiers.Service
{
    public class CashierService : ICashierService
    {
        ICashierRepository _cashierRepository;

        public CashierService(ICashierRepository cashierRepository)
        {
            _cashierRepository = cashierRepository;
        }
        public void Save()
        {
            _cashierRepository.Save();
        }

        public List<Cashier> GetAll()
        {
            return _cashierRepository.GetAll();
        }

        public Dictionary<String, Cashier> GetAllByUsername()
        {
            return _cashierRepository.GetAllByUsername();
        }

        public Cashier GetByUsername(String username)
        {
            return _cashierRepository.GetByUsername(username);
        }

        public Dictionary<int, Cashier> GetAllById()
        {
            return _cashierRepository.GetAllById();
        }

        public Cashier GetById(int id)
        {
            return _cashierRepository.GetById(id);
        }
        public List<Cashier> GetAllWithoutStations()
        {
            return _cashierRepository.GetAllWithoutStations();
        }
        public List<Cashier> GetByStation(int stationId)
        {
            return _cashierRepository.GetByStation(stationId);
        }

        public void AddStation(Cashier cashier, TollStation tollStation)
        {
            cashier.TollStation = tollStation;
            Save();
        }
    }
}
