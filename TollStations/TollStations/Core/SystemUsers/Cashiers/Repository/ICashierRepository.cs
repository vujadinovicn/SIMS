using System.Collections.Generic;
using TollStations.Core.SystemUsers.Cashiers.Model;

namespace TollStations.Core.SystemUsers.Cashiers.Repository
{
    public interface ICashierRepository
    {
        List<Cashier> Cashiers { get; set; }
        Dictionary<int, Cashier> CashiersById { get; set; }
        Dictionary<string, Cashier> CashiersByUsername { get; set; }

        List<Cashier> GetAll();
        Dictionary<int, Cashier> GetAllById();
        Dictionary<string, Cashier> GetAllByUsername();
        Cashier GetById(int id);
        Cashier GetByUsername(string username);
        void LoadFromFile();
        void Save();
    }
}