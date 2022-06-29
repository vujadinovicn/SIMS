using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Devices.Service;
using TollStations.Core.RoadSections;
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
        ITollStationService tollStationService;
        ITollCardService tollCardService;
        ITollGateService tollGateService;
        IRoadSectionService roadSectionService;
        IDeviceService deviceService;

        public RemovingService(ITollStationService tollStationService, ITollCardService tollCardService, ITollGateService tollGateService, IRoadSectionService roadSectionService, IDeviceService deviceService)
        {
            this.tollStationService = tollStationService;
            this.tollCardService = tollCardService;
            this.tollGateService = tollGateService;
            this.roadSectionService = roadSectionService;
            this.deviceService = deviceService;
        }

        private bool ContainsInRoadSections(TollStation station)
        {
            foreach (RoadSection roadSection in roadSectionService.GetAll())
            {
                if (roadSection.EntryStation == station || roadSection.ExitStation == station) return true;
            }
            return false;
        }

        private bool ContainsInTollCards(TollStation station)
        {
            foreach (TollCard tollCard in tollCardService.GetAll())
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

        public void DeleteTollStation(TollStation station)
        {
            if (!(ContainsInTollCards(station) || ContainsInRoadSections(station)))
            {
                foreach (TollGate tollGate in station.Gates)
                {
                    if (ContainsPayments(tollGate)) return;
                }

                foreach (TollGate tollGate in station.Gates)
                {
                    var cashier = tollGate.CurrentCashier;
                    cashier.TollGate = null;
                    foreach (var device in tollGate.Devices)
                        deviceService.Delete(device.Id);
                    tollGateService.Delete(tollGate.Id);
                }

                tollStationService.Delete(station.Id);
            }
        }


    }
}
