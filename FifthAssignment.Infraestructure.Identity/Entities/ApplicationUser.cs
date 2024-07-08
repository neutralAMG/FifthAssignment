

using FifthAssignment.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FifthAssignment.Infraestructure.Identity.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName  { get; set; }
		public string LastName  { get; set; }
		public string Cedula { get; set; }
		public IList<BankAccoount> BankAccoounts {  get; set; }
		public IList<CreditCard> CreditCards {  get; set; }
		public IList<Beneficiary> Beneficiaries {  get; set; }
		public IList<Loan> Loans {  get; set; }
	}
}
