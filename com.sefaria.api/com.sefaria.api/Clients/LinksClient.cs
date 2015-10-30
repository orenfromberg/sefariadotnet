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

using System;
using System.Collections.Generic;
using com.sefaria.api.Api;
using com.sefaria.api.Models;
using Newtonsoft.Json;

namespace com.sefaria.api.Clients
{
	public class LinksClient
	{
		public List<Link> GetLinks(string reference)
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
