using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace com.sefaria.api.Texts
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
