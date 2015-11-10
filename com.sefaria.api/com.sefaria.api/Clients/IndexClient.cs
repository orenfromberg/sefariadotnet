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
	public class IndexClient: BaseClient
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="authentication"></param>
		public IndexClient(IAuthentication authentication) : base(authentication)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static async Task<Index> GetTitlesAsync()
		{
			String json = await Http.WebRequest.SendGetAsync(new Uri(String.Format("{0}", Endpoints.Titles)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Index>(json);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static Index GetTitles()
		{
			String json = Http.WebRequest.SendGet(new Uri(String.Format("{0}", Endpoints.Titles)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Index>(json);			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static async Task<List<Index>> GetContentsAsync()
		{
			String json = await Http.WebRequest.SendGetAsync(new Uri(String.Format("{0}", Endpoints.Index)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<List<Index>>(json);

			//todo handle json exceptions here
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static List<Index> GetContents()
		{
			String json = Http.WebRequest.SendGet(new Uri(String.Format("{0}", Endpoints.Index )));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<List<Index>>(json);

			//todo handle json exceptions here
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public static async Task<Index> GetIndexAsync(String reference)
		{
			String json = await Http.WebRequest.SendGetAsync(new Uri(String.Format("{0}/{1}", Endpoints.Index, reference)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Index>(json);

			//todo handle json exceptions here
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public static Index GetIndex(String reference)
		{
			String json = Http.WebRequest.SendGet(new Uri(String.Format("{0}/{1}", Endpoints.Index, reference)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Index>(json);

			//todo handle json exceptions here
		}
	}
}