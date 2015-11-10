using System;
using System.Threading.Tasks;
using com.sefaria.api.Authentication;
using Newtonsoft.Json;
using Text = com.sefaria.api.Models.Text;
using Endpoints = com.sefaria.api.Api.Endpoints;

namespace com.sefaria.api.Clients
{
	public class TextClient: BaseClient
	{
		#region Private Fields

		private IAuthentication _authentication;

		#endregion

		#region Public Properties

		public bool HasCommentary { get; set; }

		public bool HasContext { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="authentication"></param>
		public TextClient(IAuthentication authentication)
			: this(authentication, false, false)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="authentication"></param>
		/// <param name="hasCommentary"></param>
		/// <param name="hasContext"></param>
		public TextClient(IAuthentication authentication, bool hasCommentary, bool hasContext)
			: base(authentication)
		{
			_authentication = authentication;
			HasCommentary = hasCommentary;
			HasContext = hasContext;
		}

		#endregion

		#region Static Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reference"></param>
		/// <param name="hasContext"></param>
		/// <param name="hasCommentary"></param>
		/// <returns></returns>
		private static string BuildGetUrl(String reference, bool hasContext, bool hasCommentary)
		{
			return String.Format("{0}/{1}?{2}&{3}",
				Endpoints.Text,
				reference,
				hasContext ? String.Empty : "context=0",
				hasCommentary ? String.Empty : "commentary=0");
		}

		/// <summary>
		/// Gets a text from sefaria asynchronously
		/// </summary>
		/// <param name="reference"></param>
		/// <param name="hasContext"></param>
		/// <param name="hasCommentary"></param>
		/// <returns></returns>
		public static async Task<Text> GetTextAsync(String reference, bool hasContext, bool hasCommentary)
		{
			String json = await Http.WebRequest.SendGetAsync(new Uri(BuildGetUrl(reference, hasContext, hasCommentary)));
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
		/// <param name="hasContext"></param>
		/// <param name="hasCommentary"></param>
		/// <returns></returns>
		static public Text GetText(String reference, bool hasContext, bool hasCommentary)
		{
			String json = Http.WebRequest.SendGet(new Uri(BuildGetUrl(reference, hasContext, hasCommentary)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<Text>(json);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets a text from sefaria asynchronously
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public async Task<Text> GetTextAsync(String reference)
		{
			return await GetTextAsync(reference, HasContext, HasCommentary);
		}


		/// <summary>
		/// Gets a text from sefaria
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public Text GetText(String reference)
		{
			return GetText(reference, HasContext, HasCommentary);
		}

		#endregion
	}
}
