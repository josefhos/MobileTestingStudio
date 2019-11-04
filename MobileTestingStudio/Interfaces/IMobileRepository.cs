using System;
using System.Collections.Generic;
using System.Text;
using MobileTestingStudio.Enums;

namespace MobileTestingStudio.Interfaces
{
    public interface IMobileRepository
    {
        IMobile Add(IMobile mobile);
        void Remove(IMobile mobile);
        IMobile Update(IMobile mobile);
        IMobile GetById(Guid id);
        IEnumerable<IMobile> GetByName(string name);
        IEnumerable<IMobile> GetByVersion(string version);
        IEnumerable<IMobile> GetByAvailability(bool isAvailable);
        IEnumerable<IMobile> GetBySystem(MobileSystem system);
        void Store();
        IEnumerable<IMobile> LoadDataFromStore();
    }
}
