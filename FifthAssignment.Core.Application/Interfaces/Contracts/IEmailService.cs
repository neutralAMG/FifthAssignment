
using FifthAssignment.Core.Application.Dtos.UtilsDto;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface IEmailService
	{
		Task SendEmailAsync(EmailRequest request);
	}
}
