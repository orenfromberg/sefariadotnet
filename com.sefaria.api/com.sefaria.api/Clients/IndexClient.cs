using System;
using com.sefaria.api.Api;
using com.sefaria.api.Texts;
using Newtonsoft.Json;

namespace com.sefaria.api.Clients
{
	public class IndexClient
	{
		public Index GetIndex()
		{
			String json = Http.WebRequest.SendGet(new Uri(String.Format("{0}", Endpoints.Index)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Index>(json);
		}
	}
}