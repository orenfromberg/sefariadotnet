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

using System.Collections.Generic;
using com.sefaria.api.Common;
using Newtonsoft.Json;

namespace com.sefaria.api.Texts
{
	/// <summary>
	/// 
	/// </summary>
	public class Index
	{
		[JsonProperty("heSectionNames")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> HeSectionNames { get; set; }

		[JsonProperty("books")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> Books { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("heTitle")]
		public string HeTitle { get; set; }

		[JsonProperty("contents")]
		[JsonConverter(typeof(SingleOrArrayConverter<Index>))]
		public List<Index> Contents { get; set; }

		[JsonProperty("firstSection")]
		public string FirstSection { get; set; }

		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("heCategory")]
		public string HeCategory { get; set; }

		[JsonProperty("length")]
		public int Length { get; set; }

		[JsonProperty("sparseness")]
		public int Sparseness { get; set; }

		[JsonProperty("textDepth")]
		public int TextDepth { get; set; }

		[JsonProperty("lengths")]
		[JsonConverter(typeof(SingleOrArrayConverter<int>))]
		public List<int> Lengths { get; set; }

		[JsonProperty("order")]
		[JsonConverter(typeof(SingleOrArrayConverter<int>))]
		public List<int> Order { get; set; }

		[JsonProperty("categories")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> Categories { get; set; }

		[JsonProperty("sectionNames")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> SectionNames { get; set; }

		[JsonProperty("addressTypes")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> AddressTypes { get; set; }

		[JsonProperty("titleVariants")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> TitleVariants { get; set; }

		[JsonProperty("heTitleVariants")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> HeTitleVariants { get; set; }


	}
}