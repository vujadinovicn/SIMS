using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core
{
    interface IRemovingService
    {
        bool ContainsPayments(TollGate tollGate);
        void DeleteTollStation(TollStation station);
    }
}