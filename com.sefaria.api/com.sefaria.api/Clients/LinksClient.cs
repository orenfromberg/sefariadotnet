using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.sefaria.api.Api;
using com.sefaria.api.Authentication;
using com.sefaria.api.Models;
using Newtonsoft.Json;

namespace com.sefaria.api.Clients
{
	/// <summary>
	/// 
	/// </summary>
	public class LinksClient: BaseClient
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="authentication"></param>
		public LinksClient(IAuthentication authentication) : base(authentication)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public static async Task<List<Link>> GetLinksAsync(string reference)
		{
			String json = await Http.WebRequest.SendGetAsync(new Uri(String.Format("{0}/{1}", Endpoints.Links, reference)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<List<Link>>(json);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public static List<Link> GetLinks(string reference)
		{
			String json = Http.WebRequest.SendGet(new Uri(String.Format("{0}/{1}", Endpoints.Links, reference)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<List<Link>>(json);			
		}
	}
}
