using System;

namespace DeliverySlotChecker.Models
{
    public class DeliverySlot
    {
        DateTime _startDate;
        public DateTime StartDate => _startDate;

        DateTime _endDate;
        public DateTime EndDate => _endDate;

        double _basePrice;
        public double BasePrice => _basePrice;

        bool _available;

        DeliveryType _deliveryType;
        public DeliveryType DeliveryType;

        public DeliverySlot(DateTime startDate, DateTime endDate, double basePrice, bool available, DeliveryType deliveryType)
        {
            _startDate = startDate;
            _endDate = endDate;
            _basePrice = basePrice;
            _available = available;
            _deliveryType = deliveryType;
        }

        public bool Available => _available;
    }
}