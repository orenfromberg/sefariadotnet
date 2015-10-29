#region Copyright (C) 2014 Sascha Simon

//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/.
//
//  Visit the official homepage at http://www.sascha-simon.com

#endregion

#region Copyright (C) 2015 Oren Fromberg

//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/.

#endregion

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.sefaria.api.Http
{
	/// <summary>
	/// Class to create web requests and receive a response from the server.
	/// </summary>
	public static class WebRequest
	{
		/// <summary>
		/// The Response Code that was received on the last request.
		/// </summary>
		public static HttpStatusCode LastResponseCode { get; set; }

		/// <summary>
		/// AsyncResponseReceived is raised when an asynchronous response is received from the server.
		/// </summary>
		public static event EventHandler<AsyncResponseReceivedEventArgs> AsyncResponseReceived;

		/// <summary>
		/// ResponseReceived is raised when a response is received from the server.
		/// </summary>
		public static event EventHandler<ResponseReceivedEventArgs> ResponseReceived;

		/// <summary>
		/// Sends a GET request to the server asynchronously.
		/// </summary>
		/// <param name="uri">The Uri where the request will be sent.</param>
		/// <returns>The server's response.</returns>
		public static async Task<String> SendGetAsync(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
			}

			using (var httpClient = new HttpClient())
			{
				using (HttpResponseMessage response = await httpClient.GetAsync(uri))
				{
					if (response != null)
					{
						if (AsyncResponseReceived != null)
						{
							AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
						}

						//Request was successful
						if (response.StatusCode == HttpStatusCode.OK)
						{
							LastResponseCode = response.StatusCode;
							return await response.Content.ReadAsStringAsync();
						}
					}
				}
			}

			return String.Empty;
		}

		/// <summary>
		/// Sends a POST request to the server asynchronously.
		/// </summary>
		/// <param name="uri">The Uri where the request will be sent.</param>
		/// <returns>The server's response.</returns>
		public static async Task<String> SendPostAsync(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
			}

			using (var httpClient = new HttpClient())
			{
				using (HttpResponseMessage response = await httpClient.PostAsync(uri, null))
				{
					if (response != null)
					{
						if (AsyncResponseReceived != null)
						{
							AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
						}

						LastResponseCode = response.StatusCode;
						return await response.Content.ReadAsStringAsync();
					}
				}
			}

			return String.Empty;
		}

		/// <summary>
		/// Sends a PUT request to the server asynchronously.
		/// </summary>
		/// <param name="uri">The Uri where the request will be sent.</param>
		/// <returns>The server's response.</returns>
		public static async Task<String> SendPutAsync(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
			}

			using (var httpClient = new HttpClient())
			{
				using (HttpResponseMessage response = await httpClient.PutAsync(uri, null))
				{
					if (response != null)
					{
						if (AsyncResponseReceived != null)
						{
							AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
						}

						LastResponseCode = response.StatusCode;
						return await response.Content.ReadAsStringAsync();
					}
				}
			}

			return String.Empty;
		}

		/// <summary>
		/// Sends a DELETE request to the server asynchronously.
		/// </summary>
		/// <param name="uri">The Uri where the request will be sent.</param>
		/// <returns>The server's response.</returns>
		public static async Task<String> SendDeleteAsync(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
			}

			using (var httpClient = new HttpClient())
			{
				using (HttpResponseMessage response = await httpClient.DeleteAsync(uri))
				{
					if (response != null)
					{
						if (AsyncResponseReceived != null)
						{
							AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
						}

						LastResponseCode = response.StatusCode;
						return await response.Content.ReadAsStringAsync();
					}
				}
			}

			return String.Empty;
		}

		/// <summary>
		/// Sends a GET request to the server.
		/// </summary>
		/// <param name="uri">The Uri where the request will be sent.</param>
		/// <returns>The server's response.</returns>
		public static String SendGet(Uri uri)
		{
			var httpRequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
			httpRequest.Method = "GET";

			using (var httpResponse = (HttpWebResponse)httpRequest.GetResponse())
			{
				Stream responseStream = httpResponse.GetResponseStream();

				if (responseStream == null) 
					return String.Empty;

				if (ResponseReceived != null)
				{
					ResponseReceived(null, new ResponseReceivedEventArgs(httpResponse));
				}

				var reader = new StreamReader(responseStream);
				String response = reader.ReadToEnd();

				// Close both streams.
				reader.Close();
				responseStream.Close();

				return response;
			}
		}

		/// <summary>
		/// Sends a PUT request to the server.
		/// </summary>
		/// <param name="uri">The Uri where the request will be sent.</param>
		/// <returns>The server's response.</returns>
		public static String SendPut(Uri uri)
		{
			var httpRequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
			httpRequest.Method = "PUT";

			using (var httpResponse = (HttpWebResponse)httpRequest.GetResponse())
			{
				Stream responseStream = httpResponse.GetResponseStream();

				if (responseStream == null)
					return String.Empty;

				if (ResponseReceived != null)
				{
					ResponseReceived(null, new ResponseReceivedEventArgs(httpResponse));
				}

				var reader = new StreamReader(responseStream);
				String response = reader.ReadToEnd();

				// Close both streams.
				reader.Close();
				responseStream.Close();

				return response;
			}
		}
	}
}
