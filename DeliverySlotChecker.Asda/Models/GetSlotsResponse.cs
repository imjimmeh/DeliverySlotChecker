using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySlotChecker.Asda.Models
{

    public class GetSlotsResponseServiceAddress
    {
        public bool is_apo_fpo { get; set; }
        public bool is_po_box { get; set; }
        public object country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public object city { get; set; }
        public string postcode { get; set; }
        public object address_line_one { get; set; }
        public object address_line_two { get; set; }
    }

    public class GetSlotsResponseServiceInfo
    {
        public string fulfillment_type { get; set; }
        public object reservation_type { get; set; }
        public object dispense_type { get; set; }
        public int priority { get; set; }
        public object carrier { get; set; }
        public object fulfillment_option { get; set; }
        public object location_type { get; set; }
        public int service_time { get; set; }
        public bool is_recurring_slot { get; set; }
        public bool enable_express { get; set; }
    }

    public class Grid
    {
        public string horizon { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public bool is_horizon_extended { get; set; }
        public string horizon_for_subscribers { get; set; }
        public DateTime end_date_for_subscribers { get; set; }
    }

    public class SlotInfo
    {
        public List<object> reason { get; set; }
        public string window { get; set; }
        public string slot_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public string status { get; set; }
        public int priority { get; set; }
        public object slot_type { get; set; }
        public double base_slot_price { get; set; }
        public double final_slot_price { get; set; }
        public double total_discount { get; set; }
        public double total_premium { get; set; }
        public List<object> price_details { get; set; }
        public DateTime customer_cutoff_time { get; set; }
        public int max_capacity { get; set; }
        public int current_capacity { get; set; }
        public int reserved_capacity { get; set; }
        public int sla_in_mins { get; set; }
        public bool is_ammendable { get; set; }
        public object capacity_type { get; set; }
        public bool is_express_slot { get; set; }
    }

    public class Slot
    {
        public string supported_timezone { get; set; }
        public SlotInfo slot_info { get; set; }
    }

    public class SlotDay
    {
        public List<Slot> slots { get; set; }
        public DateTime slot_date { get; set; }
        public string dispense_store_id { get; set; }
        public string fulfill_store_id { get; set; }
        public object remote_site_id { get; set; }
        public string accesspoint_id { get; set; }
        public string supported_timezone { get; set; }
        public string fulfillment_type { get; set; }
    }

    public class ServiceInfo2
    {
        public string fulfillment_type { get; set; }
        public string reservation_type { get; set; }
        public string dispense_type { get; set; }
        public int priority { get; set; }
        public string carrier { get; set; }
        public string fulfillment_option { get; set; }
        public string location_type { get; set; }
        public int service_time { get; set; }
        public bool is_recurring_slot { get; set; }
        public bool enable_express { get; set; }
    }

    public class ServiceAddress2
    {
        public bool is_apo_fpo { get; set; }
        public bool is_po_box { get; set; }
        public string country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string address_line_one { get; set; }
        public object address_line_two { get; set; }
    }

    public class ContactInformation
    {
        public string contact_phone_no { get; set; }
    }

    public class WorkHours
    {
        public string monday { get; set; }
        public string tuesday { get; set; }
        public string wednesday { get; set; }
        public string thursday { get; set; }
        public string friday { get; set; }
        public string saturday { get; set; }
        public string sunday { get; set; }
    }

    public class NearestCollectionPoint
    {
        public object current_time { get; set; }
        public object currency { get; set; }
        public string accesspoint_id { get; set; }
        public ServiceInfo2 service_info { get; set; }
        public ServiceAddress2 service_address { get; set; }
        public string accesspoint_name { get; set; }
        public string description { get; set; }
        public string supported_timezone { get; set; }
        public string location_instructions { get; set; }
        public string image_url { get; set; }
        public double minimum_purchase { get; set; }
        public double minimum_purchase_charge { get; set; }
        public string bag_fee_type { get; set; }
        public double bag_fee_value { get; set; }
        public double distance { get; set; }
        public object remote_site_id { get; set; }
        public string dispense_store_id { get; set; }
        public string fulfill_store_id { get; set; }
        public string service_area { get; set; }
        public ContactInformation contact_information { get; set; }
        public bool is_new_accesspoint { get; set; }
        public bool is_in_training { get; set; }
        public double default_volume { get; set; }
        public double default_weight { get; set; }
        public bool is_active { get; set; }
        public DateTime start_date { get; set; }
        public object end_date { get; set; }
        public bool cp_enabled_flag { get; set; }
        public bool is_test { get; set; }
        public DateTime cp_managed_start_date { get; set; }
        public bool is_cp_managed { get; set; }
        public bool is_oms_active { get; set; }
        public DateTime oms_start_date { get; set; }
        public bool is_gop_active { get; set; }
        public DateTime gop_start_date { get; set; }
        public bool is_v2_api { get; set; }
        public bool is_crowd_sourced { get; set; }
        public bool is_drive_through { get; set; }
        public List<string> supported_slot_windows { get; set; }
        public bool is_ebt_pay_in_person { get; set; }
        public bool allow_age_restricted { get; set; }
        public bool allow_alcohol { get; set; }
        public bool allow_bag_fee { get; set; }
        public WorkHours work_hours { get; set; }
        public bool allow_ssr { get; set; }
    }

    public class GetSlotsResponseData
    {
        public GetSlotsResponseServiceAddress service_address { get; set; }
        public GetSlotsResponseServiceInfo service_info { get; set; }
        public DateTime current_time { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public List<string> supported_slot_windows { get; set; }
        public string selected_slot_window { get; set; }
        public Grid grid { get; set; }
        public List<SlotDay> slot_days { get; set; }
        public NearestCollectionPoint nearest_collection_point { get; set; }
        public string currency { get; set; }
    }

    public class GetSlotsResponse
    {
        public GetSlotsResponseData data { get; set; }
        public int status_code { get; set; }
        public string status_message { get; set; }
    }
}
