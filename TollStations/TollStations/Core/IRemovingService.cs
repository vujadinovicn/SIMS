using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core
{
    public interface IRemovingService
    {
        bool ContainsPayments(TollGate tollGate);
        bool DeleteTollStation(TollStation station);
        void DeleteTollGate(TollGate tollGate);
    }
}