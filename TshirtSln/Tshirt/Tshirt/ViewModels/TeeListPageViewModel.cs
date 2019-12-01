using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tshirt.Models;
using Tshirt.Service.Interfaces;

namespace Tshirt.ViewModels
{
    public class TeeListPageViewModel : ViewModelBase
    {
        
        private ObservableCollection<Tees> _teesList;
        private IData _database;

        public ObservableCollection<Tees> TeesList
        {
            get { return _teesList; }
            set { SetProperty(ref _teesList, value); }
        }
        public TeeListPageViewModel(INavigationService navigationService, IData database) : base(navigationService)
        {
            _database = database;
        }

        public async override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            var tees = await _database.GetItemsAsync();

            TeesList = new ObservableCollection<Tees>(tees);
        }
    }
}
