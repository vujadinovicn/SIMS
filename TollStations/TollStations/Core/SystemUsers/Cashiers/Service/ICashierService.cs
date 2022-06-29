using System.Collections.Generic;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.SystemUsers.Cashiers.Service
{
    public interface ICashierService
    {
        List<Cashier> GetAll();
        Dictionary<int, Cashier> GetAllById();
        Dictionary<string, Cashier> GetAllByUsername();
        Cashier GetById(int id);
        Cashier GetByUsername(string username);
        void Save();
        List<Cashier> GetAllWithoutStations();
        List<Cashier> GetByStation(int stationId);
        void AddStation(Cashier cashier, TollStation tollStation);
        public List<Cashier> GetAllWithoutGates(List<Cashier> cashiers);

        public List<Cashier> GetByStationWithoutGate(int stationId);
    }
}