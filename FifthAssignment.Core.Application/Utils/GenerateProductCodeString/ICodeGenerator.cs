
namespace FifthAssignment.Core.Application.Utils.GenerateProductCodeString
{
	public interface ICodeGenerator
	{
		string GenerateNumberIdentifierCode();
		string GenerateCreditCardCVVCode();
	}
}
