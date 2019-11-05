using MobileTestingStudio.Enums;
using MobileTestingStudio.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTestingStudio
{
    public class Mobile : IMobile
    {
        public MobileSystem System { get; }

        [JsonProperty("Guid")]
        public Guid Id { get; }

        public string Name { get; }

        public string Version { get; }

        public bool IsAvailable { get; set; }

        [JsonConstructor]
        public Mobile(MobileSystem system, string name, string version, Guid id, bool isAvailable)
        {
            this.Id = id;
            this.IsAvailable = isAvailable;
            this.Name = name;
            this.Version = version;
            this.System = system;
        }
        public Mobile(MobileSystem system, string name, string version)
        {
            Id = Guid.NewGuid();
            System = system;
            Version = version;
            Name = name;
            IsAvailable = true;
        }
    }
}
