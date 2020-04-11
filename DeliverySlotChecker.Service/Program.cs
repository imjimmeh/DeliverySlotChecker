using DeliverySlotChecker.Asda;
using DeliverySlotChecker.Asda.Models;
using DeliverySlotChecker.Models;
using EmailService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliverySlotChecker.Service
{
    class Program
    {
        static Random _random;
        static SmtpEmailService _emailService;
        static List<DeliveryService> _deliveryServices;
        static Dictionary<string, Func<ServiceSettings, DeliveryService>> _availableServices;

        static async Task Main(string[] args)
        {
            Initialise();

            while (true)
            {
                foreach (var service in _deliveryServices)
                {
                    bool foundAvailableSlot = false;
                    Console.WriteLine($"Fetching available slots for {service.Name}");
                    var sb = new StringBuilder();

                    try
                    {
                        var deliverySlots = service.GetDeliverySlots().Result;
                        var availableSlots = deliverySlots.Where(d => d.Available).ToList();
                        if (availableSlots.Count > 0)
                            SendEmail(availableSlots, service.Name);
                        else
                            Console.WriteLine($"Found no available slots for {service.Name}");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error - {ex.Message} - {ex.StackTrace}");
                        continue;
                    }

                    if (!foundAvailableSlot)
                    {
                    }
                }
                int minutesToWait = _random.Next(1, 5);
                Console.WriteLine($"Waiting {minutesToWait} minutes");
                Console.WriteLine("");
                Console.WriteLine("");
                await Task.Delay(1000 * 60 * minutesToWait);
            }
        }

        private static void SendEmail(List<DeliverySlot> slots, string serviceName)
        {
            StringBuilder sb = BuildBody(slots, serviceName);
            var recipients = ConfigurationManager.AppSettings["emailRecipients"].Split(",");

            try
            {
                _emailService.SendEmail(
                    sb.ToString(),
                    $"There are {slots.Count} slots available at {serviceName}",
                    recipients
                    );
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private static StringBuilder BuildBody(List<DeliverySlot> slots, string serviceName)
        {
            var sb = new StringBuilder();
            foreach (var slot in slots)
            {
                var text = $"There is a new {slot.DeliveryType.ToString()} slot available at {serviceName} between {slot.StartDate} - {slot.EndDate}. It costs {slot.BasePrice}";
                Console.WriteLine(text);
                sb.AppendLine(text + "<br/>");
            }

            return sb;
        }

        private static void Initialise()
        {
            _random = new Random();
            _availableServices = new Dictionary<string, Func<ServiceSettings, DeliveryService>>();
            _deliveryServices = new List<DeliveryService>();
            _emailService = new SmtpEmailService(ConfigurationManager.AppSettings["smtphost"], ConfigurationManager.AppSettings["emailUsername"], ConfigurationManager.AppSettings["emailPassword"]);
            SetAvailableServices();
            LoadServices();
        }

        private static void SetAvailableServices()
        {
            Func<ServiceSettings, DeliveryService> asdaServiceCreator = s => new AsdaService(s);
            _availableServices.Add("Asda", asdaServiceCreator);
        }


        private static void LoadServices()
        {
            var settingsData = File.ReadAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/settings.json");
            var parsed = JsonSerializer.Deserialize<Settings>(settingsData);
            foreach (var service in parsed.Services.Where(s => s.Enabled))
            {
                CreateService(service);
            }
        }

        private static void CreateService(ServiceSettings serviceSettings)
        {
            var matchingAvailableService = _availableServices.FirstOrDefault(s => s.Key == serviceSettings.Service);
            if(matchingAvailableService.Value != null)
            {
                _deliveryServices.Add(matchingAvailableService.Value(serviceSettings));
            }
        }
    }
}
