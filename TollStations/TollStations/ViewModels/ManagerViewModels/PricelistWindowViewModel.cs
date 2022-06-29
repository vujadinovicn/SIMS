using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Prices;
using TollStations.Core.Prices.Model;

namespace TollStations.ViewModels.ManagerViewModels
{
    public class PricelistWindowViewModel : ViewModelBase
    {
        IPriceService _priceService;

        public PricelistWindowViewModel(IPriceService priceService)
        {
            _priceService = priceService;
            _prices = new();
            RefreshGrid();
        }

        private ObservableCollection<Price> _prices;

        public ObservableCollection<Price> Prices
        {
            get
            {
                return _prices;
            }
            set
            {
                _prices = value;
                OnPropertyChanged(nameof(Prices));
            }
        }


        public void RefreshGrid()
        {
            _prices.Clear();

            foreach (Price price in _priceService.GetAll())
            {
                Prices.Add(price);
            }
        }

        
    }
}
