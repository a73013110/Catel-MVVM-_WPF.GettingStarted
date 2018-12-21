using Catel;
using Catel.Collections;
using Catel.Runtime.Serialization;
using Catel.Runtime.Serialization.Xml;
using System.Collections.Generic;
using System.IO;
using WPF.GettingStarted.Models;

namespace WPF.GettingStarted.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly string _path;
        private readonly IXmlSerializer _xmlSerializer;

        public FamilyService(IXmlSerializer xmlSerializer)
        {
            Argument.IsNotNull(() => xmlSerializer);
            _xmlSerializer = xmlSerializer;
            string directory = Catel.IO.Path.GetApplicationDataDirectory("CatenaLogic", "WPF.GettingStarted");
            _path = Path.Combine(directory, "family.xml");
        }

        public IEnumerable<Family> LoadFamilies()
        {
            if (!File.Exists(_path))
            {
                return new Family[] { };
            }

            using (var fileStream = File.Open(_path, FileMode.Open))
            {
                var settings = _xmlSerializer.Deserialize<Settings>(fileStream);
                return settings.Families;
            }
        }

        public void SaveFamilies(IEnumerable<Family> families)
        {
            var settings = new Settings();
            settings.Families.ReplaceRange(families);

            using (var fileStream = File.Open(_path, FileMode.Create))
            {
                _xmlSerializer.Serialize(settings, fileStream);
            }
        }
    }
}
