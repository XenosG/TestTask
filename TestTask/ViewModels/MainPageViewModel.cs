using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Stores;

namespace TestTask.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
		private string _searchQuery = "";
		public string SearchQuery
		{
			get
			{
				return _searchQuery;
			}
			set
			{
				_searchQuery = value;
				OnPropertyChanged(nameof(SearchQuery));
			}
		}

        private readonly ObservableCollection<CurrencyViewModel> _currencies;

		public IEnumerable<CurrencyViewModel> Currencies => _currencies;

        public MainPageViewModel(NavigationStore navigationStore)
        {
            _currencies = new ObservableCollection<CurrencyViewModel>();

			_currencies.Add(new CurrencyViewModel(navigationStore, new Currency("Bitcoin", "BTC", (decimal)5634.23, (float)-23.4, 2334)));
        }
    }
}
