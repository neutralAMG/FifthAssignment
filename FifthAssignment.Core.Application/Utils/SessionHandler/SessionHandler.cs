using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FifthAssignment.Core.Application.Utils.SessionHandler
{
	public static class SessionHandler
	{
		public static void Set<TValue>(this ISession session, string key, TValue value)
		{
			string ValueToBeSaved = JsonConvert.SerializeObject(value);
			session.SetString(key, ValueToBeSaved);
		}

		public static TValue Get<TValue>(this ISession session, string key)
		{

			string ValueFromSessionSaved = session.GetString(key);

		return ValueFromSessionSaved == null? default : JsonConvert.DeserializeObject<TValue>(ValueFromSessionSaved);

			
		} 
	} 
}
