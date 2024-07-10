
using System.Text;

namespace FifthAssignment.Core.Application.Utils.GenerateProductCodeString
{
	public static class GenerateProductCodeString
	{
		private readonly static string Characters = "1234567890";
		public static string GenerateCode()
		{
			StringBuilder stringBuilder = new();
			Random random = new();
			for (int i = 0; i< 7;i++) {
				stringBuilder.Append(Characters[random.Next(Characters.Length)]);
			}

			return stringBuilder.ToString();
		}
	}
}
