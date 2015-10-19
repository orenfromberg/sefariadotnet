using System;
using Newtonsoft.Json;
using Text = com.sefaria.api.Texts.Text;
using Endpoints = com.sefaria.api.Api.Endpoints;

namespace com.sefaria.api.Clients
{
	public class TextClient
	{
		public bool HasCommentary { get; set; }

		public bool HasContext { get; set; }

		public TextClient(bool hasCommentary = false, bool hasContext = false)
		{
			HasCommentary = hasCommentary;
			HasContext = hasContext;
		}

		public Text GetText(string reference)
		{
			String getUrl = String.Format("{0}/{1}?{2}&{3}",
				Endpoints.Text, 
				reference,
				HasContext ? String.Empty : "context=0",
				HasCommentary ? String.Empty : "commentary=0");

			String json = Http.WebRequest.SendGet(new Uri(getUrl));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Text>(json);
		}

	}
}
