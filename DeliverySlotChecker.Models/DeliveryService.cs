using HttpRequestService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliverySlotChecker.Models
{
    public abstract class DeliveryService
    {
        string _name;
        public string Name => _name;

        public abstract Task<IEnumerable<DeliverySlot>> GetDeliverySlots();

        protected HttpService _httpService;

        public DeliveryService(string serviceName, string baseAddress, Dictionary<string, string> defaultRequestHeaders = null)
        {
            _httpService = new HttpService(baseAddress, defaultRequestHeaders);
            _name = serviceName;
        }
    }
}
