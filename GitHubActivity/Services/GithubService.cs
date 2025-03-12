using System.Net.Http.Headers;
using GitHubActivity.Models;
using Newtonsoft.Json;

namespace GitHubActivity.Services;

public static class GithubService
{
    private static readonly HttpClient client = new HttpClient();

    static GithubService()
    {
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("GithubActivity", "1.0"));
    }

    public static async Task<List<GithubResult>> GetGithubInfo(string userName)
    {
        var url = $"https://api.github.com/users/{userName}/events";
        try
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<GithubResult>>(content);
            return events ?? new List<GithubResult>();
        }
        catch (HttpRequestException e)
        {
            throw new Exception($"Error fetching data from GitHub: {e.Message}");
        }
    }
}