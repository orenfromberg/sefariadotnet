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
using Newtonsoft.Json;

namespace com.sefaria.api.Models
{
	public class Commentary
	{
		[JsonProperty("_id")]
		public String Id { get; set; }

		[JsonProperty("anchorRef")]
		public String AnchorReference { get; set; }

		[JsonProperty("anchorText")]
		public String AnchorText { get; set; }

		[JsonProperty("anchorVerse")]
		public int AnchorVerse { get; set; }

		[JsonProperty("category")]
		public String Category { get; set; }

		[JsonProperty("commentaryNum")]
		public int CommentaryNumber { get; set; }

		[JsonProperty("commentator")]
		public String Commentator { get; set; }

		[JsonProperty("he")]
		public String He { get; set; }

		[JsonProperty("ref")]
		public String Reference { get; set; }

		[JsonProperty("sourceRef")]
		public String SourceReference { get; set; }

		[JsonProperty("text")]
		public String Text { get; set; }

		[JsonProperty("type")]
		public String Type { get; set; }
	}
}
