using System.Net;

namespace com.sefaria.api.Http
{
	/// <summary>
	/// This class holds information about a received web response.
	/// </summary>
	public class ResponseReceivedEventArgs
	{
		/// <summary>
		/// The HttpWebResponse object that was received from the server.
		/// </summary>
		public HttpWebResponse Response { get; set; }

		/// <summary>
		/// Initializes a new instance of the ResponseReceivedEventArgs class.
		/// </summary>
		/// <param name="response">The HttpWebResponse received from the server.</param>
		public ResponseReceivedEventArgs(HttpWebResponse response)
		{
			Response = response;
		}
	}
}