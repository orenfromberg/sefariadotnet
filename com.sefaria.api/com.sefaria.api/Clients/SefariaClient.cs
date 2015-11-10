using System.Reflection;
using com.sefaria.api.Authentication;

namespace com.sefaria.api.Clients
{
	/// <summary>
	/// 
	/// </summary>
	public class SefariaClient
	{
		#region Private Fields

		private IAuthentication _authenticator;

		#endregion

		#region Public Properties

		/// <summary>
		/// 
		/// </summary>
		public bool HasCommentary { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool HasContext { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public TextClient Texts { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IndexClient Index { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public LinksClient Links { get; set; }

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="authenticator"></param>
		public SefariaClient(IAuthentication authenticator)
			:this(authenticator, false, false)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="authenticator"></param>
		/// <param name="hasCommentary"></param>
		/// <param name="hasContext"></param>
		public SefariaClient(IAuthentication authenticator, bool hasCommentary, bool hasContext)
		{
			HasCommentary = hasCommentary;
			HasContext = hasContext;
			_authenticator = authenticator;

			Texts = new TextClient(authenticator, HasCommentary, HasContext);
			Index = new IndexClient(authenticator);
			Links = new LinksClient(authenticator);
		}

		/// <summary>
		/// Returns the framework version of the SefariaClient
		/// </summary>
		/// <returns>The version number of the SefariaClient.</returns>
		public override string ToString()
		{
			return string.Format("SefariaClient Version {0}", Assembly.GetExecutingAssembly().GetName().Version);
		}
	}
}
