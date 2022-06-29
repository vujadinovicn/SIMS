using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.CashierCommands;
using TollStations.Core.Prices;
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards;

namespace TollStations.ViewModels.CashierViewModels
{
    public class VehicleExitWindowViewModel : ViewModelBase
    {
        ITollCardService _tollCardService;
        IPriceService _priceService;
        public VehicleExitWindowViewModel(ITollCardService tollCardService, IPriceService priceService)
        {
            _tollCardService = tollCardService;
            _priceService = priceService;
            LoadTypeComboBox();
        }
        public void SetLoggedCashier(Cashier cashier)
        {
            SetVehicleDataDialogCommand = new MakePaymentCommand(this, cashier,_tollCardService, _priceService);
        }
        public ICommand SetVehicleDataDialogCommand { get; set; }

        private string cardId;
        public string CardId
        {
            get
            {
                return cardId;
            }
            set
            {
                cardId = value;
                OnPropertyChanged(nameof(CardId));
            }
        }
        public int GetCardId()
        {
            return Int32.Parse(CardId);
        }

        private void LoadTypeComboBox()
        {
            TypeComboBoxItems = new();
            foreach (VehicleType type in Enum.GetValues(typeof(VehicleType)))
            {
                TypeComboBoxItems.Add(type);
            }
            TypeComboBoxSelectedIndex = 0;
        }
        public VehicleType GetVehicleType()
        {
            return TypeComboBoxItems[TypeComboBoxSelectedIndex];
        }
        private ObservableCollection<VehicleType> _vehicleTypeComboBoxItems;
        public ObservableCollection<VehicleType> TypeComboBoxItems
        {
            get
            {
                return _vehicleTypeComboBoxItems;
            }
            set
            {
                _vehicleTypeComboBoxItems = value;
                OnPropertyChanged(nameof(TypeComboBoxItems));
            }
        }
        private int _typeComboBoxSelectedIndex;
        public int TypeComboBoxSelectedIndex
        {
            get
            {
                return _typeComboBoxSelectedIndex;
            }
            set
            {
                _typeComboBoxSelectedIndex = value;
                OnPropertyChanged(nameof(TypeComboBoxSelectedIndex));
            }
        }

    }
}
