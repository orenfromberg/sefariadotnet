#region Copyright (C) 2015 Oren Fromberg

//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/.

#endregion

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
