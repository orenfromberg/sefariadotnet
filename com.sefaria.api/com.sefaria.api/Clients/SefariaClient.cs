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

namespace com.sefaria.api.Clients
{
	/// <summary>
	/// 
	/// </summary>
	public class SefariaClient
	{
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

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hasCommentary"></param>
		/// <param name="hasContext"></param>
		public SefariaClient(bool hasCommentary = false, bool hasContext = false)
		{
			HasCommentary = hasCommentary;
			HasContext = hasContext;

			Texts = new TextClient(HasCommentary, HasContext);
			Index = new IndexClient();
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
