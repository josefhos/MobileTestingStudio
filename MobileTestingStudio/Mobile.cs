using MobileTestingStudio.Enums;
using MobileTestingStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTestingStudio
{
    public class Mobile : IMobile
    {
        public MobileSystem System { get; }

        public Guid Id { get; }

        public string Name { get; }

        public string Version { get; }

        public bool IsAvailable { get; set; }

        public Mobile(MobileSystem system, string version, string name)
        {
            Id = Guid.NewGuid();
            System = system;
            Version = version;
            Name = name;
            IsAvailable = true;
        }
    }
}
