using MobileTestingStudio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTestingStudio.Interfaces
{
    public interface IMobile
    {
        MobileSystem System { get; }
        Guid Id { get; }
        string Name { get; }
        string Version { get; }
        bool IsAvailable { get; set;  }
    }
}
