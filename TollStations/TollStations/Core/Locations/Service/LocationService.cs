using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Locations.Repository;

namespace TollStations.Core.Locations.Service
{
    public class LocationService : ILocationService
    {
        ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public List<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }
        public Dictionary<int, Location> GetAllById()
        {
            return _locationRepository.GetAllById();
        }
        public Location GetById(int id)
        {
            return _locationRepository.GetById(id);
        }
        public void Save()
        {
            _locationRepository.Save();
        }
    }
}
