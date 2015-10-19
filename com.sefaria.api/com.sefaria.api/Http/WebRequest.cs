using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
							////Getting the Strava API usage data.
							//KeyValuePair<String, IEnumerable<String>> usage = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Usage"));

							//if (usage.Value != null)
							//{
							//	//Setting the related Properties in the Limits-class.
							//	Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
							//		Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
							//}

							////Getting the Strava API limits
							//KeyValuePair<String, IEnumerable<String>> limit = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit"));

							//if (limit.Value != null)
							//{
							//	//Setting the related Properties in the Limits-class.
							//	Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
							//		Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
							//}

							//LastResponseCode = response.StatusCode;
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

			using (HttpClient httpClient = new HttpClient())
			{
				using (HttpResponseMessage response = await httpClient.PostAsync(uri, null))
				{
					if (response != null)
					{
						if (AsyncResponseReceived != null)
						{
							AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
						}

						////Getting the Strava API usage data.
						//KeyValuePair<String, IEnumerable<String>> usage =
						//	response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Usage"));

						//if (usage.Value != null)
						//{
						//	//Setting the related Properties in the Limits-class.
						//	Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
						//		Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
						//}

						////Getting the Strava API limits
						//KeyValuePair<String, IEnumerable<String>> limit =
						//	response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit"));

						//if (limit.Value != null)
						//{
						//	//Setting the related Properties in the Limits-class.
						//	Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
						//		Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
						//}

						////Request was successful
						//LastResponseCode = response.StatusCode;
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

						////Getting the Strava API usage data.
						//KeyValuePair<String, IEnumerable<String>> usage = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Usage"));

						//if (usage.Value != null)
						//{
						//	//Setting the related Properties in the Limits-class.
						//	Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
						//		Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
						//}

						////Getting the Strava API limits
						//KeyValuePair<String, IEnumerable<String>> limit = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit"));

						//if (limit.Value != null)
						//{
						//	//Setting the related Properties in the Limits-class.
						//	Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
						//		Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
						//}

						//LastResponseCode = response.StatusCode;
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

			using (HttpClient httpClient = new HttpClient())
			{
				using (HttpResponseMessage response = await httpClient.DeleteAsync(uri))
				{

					if (response != null)
					{
						if (AsyncResponseReceived != null)
						{
							AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
						}

						////Getting the Strava API usage data.
						//KeyValuePair<String, IEnumerable<String>> usage = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Usage"));

						//if (usage.Value != null)
						//{
						//	//Setting the related Properties in the Limits-class.
						//	Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
						//		Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
						//}

						////Getting the Strava API limits
						//KeyValuePair<String, IEnumerable<String>> limit = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit"));

						//if (limit.Value != null)
						//{
						//	//Setting the related Properties in the Limits-class.
						//	Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
						//		Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
						//}

						//LastResponseCode = response.StatusCode;
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
			HttpWebRequest httpRequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
			httpRequest.Method = "GET";

			using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
			{
				Stream responseStream = httpResponse.GetResponseStream();

				if (responseStream != null)
				{
					if (ResponseReceived != null)
					{
						ResponseReceived(null, new ResponseReceivedEventArgs(httpResponse));
					}

					////Getting the Strava API usage data.
					//String usage = httpResponse.GetResponseHeader("X-RateLimit-Usage");

					////Getting the Strava API limits
					//String limit = httpResponse.GetResponseHeader("X-RateLimit-Limit");

					//if (!String.IsNullOrEmpty(usage))
					//{
					//	//Setting the related Properties in the Limits-class.
					//	Limits.Usage = new Usage(Int32.Parse(usage.Split(',')[0]), Int32.Parse(usage.Split(',')[1]));
					//}

					//if (!String.IsNullOrEmpty(limit))
					//{
					//	//Setting the related Properties in the Limits-class.
					//	Limits.Limit = new Limit(Int32.Parse(limit.Split(',')[0]), Int32.Parse(limit.Split(',')[1]));
					//}

					StreamReader reader = new StreamReader(responseStream);
					String response = reader.ReadToEnd();

					// Close both streams.
					reader.Close();
					responseStream.Close();

					return response;
				}
			}

			return String.Empty;
		}

		/// <summary>
		/// Sends a PUT request to the server.
		/// </summary>
		/// <param name="uri">The Uri where the request will be sent.</param>
		/// <returns>The server's response.</returns>
		public static String SendPut(Uri uri)
		{
			HttpWebRequest httpRequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
			httpRequest.Method = "PUT";

			using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
			{
				Stream responseStream = httpResponse.GetResponseStream();

				if (responseStream != null)
				{
					if (ResponseReceived != null)
					{
						ResponseReceived(null, new ResponseReceivedEventArgs(httpResponse));
					}

					////Getting the Strava API usage data.
					//String usage = httpResponse.GetResponseHeader("X-RateLimit-Usage");

					////Getting the Strava API limits
					//String limit = httpResponse.GetResponseHeader("X-RateLimit-Limit");

					//if (!String.IsNullOrEmpty(usage))
					//{
					//	//Setting the related Properties in the Limits-class.
					//	Limits.Usage = new Usage(Int32.Parse(usage.Split(',')[0]), Int32.Parse(usage.Split(',')[1]));
					//}

					//if (!String.IsNullOrEmpty(limit))
					//{
					//	//Setting the related Properties in the Limits-class.
					//	Limits.Limit = new Limit(Int32.Parse(limit.Split(',')[0]), Int32.Parse(limit.Split(',')[1]));
					//}

					StreamReader reader = new StreamReader(responseStream);
					String response = reader.ReadToEnd();

					// Close both streams.
					reader.Close();
					responseStream.Close();

					return response;
				}
			}

			return String.Empty;
		}

	}
}
