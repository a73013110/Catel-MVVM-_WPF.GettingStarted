using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.GettingStarted.Models
{
    using Catel.Data;

    public class Person : ValidatableModelBase
    {
        /// <summary>
        /// Register "FirstName" property
        /// </summary>
        public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string), null);
        /// <summary>
        /// Get/Set "FirstName"
        /// </summary>
        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof(string), null);
        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public override string ToString() => FirstName + " " + LastName;
    }
}
