using System;
using System.Diagnostics;
using com.sefaria.api.Clients;
using Sefaria = com.sefaria.api;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new TextClient();

			while(true)
			{
				Console.Write("> ");
				string input = Console.ReadLine();
				if (input != null && input.Equals("quit"))
					break;

				try
				{
					var text = client.GetText(input);
					for (int i = 0; i < text.TextList.Count; i++)
					{
						Console.WriteLine(text.TextList[i]);
						Debug.WriteLine(text.HebrewTextList[i]);
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
