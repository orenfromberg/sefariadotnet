using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.sefaria.api.Common;
using Text = com.sefaria.api.Texts.Text;
using Endpoints = com.sefaria.api.Api.Endpoints;
namespace com.sefaria.api.Clients
{
	public class TextClient
	{
		public Text GetText(string id)
		{
			String getUrl = String.Format("{0}/{1}", Endpoints.Text, id);
			String json = Http.WebRequest.SendGet(new Uri(getUrl));
			return Unmarshaller<Text>.Unmarshal(json);
		}
	}
}
