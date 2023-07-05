using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Stores;
using TestTask.API;
using System.Threading;

namespace TestTask.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        private string _searchQuery = "";

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
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
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
                _currencies.Clear();
                _ = GetList(_cancellationTokenSource.Token);
            }
        }

        private readonly ObservableCollection<CurrencyViewModel> _currencies;

        public IEnumerable<CurrencyViewModel> Currencies => _currencies;

        public MainPageViewModel(NavigationStore navigationStore)
        {
            _currencies = new ObservableCollection<CurrencyViewModel>();
            _navigationStore = navigationStore;
            _ = GetList(CancellationToken.None);

        }

        public async Task GetList(CancellationToken token)
        {
            List<Currency> ApiList = await ApiHelper.GetCurrencyList(_searchQuery, token);

            var List = ApiList;

            foreach (var currency in List)
            {
                _currencies.Add(new CurrencyViewModel(_navigationStore, currency));
            }

        }

    }
}
