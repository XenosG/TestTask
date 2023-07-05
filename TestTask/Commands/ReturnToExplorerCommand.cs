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
    public class ReturnToExplorerCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public ReturnToExplorerCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }


        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new MainPageViewModel(_navigationStore);
        }
    }
}
