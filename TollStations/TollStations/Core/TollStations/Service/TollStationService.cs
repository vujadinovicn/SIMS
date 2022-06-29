using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Locations;
using TollStations.Core.Locations.Service;
using TollStations.Core.SystemUsers.Chiefs.Service;
using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Repository;

namespace TollStations.Core.TollStations.Service
{
    public class TollStationService : ITollStationService
    {
        ITollStationRepository _tollStationRepository;
        ILocationService _locationService;
        IChiefService _chiefService;

        public TollStationService(IChiefService chiefService, ITollStationRepository tollStationRepository, ILocationService locationService)
        {
            _chiefService = chiefService;
            _tollStationRepository = tollStationRepository;
            _locationService = locationService;
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
            var chief = tollStation.Chief;
            chief.TollStation = tollStation;
            _chiefService.Save();
        }

        public void Update(int id, TollStationDTO tollStationDTO)
        {
            var oldChief = GetById(id).Chief;
            oldChief.TollStation = null;
            TollStation tollStation = new TollStation(tollStationDTO);
            var newChief = tollStation.Chief;
            newChief.TollStation = tollStation;
            _tollStationRepository.Update(id, tollStation);
            _chiefService.Save();
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

        public List<Location> GetLocationsWithoutStations()
        {
            var allLocations = _locationService.GetAll();
            List<Location> locations = new List<Location>();
            foreach (var tollStation in GetAll())
            {
                locations.Add(tollStation.Location);
            }
            return allLocations.Except(locations).ToList();
        }

        /*public void DeleteAllTollGates(int id)
        {
            _tollStationRepository.DeleteAllTollGates(id);
        }*/

    }
}
