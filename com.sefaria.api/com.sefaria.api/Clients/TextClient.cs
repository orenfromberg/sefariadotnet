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

		public TextClient(bool hasCommentary, bool hasContext)
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
