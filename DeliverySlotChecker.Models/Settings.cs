using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySlotChecker.Models
{
    [Serializable]
    public class Settings
    {
        public ServiceSettings[] Services { get; set; }
    }

    [Serializable]
    public class ServiceSettings
    {
        public string Service { get; set; }
        public bool Enabled { get; set; }
        public bool IncludePickUp { get; set; }
        public string HomePostCode { get; set; }
        public string PickupPostCode { get; set; }
    }
}
