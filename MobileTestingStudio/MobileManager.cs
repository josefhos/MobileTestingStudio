﻿using MobileTestingStudio.Enums;
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
        }

        public IMobile CreateMobile(MobileSystem system, string name, string version)
        {
            var mobile = new Mobile(system, name, version);
            return _mobileRepository.Add(mobile);
        }

        public void DeleteMobile(Guid id)
        {
            var mobile = GetMobileById(id);
            if (mobile.IsAvailable)
            {
                _mobileRepository.Remove(mobile);
            }
            else{
                throw new Exception("Can't delete mobile that is not available.");
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
            else
            {
                throw new Exception("Can't connect mobile that is alread connected");
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
    }
}
