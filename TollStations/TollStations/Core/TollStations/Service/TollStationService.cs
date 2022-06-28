using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Repository;

namespace TollStations.Core.TollStations.Service
{
    public class TollStationService : ITollStationService
    {
        ITollStationRepository _tollStationRepository;

        public TollStationService(ITollStationRepository tollStationRepository)
        {
            _tollStationRepository = tollStationRepository;
        }

        public void Save()
        {
            _tollStationRepository.Save();
        }

        public List<TollStation> GetAll()
        {
            return _tollStationRepository.GetAll();
        }

        public Dictionary<int, TollStation> GetAllById()
        {
            return _tollStationRepository.GetAllById();
        }

        public TollStation GetById(int id)
        {
            return _tollStationRepository.GetById(id);
        }

        public void Add(TollStationDTO tollStationDTO)
        {
            TollStation tollStation = new TollStation(tollStationDTO);
            _tollStationRepository.Add(tollStation);
        }

        public void Update(int id, TollStationDTO tollStationDTO)
        {
            TollStation tollStation = new TollStation(tollStationDTO);
            _tollStationRepository.Update(id, tollStation);
        }

        public void AddTollGate(int id, TollGate tollGate)
        {
            _tollStationRepository.AddTollGate(id, tollGate);
        }


        public void Delete(int id)
        {
            _tollStationRepository.Delete(id);
        }

        public void DeleteTollGate(int id, TollGate tollGate)
        {
            _tollStationRepository.DeleteTollGate(id, tollGate);
        }

    }
}
