﻿using Easy.Hosts.Core.Enums;
using System;

namespace Easy.Hosts.Core.DTOs.BookingDto
{
    public class BookingCreateDto
    {
        public string CodeBooking { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string UserId { get; set; }
        public Guid BedroomId { get; set; }
    }
}
