
using System.Text;

namespace FifthAssignment.Core.Application.Utils.GenerateProductCodeString
{
	public class GenerateACodeString : ICodeGenerator
	{
		private readonly static string Characters = "1234567890";
		public string GenerateNumberIdentifierCode()
		{
			StringBuilder stringBuilder = new();
			Random random = new();
			for (int i = 0; i< 9;i++) {
				stringBuilder.Append(Characters[random.Next(Characters.Length)]);
			}

			return stringBuilder.ToString();
		}
		public string GenerateCreditCardCVVCode()
		{
			StringBuilder stringBuilder = new();
			Random random = new();
			for (int i = 0; i < 3; i++)
			{
				stringBuilder.Append(Characters[random.Next(Characters.Length)]);
			}

			return stringBuilder.ToString();
		}
	
	}
}
