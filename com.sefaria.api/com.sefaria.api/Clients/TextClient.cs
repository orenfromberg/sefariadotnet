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
