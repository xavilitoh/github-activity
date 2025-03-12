using System.Net.Http.Headers;
using GitHubActivity.Models;
using Newtonsoft.Json;

namespace GitHubActivity.Services
{
    /// <summary>
    /// Service to interact with the GitHub API.
    /// </summary>
    public static class GithubService
    {
        // Static instance of HttpClient for reuse.
        private static readonly HttpClient client = new HttpClient();

        // Static constructor to configure default headers.
        static GithubService()
        {
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("GithubActivity", "1.0"));
        }

        /// <summary>
        /// Gets event information for a GitHub user.
        /// </summary>
        /// <param name="userName">GitHub username.</param>
        /// <returns>A list of GithubResult objects with event information.</returns>
        /// <exception cref="Exception">Thrown when there is an error fetching data from GitHub.</exception>
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
}