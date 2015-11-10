#define NO_AUTH

using System;
using System.Diagnostics;
using com.sefaria.api.Clients;
using Sefaria = com.sefaria.api;

namespace ConsoleApplication1
{
	/// <summary>
	/// test program. once there is a nuget package, i'll remove this from the repo.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
#if NO_AUTH
			// not using SefariaClient
#else
			var client = new SefariaClient();
			Console.WriteLine(client.ToString());
#endif

			while (true)
			{
				Console.Write("> ");
				string input = Console.ReadLine();
				if (input != null)
				{
					if (input.Equals("quit"))
						break;

					if (input.Equals("titles"))
					{
#if NO_AUTH
						var index = IndexClient.GetTitles();
#else
						var index = client.Index.GetTitles();
#endif
						foreach (var title in index.Books)
						{
							Console.WriteLine(title);
						}
						continue;
					}

					if (input.Equals("contents"))
					{
#if NO_AUTH
						var indices = IndexClient.GetContents();
#else
						var indices = client.Index.GetContents();
#endif
						//todo print out index
						Console.WriteLine(indices.ToString());
						continue;
					}

					// todo output specific indices (e.g. genesis)
				}

				try
				{
#if NO_AUTH
					var text = TextClient.GetText(input, false, false);
					var links = LinksClient.GetLinks(input);
#else
					var text = client.Texts.GetText(input);
					var links = client.Links.GetLinks(input);
#endif
					if (text.Error != null)
					{
						Console.WriteLine(text.Error);
					}
					else
					{
						// texts
						for (int i = 0; i < text.TextList.Count; i++)
						{
							Console.WriteLine(text.TextList[i]);
							Debug.WriteLine(text.HebrewTextList[i]);
						}	
					
						// links
						foreach (var link in links)
						{
							Console.WriteLine(link.Ref);
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}
	}
}
