using Catel;
using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.GettingStarted.Models;

namespace WPF.GettingStarted.ViewModels
{
    class FamilyViewModel : ViewModelBase
    {
        public FamilyViewModel(Family family)
        {
            Argument.IsNotNull(() => family);
            Family = family;
        }

        public static readonly PropertyData FamilyProperty = RegisterProperty("Family", typeof(Family), null);
        [Model]
        public Family Family
        {
            get { return GetValue<Family>(FamilyProperty); }
            private set { SetValue(FamilyProperty, value); }
        }

        public static readonly PropertyData PersonsProperty = RegisterProperty("Persons", typeof(ObservableCollection<Person>), null);
        [ViewModelToModel("Family")]
        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            private set { SetValue(PersonsProperty, value); }
        }

        public static readonly PropertyData FamilyNameProperty = RegisterProperty("FamilyName", typeof(string));
        [ViewModelToModel("Family")]
        public string FamilyName
        {
            get { return GetValue<string>(FamilyNameProperty); }
            set { SetValue(FamilyNameProperty, value); }
        }
    }
}
