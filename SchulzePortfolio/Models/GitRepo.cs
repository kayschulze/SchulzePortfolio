using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace SchulzePortfolio.Models
{
	public class GitRepo
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Html_Url { get; set; }

        public static List<GitRepo> GetGitRepos()
		{
			var client = new RestClient();
            client.BaseUrl = new Uri("https://api.github.com/users");

			var request = new RestRequest("kayschulze/starred");
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", "kayschulze");

            var response = new RestResponse();
			Task.Run(async () =>
			{
				response = await GetResponseContentAsync(client, request) as RestResponse;
			}).Wait();

			JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
			var gitRepoList = JsonConvert.DeserializeObject<List<GitRepo>>(jsonResponse.ToString());
			return gitRepoList;
		}

		public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
		{
			var tcs = new TaskCompletionSource<IRestResponse>();
			theClient.ExecuteAsync(theRequest, response => {
				tcs.SetResult(response);
			});
			return tcs.Task;
		}
	}
}