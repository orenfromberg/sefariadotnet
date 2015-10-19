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
		[JsonProperty("book")]
		public string Book { get; set; }
	}
}
