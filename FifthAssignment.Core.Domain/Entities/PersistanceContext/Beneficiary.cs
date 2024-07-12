﻿using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class Beneficiary : BaseEntity<Guid>
    {
		public Beneficiary()
		{
			Id = Guid.NewGuid();
			
		}
		public string UserId { get; set; }
        public string UserBeneficiaryId { get; set; }
	}
}
