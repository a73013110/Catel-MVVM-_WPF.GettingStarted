using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WPF.GettingStarted.Models
{
    using Catel.Data;

    public class Settings : SavableModelBase<Settings>
    {
        public static readonly PropertyData FamiliesProperty = RegisterProperty("Families", typeof(ObservableCollection<Family>), new ObservableCollection<Family>());
        public ObservableCollection<Family> Families
        {
            get { return GetValue<ObservableCollection<Family>>(FamiliesProperty); }
            set { SetValue(FamiliesProperty, value); }
        }
    }
}
