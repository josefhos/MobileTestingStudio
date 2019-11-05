using MobileTestingStudio.Enums;
using MobileTestingStudio.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MobileTestingStudio
{
    public class MobileRepository : IMobileRepository
    {
        private List<IMobile> _repository;
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };
        const string storeFileName = "Repository.json";

        public MobileRepository()
        {
            _repository = new List<IMobile>();
            LoadDataFromStore();
        }
        public IMobile Add(IMobile mobile)
        {
            _repository.Add(mobile);
            return mobile;
        }

        public IEnumerable<IMobile> GetByAvailability(bool isAvailable)
        {
            return _repository.Where(mobile => mobile.IsAvailable == isAvailable);
        }

        public IMobile GetById(Guid id)
        {
            return _repository.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<IMobile> GetByName(string name)
        {
            return _repository.Where(mobile => mobile.Name.ToLower().Contains(name.ToLower()));
        }

        public IEnumerable<IMobile> GetByVersion(string version)
        {
            return _repository.Where(mobile => mobile.Version == version);
        }

        public IEnumerable<IMobile> GetBySystem(MobileSystem system)
        {
            return _repository.Where(mobile => mobile.System == system);
        }
        public void Remove(IMobile mobile)
        {
            _repository.RemoveAll(mob => mob.Id == mobile.Id);
        }

        public IMobile Update(IMobile mobile)
        {
            var oldMobile = GetById(mobile.Id);
            var index = _repository.IndexOf(oldMobile);
            _repository[index] = mobile;

            return _repository[index];
        }

        public void Store()
        {
            if (File.Exists(storeFileName))
            {
                File.Delete(storeFileName);
            }
            File.WriteAllText(storeFileName, JsonConvert.SerializeObject(_repository, _settings));
        }

        public void LoadDataFromStore()
        {
            if (File.Exists(storeFileName))
            {
                var storedData = File.ReadAllText(storeFileName);

                _repository = storedData == null || !storedData.Any()
                ? new List<IMobile>()
                : JsonConvert.DeserializeObject<List<IMobile>>(storedData, _settings);
            }

            
        }
    }
}
