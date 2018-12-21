namespace WPF.GettingStarted.ViewModels
{
    using Catel;
    using Catel.Data;
    using Catel.MVVM;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using WPF.GettingStarted.Models;
    using WPF.GettingStarted.Services;

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFamilyService _familyService;

        public MainWindowViewModel(IFamilyService familyService)
        {
            Argument.IsNotNull(() => familyService);
            _familyService = familyService;
        }

        public override string Title { get { return "WPF.GettingStarted"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        public static readonly PropertyData FamiliesProperty = RegisterProperty("Families", typeof(ObservableCollection<Family>), null);
        public ObservableCollection<Family> Families
        {
            get { return GetValue<ObservableCollection<Family>>(FamiliesProperty); }
            private set { SetValue(FamiliesProperty, value); }
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
            var families = _familyService.LoadFamilies();
            Families = new ObservableCollection<Family>(families);
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here
            _familyService.SaveFamilies(Families);

            await base.CloseAsync();
        }
    }
}
