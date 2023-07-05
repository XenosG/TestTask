using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Stores;
using TestTask.ViewModels;

namespace TestTask.Commands
{
    public class OpenDetailsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Currency _currency;

        public OpenDetailsCommand(NavigationStore navigationStore, Currency currency)
        {
            _navigationStore = navigationStore;
            _currency = currency;
        }


        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new CurrencyDetailsViewModel(_navigationStore, _currency);
        }
    }
}
