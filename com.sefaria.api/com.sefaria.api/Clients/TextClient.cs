using System;
using System.Threading.Tasks;
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

		private string BuildGetUrl(String reference)
		{
			return String.Format("{0}/{1}?{2}&{3}",
				Endpoints.Text,
				reference,
				HasContext ? String.Empty : "context=0",
				HasCommentary ? String.Empty : "commentary=0");
		}

		/// <summary>
		/// Gets a text from sefaria asynchronously
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public async Task<Text> GetTextAsync(String reference)
		{
			String json = await Http.WebRequest.SendGetAsync(new Uri(BuildGetUrl(reference)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Text>(json);
		
		}

		/// <summary>
		/// Gets a text from sefaria
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public Text GetText(String reference)
		{
			String json = Http.WebRequest.SendGet(new Uri(BuildGetUrl(reference)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Text>(json);
		}

	}
}
