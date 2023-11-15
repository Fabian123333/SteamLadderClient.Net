using System.Text.Json;
using SteamLadderClient.Models;

namespace SteamLadderClient
{
    /// <summary>
    /// Represents types of ladders available in the Steam Ladder API.
    /// </summary>
    public enum LadderType
    {
        /// <summary>
        /// Ladder type for experience points.
        /// </summary>
        Xp,

        /// <summary>
        /// Ladder type for games.
        /// </summary>
        Games,

        /// <summary>
        /// Ladder type for playtime.
        /// </summary>
        Playtime,

        /// <summary>
        /// Ladder type for badges.
        /// </summary>
        Badges,

        /// <summary>
        /// Ladder type for Steam age.
        /// </summary>
        SteamAge,

        /// <summary>
        /// Ladder type for VAC (Valve Anti-Cheat) bans.
        /// </summary>
        Vac,

        /// <summary>
        /// Ladder type for game bans.
        /// </summary>
        GameBan
    }

    /// <summary>
    /// Represents geographical regions.
    /// </summary>
    public enum Region
    {
        /// <summary>
        /// Europe region.
        /// </summary>
        Europe,

        /// <summary>
        /// North America region.
        /// </summary>
        NorthAmerica,

        /// <summary>
        /// South America region.
        /// </summary>
        SouthAmerica,

        /// <summary>
        /// Asia region.
        /// </summary>
        Asia,

        /// <summary>
        /// Africa region.
        /// </summary>
        Africa,

        /// <summary>
        /// Oceania region.
        /// </summary>
        Oceania,

        /// <summary>
        /// Antarctica region.
        /// </summary>
        Antarctica
    }

    /// <summary>
    /// Client for interacting with the Steam Ladder API.
    /// </summary>
    public class Client
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="apiKey">The API key used for authentication with the Steam Ladder API.</param>
        /// <param name="baseUrl">The base URL of the Steam Ladder API. Default is "https://steamladder.com/api/v1/"</param>
        /// <param name="httpClient">Optional HTTP client for making requests. If not provided, a new instance is created.</param>
        public Client(string apiKey, string baseUrl = "https://steamladder.com/api/v1/", HttpClient? httpClient = null)
        {
            _apiKey = apiKey;
            _baseUrl = baseUrl;
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {apiKey}");
        }

        /// <summary>
        /// Performs an asynchronous GET request to the specified endpoint of the Steam Ladder API.
        /// </summary>
        /// <param name="type">The type of the request, specifying the API endpoint.</param>
        /// <param name="parameter">The parameter to append to the API endpoint, typically an identifier or a query.</param>
        /// <returns>
        /// A task that represents the asynchronous operation and returns the response content as a string.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the HTTP request does not succeed. Possible reasons include:
        /// - 429: Rate limitiert
        /// - 401: Unauthenticated
        /// - 404: Not found
        /// </exception>
        /// <remarks>
        /// This method constructs the full URL using the base URL, type, and parameter, sends the GET request, 
        /// and returns the response content. It ensures that the HTTP response status code is successful, 
        /// otherwise it throws an exception.
        /// </remarks>
        private async Task<string> GetAsync(string type, string parameter)
        {
            Console.WriteLine($"{_baseUrl}{type}/{parameter}/");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}{type}/{parameter}/");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Performs an asynchronous POST request to the specified endpoint of the Steam Ladder API.
        /// </summary>
        /// <param name="type">The type of the request, specifying the API endpoint.</param>
        /// <param name="parameter">The parameter to append to the API endpoint, typically an identifier or a query.</param>
        /// <returns>
        /// A task that represents the asynchronous operation and returns the response content as a string.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the HTTP request does not succeed. Possible reasons include:
        /// - 429: Rate limitiert
        /// - 401: Unauthenticated
        /// - 404: Not found
        /// </exception>
        /// <remarks>
        /// This method constructs the full URL using the base URL, type, and parameter, sends the POST request, 
        /// and returns the response content. It ensures that the HTTP response status code is successful, 
        /// otherwise it throws an exception.
        /// </remarks>
        private async Task<string> PostAsync(string type, string parameter)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}{type}/{parameter}");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Retrieves the Steam profile information for a given Steam ID (64-bit) asynchronously.
        /// </summary>
        /// <param name="steamId64">The 64-bit Steam ID of the user whose profile information is to be retrieved.</param>
        /// <returns>
        /// A task that represents the asynchronous operation and returns the profile information
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the HTTP request does not succeed. Possible reasons include:
        /// - 429: Rate limit
        /// - 401: Unauthenticated
        /// - 404: Not found
        /// </exception>
        /// <remarks>
        /// This method uses the GetAsync method to send a GET request to the 'profile' endpoint of the Steam Ladder API 
        /// with the provided Steam ID as the parameter.
        /// </remarks>
        public async Task<SteamProfile> GetProfileAsync(ulong steamId64)
        {
            string response = await GetAsync("profile", steamId64.ToString());
            return JsonSerializer.Deserialize<SteamProfile>(response) ?? throw new Exception("Failed to deserialize response.");
        }

        /// <summary>
        /// Updates the Steam profile information for a given Steam ID (64-bit) asynchronously.
        /// </summary>
        /// <param name="steamId64">The 64-bit Steam ID of the user whose profile information is to be updated.</param>
        /// <returns>
        /// A task that represents the asynchronous operation and returns the response content after updating the profile.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the HTTP request does not succeed. Possible reasons include:
        /// - 429: Rate limitiert
        /// - 401: Unauthenticated
        /// - 404: Not found
        /// </exception>
        /// <remarks>
        /// This method uses the PostAsync method to send a POST request to the 'profile' endpoint of the Steam Ladder API 
        /// with the provided Steam ID as the parameter. This is typically used to trigger an update of the user's profile data.
        /// </remarks>
        public async Task<SteamProfile> UpdateProfileAsync(ulong steamId64)
        {
            string response = await PostAsync("profile", steamId64.ToString());
            return JsonSerializer.Deserialize<SteamProfile>(response) ?? throw new Exception("Failed to deserialize response.");
        }

        /// <summary>
        /// Retrieves the ladder information from the Steam Ladder API for a specified ladder type and region asynchronously.
        /// </summary>
        /// <param name="type">The type of the ladder to retrieve. See <see cref="LadderType"/> for possible values.</param>
        /// <param name="region">The region for which to retrieve the ladder information. Default is <see cref="Region.Europe"/>.</param>
        /// <returns>
        /// A task that represents the asynchronous operation and returns the ladder information as a string.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the HTTP request does not succeed. Possible reasons include:
        /// - 429: Rate limitiert
        /// - 401: Unauthenticated
        /// - 404: Not found
        /// </exception>
        /// <remarks>
        /// This method constructs the endpoint using the specified ladder type and region, then uses the GetAsync method 
        /// to send a GET request to the Steam Ladder API. If no region is specified, it defaults to Europe.
        /// </remarks>
        public async Task<SteamLadder> GetLadderAsync(LadderType type, Region region = Region.Europe)
        {
            string typeStr = type.ToString().ToLower();
            string regionStr = region.ToString().ToLower();
            
            string response = await GetAsync("ladder", $"{typeStr}/{regionStr}");
            return JsonSerializer.Deserialize<SteamLadder>(response) ?? throw new Exception("Failed to deserialize response.");
        }

        /// <summary>
        /// Retrieves the ladder information from the Steam Ladder API for a specified ladder type and country asynchronously.
        /// </summary>
        /// <param name="type">The type of the ladder to retrieve. See <see cref="LadderType"/> for possible values.</param>
        /// <param name="country">The alpha-2 country code for which to retrieve the ladder information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation and returns the ladder information as a string.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the HTTP request does not succeed. Possible reasons include:
        /// - 429: Rate limitiert
        /// - 401: Unauthenticated
        /// - 404: Not found
        /// </exception>
        /// <remarks>
        /// This method constructs the endpoint using the specified ladder type and country code, then uses the GetAsync method 
        /// to send a GET request to the Steam Ladder API.
        /// </remarks>
        public async Task<SteamLadder> GetLadderAsync(LadderType type, string country)
        {
            string typeStr = type.ToString().ToLower();
            
            string response = await GetAsync("ladder", $"{typeStr}/{country}");
            return JsonSerializer.Deserialize<SteamLadder>(response) ?? throw new Exception("Failed to deserialize response.");
        }
    }
}