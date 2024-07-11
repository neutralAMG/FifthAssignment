﻿using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class Transfer : BaseDateCreatedEntity<Guid>
    {
		public double Amount { get; set; }
		public Guid UserAccountFromId { get; set; }
        public Guid UserAccountToId { get; set; }

        public BankAccount UserAccountFrom { get; set; }
        public BankAccount UserAccountTo { get; set; }
    }
}
