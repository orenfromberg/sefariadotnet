namespace com.sefaria.api.Authentication
{
	/// <summary>
	/// 
	/// </summary>
	public class StaticAuthentication: IAuthentication
	{
		/// <summary>
		/// 
		/// </summary>
		public string AccessToken { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="accessToken"></param>
		public StaticAuthentication(string accessToken)
		{
			AccessToken = accessToken;
		}
	}
}