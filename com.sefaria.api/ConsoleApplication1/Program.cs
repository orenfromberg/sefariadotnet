using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.sefaria.api.Clients;
using Sefaria = com.sefaria.api;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new TextClient();

			const string name = "Kohelet.5";

			var text = client.GetText(name);

			return;

		}
	}
}
