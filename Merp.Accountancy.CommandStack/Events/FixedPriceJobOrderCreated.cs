﻿using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.CommandStack.Events
{
    public class FixedPriceJobOrderCreated : DomainEvent
    {
        public Guid JobOrderId { get; private set; }
        public int CustomerId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public DateTime DueDate { get; private set; }
        public string JobOrderName { get; private set; }

        public FixedPriceJobOrderCreated(Guid jobOrderId, int customerId, decimal price, DateTime dateOfStart, DateTime dueDate, string jobOrderName)
        {
            JobOrderId = jobOrderId;
            CustomerId = customerId;
            Price = price;
            DateOfStart = dateOfStart;
            DueDate = dueDate;
            JobOrderName = jobOrderName;
        }
    }
}
