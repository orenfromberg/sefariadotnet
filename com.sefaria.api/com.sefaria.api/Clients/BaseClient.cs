using System;
using com.sefaria.api.Authentication;

namespace com.sefaria.api.Clients
{
	public class BaseClient
	{
		protected IAuthentication Authentication;

		public BaseClient(IAuthentication authentication)
		{
			if (authentication == null)
			{
				throw new ArgumentException("The IAuthentication Object must not be null.");
			}

			Authentication = authentication;
		}
	}
}