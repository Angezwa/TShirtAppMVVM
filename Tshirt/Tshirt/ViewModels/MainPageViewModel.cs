using Prism.Commands;
using Prism.Navigation;
using Tshirt.Models;
using Tshirt.Service.Interfaces;

namespace Tshirt.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IData _database;

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

       
        public Tees TeesOrders;


        private async void ExecuteSaveCommand()
        {
            await _database.SaveItemAsync(TeesOrders);
        }
        public MainPageViewModel(INavigationService navigationService, IData database)
            : base(navigationService)
        {
            Title = "Main Page";

            _database = database;

        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);


        }

    }
}
