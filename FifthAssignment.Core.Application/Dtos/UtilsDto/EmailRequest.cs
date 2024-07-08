
namespace FifthAssignment.Core.Application.Dtos.UtilsDto
{
	public record EmailRequest
	{
		public string To { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
	}
}
