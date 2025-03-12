// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using GitHubActivity.Models;
using GitHubActivity.Services;
using Spectre.Console;
using Spectre.Console.Json;

if(args.Length == 0)
{
    Console.WriteLine("Please provide a name as an argument.");
    return;
}

List<GithubResult> data = new List<GithubResult>();
// Synchronous
// Asynchronous
await AnsiConsole.Status()
    .StartAsync($"Buscando informacion de {args[0]}...", async ctx => 
    {
        data = await GithubService.GetGithubInfo(args[0]);
    });

foreach (var @event in data)
{
    AnsiConsole.Write(new Markup($"[green]{@event.CreatedAt.ToLocalTime()}[/]: "));
    switch (@event.Type)
    {
        case "PushEvent":
            AnsiConsole.Write(new Markup($"Pushed [bold yellow]{@event.Payload.Commits?.Count ?? 0}[/] commits to [bold yellow]{@event.Repo?.Name}[/].\n"));
            break;
        case "CreateEvent":
            AnsiConsole.Write(new Markup($"Created a new [bold yellow]{@event.Payload.RefType}[/] in [bold yellow]{@event.Repo?.Name}[/].\n"));
            break;
        case "DeleteEvent":
            Console.WriteLine($"Deleted {@event.Repo?.Name}.");
            break;
        case "ForkEvent":
            AnsiConsole.Write(new Markup($"Forked [bold yellow]{@event.Repo?.Name}[/].\n"));
            break;
        case "WatchEvent":
            AnsiConsole.Write(new Markup($"{@event.Payload.Action} watching [bold yellow]{@event.Repo?.Name}[/].\n"));
            break;
        case "PullRequestEvent":
            AnsiConsole.Write(new Markup($"{@event.Payload.Action} a pull request in [bold yellow]{@event.Repo?.Name}[/].\n"));
            break;
        case "IssueCommentEvent":
            AnsiConsole.Write(new Markup($"{@event.Payload.Action} a issue comment in [bold yellow]{@event.Repo?.Name}[/].\n"));
        break;
        default:
            Console.WriteLine($"Unknown event type: {@event.Type}");
            break;
    }
    
}