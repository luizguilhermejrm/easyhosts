﻿
using Easy.Hosts.Core.Enums;
using System;

namespace Easy.Hosts.Core.DTOs.OrderServiceDto
{
    public class OrderServiceReadDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public StatusOrderService Status { get; set; }
        public OrderServiceType Type { get; set; }
    }
}