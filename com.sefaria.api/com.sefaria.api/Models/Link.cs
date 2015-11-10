using System.Collections.Generic;
using com.sefaria.api.Common;
using Newtonsoft.Json;

namespace com.sefaria.api.Models
{
	public class Link
	{
		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("commentator")]
		public string Commentator { get; set; }

		[JsonProperty("heCommentator")]
		public string HeCommentator { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("anchorRef")]
		public string AnchorRef { get; set; }

		[JsonProperty("anchorText")]
		public string AnchorText { get; set; }

		[JsonProperty("sourceRef")]
		public string SourceRef { get; set; }

		[JsonProperty("commentaryNum")]
		public int CommentaryNum { get; set; }

		[JsonProperty("anchorVerse")]
		public int AnchorVerse { get; set; }

		[JsonProperty("heTitle")]
		public string HeTitle { get; set; }

		[JsonProperty("sourceHeRef")]
		public string SourceHeRef { get; set; }

		[JsonProperty("text")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> Text { get; set; }

		[JsonProperty("_id")]
		public string Id { get; set; }

		[JsonProperty("ref")]
		public string Ref { get; set; }

		[JsonProperty("he")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> He { get; set; }
	}
}