using System;
using Newtonsoft.Json;

namespace com.sefaria.api.Models
{
	public class Version
	{
		[JsonProperty("language")]
		public String Language { get; set; }

		[JsonProperty("versionTitle")]
		public String VersionTitle { get; set; }
	}
}