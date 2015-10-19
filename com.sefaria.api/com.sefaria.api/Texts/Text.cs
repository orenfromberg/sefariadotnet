using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace com.sefaria.api.Texts
{
	public class Text
	{
		[JsonProperty("text")]
		public List<String> TextStrings { get; set; }

		[JsonProperty("heTitleVariants")]
		public List<String> HebrewTitleVariantsStrings { get; set; }

		[JsonProperty("versionSource")]
		public String VersionSource { get; set; }

		[JsonProperty("heTitle")]
		public String HebrewTitle { get; set; }

		[JsonProperty("heRef")]
		public String HebrewReference { get; set; }

		[JsonProperty("toSections")]
		public List<int> ToSectionsInts { get; set; }

		[JsonProperty("sectionRef")]
		public String SectionReference { get; set; }

		[JsonProperty("heVersionTitle")]
		public String HebrewVersionTitle { get; set; }

		[JsonProperty("book")]
		public String Book { get; set; }
	}
}
