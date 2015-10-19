using System;
using Newtonsoft.Json;
using Text = com.sefaria.api.Texts.Text;
using Endpoints = com.sefaria.api.Api.Endpoints;
namespace com.sefaria.api.Clients
{
	public class TextClient
	{
		public Text GetText(string id)
		{
			String getUrl = String.Format("{0}/{1}", Endpoints.Text, id);
			String json = Http.WebRequest.SendGet(new Uri(getUrl));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Text>(json);
		}
	}
}
