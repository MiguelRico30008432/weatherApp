using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace WpfApp1
{
	public class baseAPI
	{
		private HttpClient client = new HttpClient();
		private HttpRequestMessage? request;
		private string token = "e3e622aea3mshc0d22589918910fp1f84c2jsn24f15ee2adff";	


		public string sendRequest(string url, string method, string host, Dictionary<string,string> contents) 
		{
			request = new HttpRequestMessage();
			request.RequestUri = new Uri(url);
			request.Headers.Add("X-RapidAPI-Key", token);
			request.Headers.Add("X-RapidAPI-Host", host);

			if (method.ToLower() == "get") { getRquest(); }
			else if (method.ToLower() == "post") { postRquest(contents); }

			return getResultSet(request);
		}

		private void getRquest() 
		{
			request.Method = HttpMethod.Get;
		}


		private void postRquest(Dictionary<string, string> contents) 
		{
			request.Method = HttpMethod.Post;
			request.Content = new FormUrlEncodedContent(contents);
		}


		private string getResultSet(HttpRequestMessage request)
		{
			var response = client.SendAsync(request).Result;
			return response.Content.ReadAsStringAsync().Result;
		}
	}
}
