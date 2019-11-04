using MobileTestingStudio.Enums;
using MobileTestingStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTestingStudio
{
    public class MobileManager : IMobileManager
    {
        private readonly IMobileRepository _mobileRepository;

        public MobileManager()
        {
            _mobileRepository = new MobileRepository();
            CreateMobile(MobileSystem.Android, "Androidik", "10.1");
            CreateMobile(MobileSystem.iOS, "Jabko", "13.1");
            CreateMobile(MobileSystem.Windows, "Okno", "1.3");
            CreateMobile(MobileSystem.Android, "Droid", "10.5");
            CreateMobile(MobileSystem.Windows, "Vokno", "1.01");
            _mobileRepository.Store();
        }

        public IMobile CreateMobile(MobileSystem system, string name, string version)
        {
            var mobile = new Mobile(system, version, name);
            _mobileRepository.Add(mobile);

            return mobile;
        }

        public void DeleteMobile(Guid id)
        {
            var mobile = GetMobileById(id);
            if (mobile.IsAvailable)
            {
                _mobileRepository.Remove(mobile);
            }
        }

        public void ConnectMobile(Guid id)
        {
            var mobile = GetMobileById(id);
            if (!mobile.IsAvailable)
            {
                mobile.IsAvailable = true;
                _mobileRepository.Update(mobile);
            }
        }
        public void DisconnectMobile(Guid id)
        {
            var mobile = GetMobileById(id);
            if (mobile.IsAvailable)
            {
                mobile.IsAvailable = false;
                _mobileRepository.Update(mobile);
            }

            _mobileRepository.Store();
        }

        public IEnumerable<IMobile> GetAllMobilesByName(string name)
        {
            return _mobileRepository.GetByName(name);
        }

        public IEnumerable<IMobile> GetAllMobilesBySystem(MobileSystem system)
        {
            return _mobileRepository.GetBySystem(system);
        }

        public IEnumerable<IMobile> GetAllMobilesByVersion(string version)
        {
            return _mobileRepository.GetByVersion(version);
        }

        public IEnumerable<IMobile> GetConnectedMobiles()
        {
            return _mobileRepository.GetByAvailability(true);
        }

        public IEnumerable<IMobile> GetDisconnectedMobiles()
        {
            return _mobileRepository.GetByAvailability(false);
        }

        public IMobile GetMobileById(Guid id)
        {
            return _mobileRepository.GetById(id);
        }

        public void StoreMobiles()
        {
            _mobileRepository.Store();
        }

        public IEnumerable<IMobile> LoadAllMobiles()
        {
            return _mobileRepository.LoadDataFromStore();
        }
    }
}
