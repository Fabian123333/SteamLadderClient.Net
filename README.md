# SteamLadderClient.Net

SteamLadderClient.Net is a .NET library for interacting with the Steam Ladder API. It allows developers to retrieve Steam user data and work with various leaderboards.

## Table of Contents

1. Features
2. Installation
3. Usage
4. Examples
5. License
6. Contributing
7. Support

## Features

Retrieve Steam profile information.
Interact with various types of leaderboards.
Support for regional and country-specific leaderboards.
Easy and flexible HTTP client integration.

## Installation

Add the library to your .NET project. You can do this either via the NuGet package manager or by directly adding the project as a dependency.

## Usage

Import SteamLadderClient into your project and initialize the client with your API key.

## Initializing the Client
```
var client = new SteamLadderClient.Client("Your_API_Key");
```

## Examples

### Retrieving Profile Information

To retrieve the profile information of a Steam user, use the `GetProfileAsync` method.

```
ulong steamId = 76561198123456789; // Example Steam ID
var profile = await client.GetProfileAsync(steamId);
Console.WriteLine(profile.SteamUser.SteamName);
```

### Retrieving Leaderboard Information

You can also retrieve leaderboard information for specific criteria like XP, playtime, etc.

```
var ladder = await client.GetLadderAsync(SteamLadderClient.LadderType.Xp);
foreach (var entry in ladder.Ladder)
{
    Console.WriteLine($"{entry.Position}: {entry.SteamUser.SteamName}");
}
```

## License
This project is licensed under the GPL3 License. For more details, see https://www.gnu.org/licenses/gpl-3.0.de.html

## Contributing
Any contributions, whether pull requests, bug reports, or suggestions, are warmly welcomed.

## Support
If you have any questions or issues, please create an issue in the GitHub repository.