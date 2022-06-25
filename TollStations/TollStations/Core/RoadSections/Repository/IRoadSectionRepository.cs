using System.Collections.Generic;

namespace TollStations.Core.RoadSections.Repository
{
    public interface IRoadSectionRepository
    {
        Dictionary<int, RoadSection> RoadSectionById { get; set; }
        List<RoadSection> RoadSections { get; set; }

        void Add(RoadSection roadSection);
        void Delete(int id);
        List<RoadSection> GetAll();
        Dictionary<int, RoadSection> GetAllById();
        RoadSection GetById(int id);
        void LoadFromFile();
        void Save();
        void Update(int id, RoadSection byRoadSection);
    }
}