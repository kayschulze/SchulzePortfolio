﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace SchulzePortfolio.Models
{
	public class GitRepo
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }

		public static List<GitRepo> GetGitRepos()
		{
			var client = new RestClient();
			client.BaseUrl = new Uri("http://api.github.com");

			var request = new RestRequest("users/kayschulze/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("UserAgent", "kayschulze");

			var response = new RestResponse();
			Task.Run(async () =>
			{
				response = await GetResponseContentAsync(client, request) as RestResponse;
			}).Wait();

			JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
			var gitRepoList = JsonConvert.DeserializeObject<List<GitRepo>>(jsonResponse["repos"].ToString());
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