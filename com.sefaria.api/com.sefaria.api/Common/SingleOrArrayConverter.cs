using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.sefaria.api.Common
{
	/// <summary>
	/// taken from:
	/// http://stackoverflow.com/questions/18994685/how-to-handle-both-a-single-item-and-an-array-for-the-same-property-using-json-n/18997172#18997172
	/// </summary>
	/// <typeparam name="T">type of single or array to be converted</typeparam>
	class SingleOrArrayConverter<T> : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(List<T>));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JToken token = JToken.Load(reader);
			if (token.Type == JTokenType.Array)
			{
				return token.ToObject<List<T>>();
			}
			return new List<T> { token.ToObject<T>() };
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}