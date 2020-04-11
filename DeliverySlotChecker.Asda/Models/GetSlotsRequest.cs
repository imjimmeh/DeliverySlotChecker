using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySlotChecker.Asda.Models
{
    public class ServiceInfo
    {
        public string fulfillment_type { get; set; }
        public bool enable_express { get; set; }
    }

    public class ServiceAddress
    {
        public string postcode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class CustomerInfo
    {
        public string account_id { get; set; }
    }

    public class OrderInfo
    {
        public string order_id { get; set; }
        public List<object> restricted_item_types { get; set; }
        public double volume { get; set; }
        public double weight { get; set; }
        public double sub_total_amount { get; set; }
        public int line_item_count { get; set; }
        public int total_quantity { get; set; }
    }

    public class Data
    {
        public ServiceInfo service_info { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string reserved_slot_id { get; set; }
        public ServiceAddress service_address { get; set; }
        public CustomerInfo customer_info { get; set; }
        public OrderInfo order_info { get; set; }
    }

    public class GetSlotsRequest
    {
        public string requestorigin { get; set; }
        public Data data { get; set; }
    }
}
