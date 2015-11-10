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

using System.Collections.Generic;
using com.sefaria.api.Common;
using Newtonsoft.Json;

namespace com.sefaria.api.Models
{
	/// <summary>
	/// Link to another text
	/// </summary>
	public class Link
	{
		/// <summary>
		/// Category
		/// </summary>
		[JsonProperty("category")]
		public string Category { get; set; }

		/// <summary>
		/// Commentator
		/// </summary>
		[JsonProperty("commentator")]
		public string Commentator { get; set; }

		/// <summary>
		/// Hebrew name of Commentator
		/// </summary>
		[JsonProperty("heCommentator")]
		public string HeCommentator { get; set; }

		/// <summary>
		/// Type of link
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Anchor Reference
		/// </summary>
		[JsonProperty("anchorRef")]
		public string AnchorRef { get; set; }

		/// <summary>
		/// Anchor Text
		/// </summary>
		[JsonProperty("anchorText")]
		public string AnchorText { get; set; }

		/// <summary>
		/// Source Reference
		/// </summary>
		[JsonProperty("sourceRef")]
		public string SourceRef { get; set; }

		/// <summary>
		/// Commentary Number
		/// </summary>
		[JsonProperty("commentaryNum")]
		public int CommentaryNum { get; set; }

		/// <summary>
		/// Anchor Verse
		/// </summary>
		[JsonProperty("anchorVerse")]
		public int AnchorVerse { get; set; }

		/// <summary>
		/// Hebrew Title
		/// </summary>
		[JsonProperty("heTitle")]
		public string HeTitle { get; set; }

		/// <summary>
		/// Source Hebrew Reference
		/// </summary>
		[JsonProperty("sourceHeRef")]
		public string SourceHeRef { get; set; }

		/// <summary>
		/// List of Texts
		/// </summary>
		[JsonProperty("text")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> Text { get; set; }

		/// <summary>
		/// Id
		/// </summary>
		[JsonProperty("_id")]
		public string Id { get; set; }

		/// <summary>
		/// Reference
		/// </summary>
		[JsonProperty("ref")]
		public string Ref { get; set; }

		/// <summary>
		/// Hebrew Content
		/// </summary>
		[JsonProperty("he")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> He { get; set; }
	}
}