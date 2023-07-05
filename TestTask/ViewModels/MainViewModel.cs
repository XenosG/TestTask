using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new CurrencyDetailsViewModel(new Currency("Bitcoin", "BTC", (decimal)5634.23, (float)-23.4, 2334, null));
        }
    }
}
