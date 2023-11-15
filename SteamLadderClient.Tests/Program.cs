using System.Text.Json;
using SteamLadderClient;

string token = "123467890";
ulong steamid = 76512345678901234;

var client = new Client(token);

var profile = await client.GetProfileAsync(steamid);
var ladder_europe = await client.GetLadderAsync(LadderType.Xp, Region.Europe);

Console.WriteLine(profile.SteamUser.SteamName);