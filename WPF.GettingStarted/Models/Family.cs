using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WPF.GettingStarted.Models
{
    using Catel.Data;

    public class Family : ValidatableModelBase
    {
        public static readonly PropertyData FamilyNameProperty = RegisterProperty("FamilyName", typeof(string), null);
        public string FamilyName
        {
            get { return GetValue<string>(FamilyNameProperty); }
            set { SetValue(FamilyNameProperty, value); }
        }

        public static readonly PropertyData PersonsProperty = RegisterProperty("Persons", typeof(ObservableCollection<Person>), () => new ObservableCollection<Person>());
        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }

        public override string ToString() => FamilyName;
    }
}
