using System;
using System.Collections.Generic;
using com.sefaria.api.Common;
using Newtonsoft.Json;

namespace com.sefaria.api.Texts
{
	/// <summary>
	/// 
	/// </summary>
	public class Text
	{
		/// <summary>
		/// The name of the requested text, normalized to the name 
		/// considered primary. Hence "Kohelet" becomes "Eccelesiates".
		/// </summary>
		[JsonProperty("book")]
		public String Book { get; set; }

		/// <summary>
		/// A hierarchal array of categories to which this text belongs,
		///  beginning with the highest level.
		/// </summary>
		[JsonProperty("categories")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> CategoryList { get; set; }

		/// <summary>
		/// An array of connections to this text including the connected 
		/// text and information about it. Looking up connections can be 
		/// slower and create larger response size. If you're only 
		/// interested in the text you requested use the ?commentary=0 
		/// parameter.
		/// </summary>
		[JsonProperty("commentary")]
		[JsonConverter(typeof(SingleOrArrayConverter<Commentary>))]
		public List<Commentary> CommentaryList { get; set; }

		/// <summary>
		/// The Hebrew (or Aramaic) text requested, as an array of strings.
		///  If only a single segment is requested (e.g. "Kohelet 5.3"),
		///  the surrounding text is still returned by default. If you only
		///  need the segment you request, you can add the parameter
		///  ?context=0 in which case this field will be a string. If no 
		/// Hebrew text exists for this ref, the value will be []. Note,
		///  Aramaic is not currently distinguished from Hebrew.
		/// </summary>
		[JsonProperty("he")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> HebrewTextList { get; set; }


		/// <summary>
		/// Only present if multiple Hebrew versions of this text are 
		/// available, this field contains an array of objects containing
		///  the versionTitle of each available version.
		/// </summary>
		[JsonProperty("heVersions")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> HebrewVersions { get; set; }

		/// <summary>
		/// The URL or book citation of the source of the Hebrew text.
		/// </summary>
		[JsonProperty("heVersionSource")]
		public String HebrewVersionSource { get; set; }

		/// <summary>
		/// The name of the version of the Hebrew text.
		/// </summary>
		[JsonProperty("heVersionTitle")]
		public String HebrewVersionTitle { get; set; }

		/// <summary>
		/// The length of the text in its highest level section, in this 
		/// case Kohelet has 12 chapters.
		/// </summary>
		[JsonProperty("length")]
		public int Length { get; set; }

		// todo
		///// <summary>
		///// An array of maps between strings and deeper sections of the 
		///// text (currently called "Shorthands" in the Sefaria interface).
		/////  Used to give names to segments of text. E.g, "Rambam Laws of
		/////  Human Dispositions" maps to "Mishneh Torah 1:2".
		///// </summary>
		//[JsonProperty("maps")]
		//public int Maps { get; set; }

		/// <summary>
		/// A ref of the next section of text, if any.
		/// </summary>
		[JsonProperty("next")]
		public String Next { get; set; }

		/// <summary>
		/// An array specifying the order of this text with regards to its
		///  categories. In this case, Kohelet is the 33rd book of the
		///  Tanach, and the 7th book of Writings.
		/// </summary>
		[JsonProperty("order")]
		[JsonConverter(typeof(SingleOrArrayConverter<int>))]
		public List<int> Order { get; set; }

		/// <summary>
		/// A ref of the previous section of this text, if any.
		/// </summary>
		[JsonProperty("prev")]
		public String Prev { get; set; }

		/// <summary>
		/// A normalized version of the requested reference.
		/// </summary>
		[JsonProperty("ref")]
		public string Ref { get; set; }

		/// <summary>
		/// An array containing the type names of the sections of this
		/// text. The length of sectionNames gives the depth of the 
		/// structure of this text. For example, Kohelet (["Chapter",
		/// "Verse"]) has depth 2, while Mishneh Torah (["Book", "Topic",
		/// "Section", "Law"]) has depth 4. Comparing this depth to the
		/// depth of sections will show if the request was for the lowest
		/// level, or a higher level, of the text.
		/// </summary>
		[JsonProperty("sectionNames")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> SectionNames { get; set; }

		/// <summary>
		/// An array of ints which corresponds to sectionNames and
		/// represents the sections of the text requested. When
		/// sectionNames is ['Chatper', 'Verse'] a request for chapter 4
		/// looks like [4] while a request for chapter 4, verse 7 would
		/// look like [4, 7]. Note, for Talmud, Dafs are represented by a
		/// string like '42a' or '12b'.
		/// </summary>
		[JsonProperty("sections")]
		[JsonConverter(typeof(SingleOrArrayConverter<int>))]
		public List<int> Sections { get; set; }

		/// <summary>
		/// The English text requested, as an array of strings. If only a 
		/// single segment is requested (e.g. "Kohelet 5.3"), the 
		/// surrounding text is still returned by default. If you only need
		/// the segment you requested, you can add the parameter ?context=0
		/// in which case this field will be a string. If no English text
		/// exists for this ref, the value will be [].
		/// </summary>
		[JsonProperty("text")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> TextList { get; set; }

		/// <summary>
		/// An array of alternate titles for this text, including titles
		/// in other language, spelling variants and abbreviations.
		/// </summary>
		[JsonProperty("titleVariants")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> TitleVariants { get; set; }

		/// <summary>
		/// An array parallel to sections which specifies the end range of 
		/// the requested text For "Kohelet 3:1-4", this would be [3, 4] 
		/// for chapter, 3, verse 4.
		/// </summary>
		[JsonProperty("toSections")]
		[JsonConverter(typeof(SingleOrArrayConverter<int>))]
		public List<int> ToSectionsList { get; set; }

		/// <summary>
		/// A convenience for categories[0], the highest level category of 
		/// the text.
		/// </summary>
		[JsonProperty("type")]
		public String Type { get; set; }

		/// <summary>
		/// The URL or book citation of the source of the English text.
		/// </summary>
		[JsonProperty("versionSource")]
		public String VersionSource { get; set; }

		/// <summary>
		/// The title of the version of the text that was returned in text.
		/// </summary>
		[JsonProperty("versionTitle")]
		public String VersionTitle { get; set; }

		/// <summary>
		/// Only present if multiple English versions of this text are 
		/// available, this field contains an array of objects containing 
		/// the versionTitle of each available version.
		/// </summary>
		[JsonProperty("versions")]
		[JsonConverter(typeof(SingleOrArrayConverter<Version>))]
		public List<Version> Versions { get; set; }

		[JsonProperty("heTitleVariants")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<String> HebrewTitleVariantList { get; set; }

		[JsonProperty("heTitle")]
		public String HebrewTitle { get; set; }

		[JsonProperty("heRef")]
		public String HebrewReference { get; set; }

		[JsonProperty("sectionRef")]
		public String SectionReference { get; set; }
	}
}
