using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Devices.Service;
using TollStations.Core.RoadSections;
using TollStations.Core.SystemUsers.Cashiers.Service;
using TollStations.Core.SystemUsers.Chiefs.Service;
using TollStations.Core.TollCards;
using TollStations.Core.TollCards.Model;
using TollStations.Core.TollGates;
using TollStations.Core.TollGates.Service;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Service;

namespace TollStations.Core
{
    class RemovingService : IRemovingService
    {
        ITollStationService _tollStationService;
        ITollCardService _tollCardService;
        ITollGateService _tollGateService;
        IRoadSectionService _roadSectionService;
        IDeviceService _deviceService;
        ICashierService _cashierService;
        IChiefService _chiefService;

        public RemovingService(ITollStationService tollStationService, ITollCardService tollCardService, ITollGateService tollGateService, IRoadSectionService roadSectionService, IDeviceService deviceService, ICashierService cashierService, IChiefService chiefService)
        {
            this._tollStationService = tollStationService;
            this._tollCardService = tollCardService;
            this._tollGateService = tollGateService;
            this._roadSectionService = roadSectionService;
            this._deviceService = deviceService;
            this._cashierService = cashierService;
            this._chiefService = chiefService;
        }

        private bool ContainsInRoadSections(TollStation station)
        {
            foreach (RoadSection roadSection in _roadSectionService.GetAll())
            {
                if (roadSection.EntryStation == station || roadSection.ExitStation == station) return true;
            }
            return false;
        }

        private bool ContainsInTollCards(TollStation station)
        {
            foreach (TollCard tollCard in _tollCardService.GetAll())
            {
                if (tollCard.EntryStation == station) return true;
            }
            return false;
        }

        public bool ContainsPayments(TollGate tollGate)
        {
            if (tollGate.TollPayments.Count > 0)
                return true;
            return false;
        }

        public void DeleteTollGate(TollGate tollGate)
        {
            var cashier = tollGate.CurrentCashier;
            cashier.TollGate = null;
            _cashierService.Save();
            foreach (var device in tollGate.Devices)
                _deviceService.Delete(device.Id);
            _tollGateService.Delete(tollGate.Id);
        }

        public bool DeleteTollStation(TollStation station)
        {
            if (!(ContainsInTollCards(station) || ContainsInRoadSections(station)))
            {
                foreach (TollGate tollGate in station.Gates)
                {
                    if (ContainsPayments(tollGate)) return false;
                }

                foreach (TollGate tollGate in station.Gates)
                {
                    tollGate.CurrentCashier.TollStation = null;
                    _cashierService.Save();
                    DeleteTollGate(tollGate);
                }
                var chief = station.Chief;
                chief.TollStation = null;
                _chiefService.Save();
                _tollStationService.Delete(station.Id);
            }
            return true;
        }


    }
}
