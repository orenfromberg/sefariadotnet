using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.sefaria.api.Common;
using Newtonsoft.Json;

namespace com.sefaria.api.Texts
{
	public class Text
	{
		[JsonProperty("text")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> TextStrings { get; set; }

		[JsonProperty("he")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> HebrewTextStrings { get; set; }


		[JsonProperty("heTitleVariants")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> HebrewTitleVariantsStrings { get; set; }

		[JsonProperty("versionSource")]
		public String VersionSource { get; set; }

		[JsonProperty("heTitle")]
		public String HebrewTitle { get; set; }

		[JsonProperty("heRef")]
		public String HebrewReference { get; set; }

		[JsonProperty("toSections")]
		[JsonConverter(typeof(SingleOrArrayConverter<int>))]
		public List<int> ToSectionsInts { get; set; }

		[JsonProperty("sectionRef")]
		public String SectionReference { get; set; }

		[JsonProperty("heVersionTitle")]
		public String HebrewVersionTitle { get; set; }

		[JsonProperty("book")]
		public String Book { get; set; }
	}
}
