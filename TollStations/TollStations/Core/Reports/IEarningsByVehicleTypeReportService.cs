using System;
using System.Collections.Generic;
using TollStations.Core.Prices.Model;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.Reports
{
    public interface IEarningsByVehicleTypeReportService
    {
        Dictionary<VehicleType, double> GetAll(TollStation station, DateTime start, DateTime end);
    }
}