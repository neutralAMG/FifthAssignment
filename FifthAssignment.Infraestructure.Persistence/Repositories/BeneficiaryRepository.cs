

using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
    public class BeneficiaryRepository : BaseRepository<Beneficiary>, IBeneficiaryRepository
    {
        private readonly fifthAssignmentContext _context;

        public BeneficiaryRepository(fifthAssignmentContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<List<Beneficiary>> GetAllAsync()
        {
            return await _context.Beneficiaries.Include(b => b.UserBeneficiaryBankAccount).ToListAsync();
        }
        public async Task<List<Beneficiary>> GetAllAsync(Func<Beneficiary, bool> filter)
        {
            return await Task.FromResult(_context.Beneficiaries.Include(b => b.UserBeneficiaryBankAccount).Where(filter).ToList());
        }
        public override async Task<Beneficiary> GetByIdAsync(Guid id)
        {
            return await _context.Beneficiaries.Where(b => b.Id == id).FirstOrDefaultAsync();
        }


        public override async Task<Beneficiary> SaveAsync(Beneficiary entity)
        {
            return await base.SaveAsync(entity);
        }

        public override async Task<bool> UpdateAsync(Beneficiary entity)
        {
            Beneficiary beneficiaryToUpdate = await GetByIdAsync(entity.Id);

            return await base.UpdateAsync(beneficiaryToUpdate);

        }
        public override async Task<bool> DeleteAsync(Beneficiary entity)
        {
            Beneficiary BeneficiaryToBeDeleted = await GetByIdAsync(entity.Id);
            _context.Beneficiaries.Remove(BeneficiaryToBeDeleted);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
