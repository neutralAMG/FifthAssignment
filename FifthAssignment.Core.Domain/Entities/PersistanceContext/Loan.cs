﻿using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class Loan : BaseBankProductTypeEntity<Guid>
    {
        public string UserId { get; set; }
        // public User user { get; set; }
    }
}