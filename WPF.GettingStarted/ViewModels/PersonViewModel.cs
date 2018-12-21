using Catel;
using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.GettingStarted.Models;

namespace WPF.GettingStarted.ViewModels
{
    class PersonViewModel : ViewModelBase
    {
        public PersonViewModel(Person person)
        {
            Argument.IsNotNull(() => person);
            Person = person;
        }

        public static readonly PropertyData PersonProperty = RegisterProperty("Person", typeof(Person), null);
        [Model]
        public Person Person
        {
            get { return GetValue<Person>(PersonProperty); }
            set { SetValue(PersonProperty, value); }
        }

        public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string), null);
        [ViewModelToModel("Person")]
        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof(string), null);
        [ViewModelToModel("Person")]
        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }
    }
}
