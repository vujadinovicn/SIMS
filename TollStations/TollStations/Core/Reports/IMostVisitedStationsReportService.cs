using System;
using System.Collections.Generic;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.Reports
{
    public interface IMostVisitedStationsReportService
    {
        Dictionary<TollStation, int> GetAll(DateTime start, DateTime end);
    }
}