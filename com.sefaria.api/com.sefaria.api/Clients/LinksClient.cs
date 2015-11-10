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
//
//  This code is heavily based on stravadotnet: https://github.com/inexcitus/stravadotnet
//  Copyright (C) Sascha Simon 2014 and Licensed under GPL v3.
//  Visit the official homepage at http://www.sascha-simon.com

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.sefaria.api.Api;
using com.sefaria.api.Authentication;
using com.sefaria.api.Models;
using Newtonsoft.Json;

namespace com.sefaria.api.Clients
{
	/// <summary>
	/// 
	/// </summary>
	public class LinksClient: BaseClient
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="authentication"></param>
		public LinksClient(IAuthentication authentication) : base(authentication)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public static async Task<List<Link>> GetLinksAsync(string reference)
		{
			String json = await Http.WebRequest.SendGetAsync(new Uri(String.Format("{0}/{1}", Endpoints.Links, reference)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<List<Link>>(json);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public static List<Link> GetLinks(string reference)
		{
			String json = Http.WebRequest.SendGet(new Uri(String.Format("{0}/{1}", Endpoints.Links, reference)));
			if (String.IsNullOrEmpty(json))
			{
				throw new ArgumentException("the json string is null or empty.");
			}
			return JsonConvert.DeserializeObject<List<Link>>(json);			
		}
	}
}
