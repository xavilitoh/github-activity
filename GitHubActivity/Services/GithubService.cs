using System.Net.Http.Headers;
using GitHubActivity.Models;
using Newtonsoft.Json;
using Spectre.Console;

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
                switch (e.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        // Handle 404 Not Found
                        AnsiConsole.Write(new Markup($"[red]ERROR: User {userName} not found.[/].\n"));
                        break;
                    case System.Net.HttpStatusCode.Forbidden:
                        // Handle 403 Forbidden
                        AnsiConsole.Write(new Markup($"[red]ERROR: Access to the GitHub API is forbidden. Please check your credentials or rate limits.[/].\n"));
                        break;
                    default:
                        // Handle other HTTP request exceptions
                        AnsiConsole.Write(new Markup($"[red]ERROR: {e.Message}[/].\n"));
                        break;
                }

                return new List<GithubResult>();
            }
        }
    }
}