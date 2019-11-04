using MobileTestingStudio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTestingStudio.Interfaces
{
    public interface IMobileManager
    {
        IMobile CreateMobile(MobileSystem system, string name, string version);

        void DeleteMobile(Guid id);
        void ConnectMobile(Guid id);
        void DisconnectMobile(Guid id);

        IMobile GetMobileById(Guid id);
        IEnumerable<IMobile> GetAllMobilesBySystem(MobileSystem system);
        IEnumerable<IMobile> GetAllMobilesByVersion(string version);
        IEnumerable<IMobile> GetAllMobilesByName(string name);
        IEnumerable<IMobile> GetConnectedMobiles();
        IEnumerable<IMobile> GetDisconnectedMobiles();

        void StoreMobiles();
    }
}
