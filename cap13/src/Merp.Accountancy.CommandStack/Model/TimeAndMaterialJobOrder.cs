﻿using Merp.Accountancy.CommandStack.Events;
using Merp.Accountancy.CommandStack.Services;
using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.CommandStack.Model
{
    public class TimeAndMaterialJobOrder : Aggregate
    {
        public decimal HourlyFee { get; private set; }
        public int CustomerId { get; private set; }
        public string Number { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public DateTime DateOfExpiration { get; private set; }
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }

        protected TimeAndMaterialJobOrder()
        {
            
        }

        public void Extend(DateTime newDueDate, decimal price)
        {
            this.DateOfExpiration = newDueDate;
            this.HourlyFee = price;

            var @event = new FixedPriceJobOrderExtendedEvent(
                this.Id, 
                this.DateOfExpiration,
                this.HourlyFee
            );
            RaiseEvent(@event);
        }

        public decimal CalculateBalance(IEventStore es)
        {
            return CalculateBalance(es, DateTime.Now);
        }

        public decimal CalculateBalance(IEventStore es, DateTime balanceDate)
        {
            if(es==null)
            {
                throw new ArgumentNullException("es");
            }
            throw new NotImplementedException();
        }

        public class Factory
        {
            public static TimeAndMaterialJobOrder CreateNewInstance(IJobOrderNumberGenerator jobOrderNumberGenerator, int customerId, decimal hourlyFee, DateTime dateOfStart, DateTime dateOfExpiration, string name)
            {
                var id = Guid.NewGuid();
                var jobOrder = new TimeAndMaterialJobOrder() 
                {
                    Id = id,
                    CustomerId = customerId,
                    HourlyFee = hourlyFee,
                    DateOfStart= dateOfStart,
                    DateOfExpiration=dateOfExpiration,
                    Name = name,
                    Number = jobOrderNumberGenerator.Generate(), 
                    IsCompleted = false
                };
                return jobOrder;
            }
        }
    }
}