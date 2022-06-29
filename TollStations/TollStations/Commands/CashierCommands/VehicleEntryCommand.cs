using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards;
using TollStations.Core.TollCards.Model;

namespace TollStations.Commands.CashierCommands
{
    public class VehicleEntryCommand : CommandBase
    {
        Cashier _loggedCashier;
        ITollCardService _tollCardService;
        public VehicleEntryCommand(Cashier cashier, ITollCardService tollCardService)
        {
            _loggedCashier = cashier;
            _tollCardService = tollCardService;
        }
        public override void Execute(object? parameter)
        {
            string plate = RandomString(2) + "-" + RandomInteger(4) + "-" + RandomString(2);
            TollCardDTO tollCardDTO = new TollCardDTO(DateTime.Now, plate, _loggedCashier.TollStation);
            _tollCardService.Add(tollCardDTO);
            MessageBox.Show("Toll card has created successfully!\nLicence plate : "+plate+"\tToll station : " + _loggedCashier.TollStation.Location.Name, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomInteger(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
