using DeliverySlotChecker.Asda.Models;
using DeliverySlotChecker.Models;
using HttpRequestService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

namespace DeliverySlotChecker.Asda
{
    public class AsdaService : DeliveryService
    {
        ServiceAddress _homeAddress;
        ServiceAddress _pickupAddress;
        bool _includePickup;

        public AsdaService(ServiceSettings serviceSettings) : base("Asda", "https://groceries.asda.com/api/", null)
        {
            _homeAddress = new ServiceAddress() { postcode = serviceSettings.HomePostCode };
            _pickupAddress = new ServiceAddress() { postcode = serviceSettings.PickupPostCode };
            _includePickup = serviceSettings.IncludePickUp;
        }

        public override async Task<IEnumerable<DeliverySlot>> GetDeliverySlots()
        {
            var allSlots = new List<DeliverySlot>();
            await GetSlots(allSlots, DeliveryType.Delivery);
            await GetSlots(allSlots, DeliveryType.Pickup);

            return allSlots;
        }

        private async Task GetSlots(List<DeliverySlot> allSlots, DeliveryType deliveryType)
        {
            var request = JsonSerializer.Serialize(GetRequest(deliveryType));
            var response = await _httpService.Post("v3/slot/view", request);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var slots = JsonSerializer.Deserialize<GetSlotsResponse>(content);
                foreach (var day in slots.data.slot_days)
                {
                    foreach (var slot in day.slots)
                    {
                        allSlots.Add(ConvertSlot(slot, deliveryType));
                    }
                }
            }
            else
            {
                throw new Exception(content);
            }
        }

        private static DeliverySlot ConvertSlot(Slot slot, DeliveryType deliveryType)
        {
            return new DeliverySlot(slot.slot_info.start_time, slot.slot_info.end_time, slot.slot_info.base_slot_price, slot.slot_info.status != "UNAVAILABLE", deliveryType);
        }

        GetSlotsRequest GetRequest(DeliveryType deliveryType)
        {
            var toReturn = GetBaseRequest();
            switch (deliveryType)
            {
                case DeliveryType.Pickup:
                    toReturn.data.service_info.fulfillment_type = "INSTORE_PICKUP";
                    toReturn.data.service_address = _pickupAddress;
                    break;
                case DeliveryType.Delivery:
                    toReturn.data.service_info.fulfillment_type = "DELIVERY";
                    toReturn.data.service_address = _homeAddress;
                    break;
            }

            return toReturn;
        }

        GetSlotsRequest GetBaseRequest()
        {
            return new GetSlotsRequest()
            {
                requestorigin = "gi",
                data = new Data()
                {
                    service_info = new ServiceInfo()
                    { enable_express = false },
                    start_date = DateTime.Now,
                    end_date = DateTime.Now.AddDays(14),
                    reserved_slot_id = "",
                    customer_info = new CustomerInfo()
                    { account_id = "1234"},
                    order_info = new OrderInfo()
                    {
                        order_id = "1234",
                        restricted_item_types = new List<object>(),
                        volume = 10,
                        weight = 3,
                        sub_total_amount = 25,
                        line_item_count = 10,
                        total_quantity = 5
                    }
                }
            };
        }
    }
}
