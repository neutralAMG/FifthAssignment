

using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Dtos.Payments;
using FifthAssignment.Core.Application.Models;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.BeneficiaryModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Models.LoanModels;
using FifthAssignment.Core.Application.Models.UserModel;
using FifthAssignment.Core.Application.Models.UserModels;
using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Utils.Mapper
{
	public class GeneralProfile : Profile
	{
		public GeneralProfile()
		{
			#region User mapping configuration setup
			CreateMap<UserGetResponceDto, UserModel>()
				  .ForMember(dest => dest.Roles, opt => opt.MapFrom(opt => opt.Roles));

			CreateMap<RegisterRequest, SaveUserModel>()
				  .ForMember(dest => dest.ComfirmPassword, opt => opt.Ignore())
				  .ReverseMap();

			CreateMap<UpdateUserDto, SaveUserModel>()
				   .ForMember(dest => dest.ComfirmPassword, opt => opt.Ignore())
				  .ReverseMap();
			#endregion

			#region Beneficiary mapping configuration setup
			CreateMap<Beneficiary, BeneficiaryModel>()
				 .ForMember(dest => dest.UserBeneficiaryBankAccount, opt => opt.MapFrom(opt => opt.UserBeneficiaryBankAccount))
				 .ReverseMap()
				 .ForMember(dest => dest.UserBeneficiaryBankAccount, opt => opt.Ignore());

			CreateMap<Beneficiary, SaveBeneficiaryModel>()
				  .ForMember(dest => dest.UserId, opt => opt.Ignore())
				  .ReverseMap()
				  .ForMember(dest => dest.UserBeneficiaryBankAccount, opt => opt.Ignore())
				  .ForMember(dest => dest.Id, opt => opt.Ignore());

			#endregion

			#region BankAccount mapping configuration setup
			CreateMap<BankAccount, BankAccountModel>()
				  .ReverseMap()
				   // .ForMember(dest => dest.BeneficiaryPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.CreditCardPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.LoansPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.MoneyAdvances, opt => opt.Ignore())
				   .ForMember(dest => dest.ExpressPaymentsFrom, opt => opt.Ignore())
				   .ForMember(dest => dest.ExpressPaymentsTo, opt => opt.Ignore())
				   .ForMember(dest => dest.UserPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.TransfersFrom, opt => opt.Ignore())
				   .ForMember(dest => dest.TransfersTo, opt => opt.Ignore());

			CreateMap<BankAccount, SaveBankAccountModel>()
				  .ReverseMap()
				   //   .ForMember(dest => dest.BeneficiaryPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.CreditCardPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.LoansPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.MoneyAdvances, opt => opt.Ignore())
				   .ForMember(dest => dest.ExpressPaymentsFrom, opt => opt.Ignore())
				   .ForMember(dest => dest.ExpressPaymentsTo, opt => opt.Ignore())
				   .ForMember(dest => dest.UserPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.TransfersFrom, opt => opt.Ignore())
				   .ForMember(dest => dest.TransfersTo, opt => opt.Ignore());

			CreateMap<BankAccountModel, SaveBankAccountModel>()
			 .ReverseMap();
			#endregion

			#region Loan mapping configuration setup
			CreateMap<Loan, LoanModel>().ReverseMap()
				   .ForMember(dest => dest.LoansPayments, opt => opt.Ignore());

			CreateMap<Loan, SaveLoanModel>()
				  .ForMember(dest => dest.UserId, opt => opt.Ignore())
				  .ReverseMap()
				   .ForMember(dest => dest.LoansPayments, opt => opt.Ignore());

			CreateMap<LoanModel, SaveLoanModel>()
			   .ReverseMap();
			#endregion

			#region CreditCard mapping configuration setup
			CreateMap<CreditCard, CreditCardModel>()
				  .ReverseMap()
				   .ForMember(dest => dest.CreditCardPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.MoneyAdvances, opt => opt.Ignore());

			CreateMap<CreditCard, SaveCreditCardModel>()
				  .ReverseMap()
				   .ForMember(dest => dest.CreditCardPayments, opt => opt.Ignore())
				   .ForMember(dest => dest.MoneyAdvances, opt => opt.Ignore());

			CreateMap<CreditCardModel, SaveCreditCardModel>()
				 .ReverseMap();
			#endregion

			#region Transaction mapping configuration setup
			CreateMap<CreditcardPayment, SaveBasePaymentDto>()
				   .ForMember(dest => dest.Emisor, opt => opt.MapFrom(ot => ot.UserBankAccountId))
				   .ForMember(dest => dest.Receiver, opt => opt.MapFrom(ot => ot.UserCreditCardId))
				  .ReverseMap()
				   .ForMember(dest => dest.UserBankAccountId, opt => opt.MapFrom(ot => ot.Emisor))
				   .ForMember(dest => dest.UserCreditCardId, opt => opt.MapFrom(ot => ot.Receiver))
				   .ForMember(dest => dest.UserCreditCard, opt => opt.Ignore())
				   .ForMember(dest => dest.UserBankAccount, opt => opt.Ignore());

			CreateMap<ExpressPayment, SaveBasePaymentDto>()
				   .ForMember(dest => dest.Emisor, opt => opt.MapFrom(ot => ot.BankAccountFromId))
				   .ForMember(dest => dest.Receiver, opt => opt.MapFrom(ot => ot.BankAccountToId))
				  .ReverseMap()
				   .ForMember(dest => dest.BankAccountFromId, opt => opt.MapFrom(ot => ot.Emisor))
				   .ForMember(dest => dest.BankAccountToId, opt => opt.MapFrom(ot => ot.Receiver))
				   .ForMember(dest => dest.BankAccountFrom, opt => opt.Ignore())
				   .ForMember(dest => dest.BankAccountTo, opt => opt.Ignore());

			CreateMap<BeneficiaryPayment, SaveBasePaymentDto>()
				 .ForMember(dest => dest.Emisor, opt => opt.MapFrom(ot => ot.UserBankAccountId))
				 .ForMember(dest => dest.Receiver, opt => opt.MapFrom(ot => ot.BeneficiaryBankAccountId))
				 .ReverseMap()
				 .ForMember(dest => dest.UserBankAccountId, opt => opt.MapFrom(ot => ot.Emisor))
				   .ForMember(dest => dest.BeneficiaryBankAccountId, opt => opt.MapFrom(ot => ot.Receiver))
				 .ForMember(dest => dest.UserBankAccount, opt => opt.Ignore())
				 .ForMember(dest => dest.UserBeneficiaryBankAccount, opt => opt.Ignore());

			CreateMap<LoanPayment, SaveBasePaymentDto>()
				   .ForMember(dest => dest.Emisor, opt => opt.MapFrom(ot => ot.UserBankAccountId))
				   .ForMember(dest => dest.Receiver, opt => opt.MapFrom(ot => ot.UserLoanId))
				   .ReverseMap()
				   .ForMember(dest => dest.UserBankAccountId, opt => opt.MapFrom(ot => ot.Emisor))
				   .ForMember(dest => dest.UserLoanId, opt => opt.MapFrom(ot => ot.Receiver))
				   .ForMember(dest => dest.UserBankAccount, opt => opt.Ignore())
				   .ForMember(dest => dest.UserLoan, opt => opt.Ignore());

			CreateMap<Transfer, SaveBasePaymentDto>()
				  .ForMember(dest => dest.Emisor, opt => opt.MapFrom(ot => ot.UserAccountFromId))
				  .ForMember(dest => dest.Receiver, opt => opt.MapFrom(ot => ot.UserAccountToId))
				  .ReverseMap()
				  .ForMember(dest => dest.UserAccountFromId, opt => opt.MapFrom(ot => ot.Emisor))
				   .ForMember(dest => dest.UserAccountToId, opt => opt.MapFrom(ot => ot.Receiver))
				  .ForMember(dest => dest.UserAccountFrom, opt => opt.Ignore())
				  .ForMember(dest => dest.UserAccountTo, opt => opt.Ignore());

			CreateMap<MoneyAdvance, SaveBasePaymentDto>()
				  .ForMember(dest => dest.Emisor, opt => opt.MapFrom(ot => ot.UserCreditCardId))
				  .ForMember(dest => dest.Receiver, opt => opt.MapFrom(ot => ot.UserBankAccountId))
				  .ReverseMap()
				  .ForMember(dest => dest.UserCreditCardId, opt => opt.MapFrom(ot => ot.Emisor))
				  .ForMember(dest => dest.UserBankAccountId, opt => opt.MapFrom(ot => ot.Receiver))
				  .ForMember(dest => dest.UserCreditCard, opt => opt.Ignore())
				  .ForMember(dest => dest.UserBankAccount, opt => opt.Ignore());

			#endregion

			#region HomeInformation mapping configuration setup

			CreateMap<HomeInformation, HomeInformationGetModel>();


			#endregion


			#region RegisterTransaction mapping configuration setup
			CreateMap<Transaction, SaveBasePaymentDto>()
				.ForMember(dest => dest.Amount, opt => opt.MapFrom(ot => ot.Amount))
				  .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(ot => ot.TransactionTypeId))
				  .ReverseMap()
				  		.ForMember(dest => dest.Amount, opt => opt.MapFrom(ot => ot.Amount))
				  .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(ot => ot.TransactionType));

			CreateMap<Transaction, SavePaymentDto>()
	          .ForMember(dest => dest.Amount, opt => opt.MapFrom(ot => ot.Amount))
	          .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(ot => ot.TransactionTypeId))
	          .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(ot => ot.TransactionTypeId))
	           .ReverseMap()
			  .ForMember(dest => dest.Amount, opt => opt.MapFrom(ot => ot.Amount))
	          .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(ot => ot.TransactionTypeId));
			#endregion
		}
	}
}
