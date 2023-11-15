#pragma warning disable 8618

using System.Text.Json.Serialization;

namespace SteamLadderClient.Models {
    /// <summary>
    /// Represents a Steam user's basic information.
    /// </summary>
    public class SteamUser
    {
        /// <summary>
        /// The user's Steam name.
        /// </summary>
        [JsonPropertyName("steam_name")]
        public string SteamName { get; set; }

        /// <summary>
        /// The user's unique Steam ID.
        /// </summary>
        [JsonPropertyName("steam_id")]
        public string SteamId { get; set; }

        /// <summary>
        /// URL to the user's SteamLadder profile.
        /// </summary>
        [JsonPropertyName("steamladder_url")]
        public string SteamladderUrl { get; set; }

        /// <summary>
        /// The date the user joined Steam.
        /// </summary>
        [JsonPropertyName("steam_join_date")]
        public DateTime SteamJoinDate { get; set; }

        /// <summary>
        /// The country code of the user, based on ISO 3166-1 alpha-2.
        /// </summary>
        [JsonPropertyName("steam_country_code")]
        public string SteamCountryCode { get; set; }

        /// <summary>
        /// URL to the user's Steam avatar.
        /// </summary>
        [JsonPropertyName("steam_avatar_src")]
        public string SteamAvatarSrc { get; set; }

        /// <summary>
        /// Indicates whether the user's Steam profile is private.
        /// </summary>
        [JsonPropertyName("is_steam_private")]
        public bool IsSteamPrivate { get; set; }
    }

    /// <summary>
    /// Represents a single badge in a Steam user's profile.
    /// </summary>
    public class Badge
    {
        /// <summary>
        /// The position of the badge in the user's badge list.
        /// </summary>
        [JsonPropertyName("pos")]
        public int Pos { get; set; }

        /// <summary>
        /// The name of the badge.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether the badge is a foil badge.
        /// </summary>
        [JsonPropertyName("foil")]
        public bool Foil { get; set; }

        /// <summary>
        /// The level of the badge.
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// The experience points associated with the badge.
        /// </summary>
        [JsonPropertyName("xp")]
        public int Xp { get; set; }
    }

    /// <summary>
    /// Represents a collection of badges for a Steam user.
    /// </summary>
    public class Badges
    {
        /// <summary>
        /// The total number of badges the user has.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// A list of badges, particularly tracking specific badges of interest.
        /// </summary>
        [JsonPropertyName("tracking")]
        public List<Badge> Tracking { get; set; }
    }

    /// <summary>
    /// Represents additional information about a Steam user's profile on Steam Ladder.
    /// </summary>
    public class SteamLadderInfo
    {
        /// <summary>
        /// Indicates whether the user is a staff member on Steam Ladder.
        /// </summary>
        [JsonPropertyName("is_staff")]
        public bool IsStaff { get; set; }

        /// <summary>
        /// Indicates whether the user participated in the Winter 2018 event on Steam.
        /// </summary>
        [JsonPropertyName("is_winter_18")]
        public bool IsWinter18 { get; set; }

        /// <summary>
        /// Indicates whether the user participated in the Winter 2019 event on Steam.
        /// </summary>
        [JsonPropertyName("is_winter_19")]
        public bool IsWinter19 { get; set; }

        /// <summary>
        /// Indicates whether the user is a donator on Steam Ladder.
        /// </summary>
        [JsonPropertyName("is_donator")]
        public bool IsDonator { get; set; }

        /// <summary>
        /// Indicates whether the user is a top donator on Steam Ladder.
        /// </summary>
        [JsonPropertyName("is_top_donator")]
        public bool IsTopDonator { get; set; }

        /// <summary>
        /// The Patreon tier of the user, if applicable.
        /// </summary>
        [JsonPropertyName("patreon_tier")]
        public string? PatreonTier { get; set; }
    }

    /// <summary>
    /// Represents a single game in a Steam user's game library.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The position of the game in the user's game list.
        /// </summary>
        [JsonPropertyName("pos")]
        public int Pos { get; set; }

        /// <summary>
        /// The unique identifier for the game.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the game.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The total playtime of the game in minutes.
        /// </summary>
        [JsonPropertyName("playtime_min")]
        public int PlaytimeMin { get; set; }
    }

    /// <summary>
    /// Represents the collection of games associated with a Steam user.
    /// </summary>
    public class Games
    {
        /// <summary>
        /// The total number of games owned by the user.
        /// </summary>
        [JsonPropertyName("total_games")]
        public int TotalGames { get; set; }

        /// <summary>
        /// The total playtime across all games in minutes.
        /// </summary>
        [JsonPropertyName("total_playtime_min")]
        public int TotalPlaytimeMin { get; set; }

        /// <summary>
        /// A list of the user's most played games.
        /// </summary>
        [JsonPropertyName("most_played")]
        public List<Game> MostPlayed { get; set; }
    }

    /// <summary>
    /// Represents the ban status of a Steam user.
    /// </summary>
    public class Bans
    {
        /// <summary>
        /// The number of VAC (Valve Anti-Cheat) bans the user has received.
        /// </summary>
        [JsonPropertyName("vac_bans")]
        public int VacBans { get; set; }

        /// <summary>
        /// The number of game-specific bans the user has received.
        /// </summary>
        [JsonPropertyName("game_bans")]
        public int GameBans { get; set; }

        /// <summary>
        /// The date of the user's last ban, if applicable.
        /// </summary>
        [JsonPropertyName("last_ban_day")]
        public DateTime? LastBanDay { get; set; }

        /// <summary>
        /// Indicates whether the user is currently VAC banned.
        /// </summary>
        [JsonPropertyName("is_vac_banned")]
        public bool IsVacBanned { get; set; }

        /// <summary>
        /// Indicates whether the user is currently community banned.
        /// </summary>
        [JsonPropertyName("is_community_banned")]
        public bool IsCommunityBanned { get; set; }

        /// <summary>
        /// The current status of the user's participation in the Steam economy.
        /// </summary>
        [JsonPropertyName("economy_status")]
        public string EconomyStatus { get; set; }
    }

    /// <summary>
    /// Represents the statistics of a Steam user's profile.
    /// </summary>
    public class SteamStats
    {
        /// <summary>
        /// The date and time when the statistics were last updated.
        /// </summary>
        [JsonPropertyName("last_update")]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// The level of the Steam user.
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// The total experience points (XP) of the Steam user.
        /// </summary>
        [JsonPropertyName("xp")]
        public int Xp { get; set; }

        /// <summary>
        /// The number of friends the Steam user has.
        /// </summary>
        [JsonPropertyName("friends")]
        public int Friends { get; set; }

        /// <summary>
        /// The collection of badges owned by the Steam user.
        /// </summary>
        [JsonPropertyName("badges")]
        public Badges Badges { get; set; }

        /// <summary>
        /// The collection of games owned by the Steam user.
        /// </summary>
        [JsonPropertyName("games")]
        public Games Games { get; set; }

        /// <summary>
        /// The ban status of the Steam user.
        /// </summary>
        [JsonPropertyName("bans")]
        public Bans Bans { get; set; }
    }

    /// <summary>
    /// Represents the regional ranking of a Steam user.
    /// </summary>
    public class RegionRank
    {
        /// <summary>
        /// The regional experience points (XP) rank of the Steam user.
        /// </summary>
        [JsonPropertyName("region_xp")]
        public int RegionXp { get; set; }

        /// <summary>
        /// The regional playtime rank of the Steam user.
        /// </summary>
        [JsonPropertyName("region_playtime")]
        public int RegionPlaytime { get; set; }

        /// <summary>
        /// The regional games rank of the Steam user.
        /// </summary>
        [JsonPropertyName("region_games")]
        public int RegionGames { get; set; }
    }

    /// <summary>
    /// Represents the country-specific ranking of a Steam user.
    /// </summary>
    public class CountryRank
    {
        /// <summary>
        /// The country-specific experience points (XP) rank of the Steam user.
        /// </summary>
        [JsonPropertyName("country_xp")]
        public int CountryXp { get; set; }

        /// <summary>
        /// The country-specific playtime rank of the Steam user.
        /// </summary>
        [JsonPropertyName("country_playtime")]
        public int CountryPlaytime { get; set; }

        /// <summary>
        /// The country-specific games rank of the Steam user.
        /// </summary>
        [JsonPropertyName("country_games")]
        public int CountryGames { get; set; }
    }

    /// <summary>
    /// Represents the overall and regional ladder ranking of a Steam user.
    /// </summary>
    public class LadderRank
    {
        /// <summary>
        /// The worldwide experience points (XP) rank of the Steam user.
        /// </summary>
        [JsonPropertyName("worldwide_xp")]
        public int WorldwideXp { get; set; }

        /// <summary>
        /// The worldwide games rank of the Steam user.
        /// </summary>
        [JsonPropertyName("worldwide_games")]
        public int WorldwideGames { get; set; }

        /// <summary>
        /// The worldwide playtime rank of the Steam user.
        /// </summary>
        [JsonPropertyName("worldwide_playtime")]
        public int WorldwidePlaytime { get; set; }

        /// <summary>
        /// The regional rank details of the Steam user.
        /// </summary>
        [JsonPropertyName("region")]
        public RegionRank Region { get; set; }

        /// <summary>
        /// The country rank details of the Steam user.
        /// </summary>
        [JsonPropertyName("country")]
        public CountryRank Country { get; set; }
    }

    /// <summary>
    /// Represents a Steam user's complete profile, including user information, ladder information, and statistics.
    /// </summary>
    public class SteamProfile
    {
        /// <summary>
        /// The basic information of the Steam user.
        /// </summary>
        [JsonPropertyName("steam_user")]
        public SteamUser SteamUser { get; set; }

        /// <summary>
        /// Additional information about the user's profile on Steam Ladder.
        /// </summary>
        [JsonPropertyName("steam_ladder_info")]
        public SteamLadderInfo SteamLadderInfo { get; set; }

        /// <summary>
        /// The statistics of the Steam user's profile.
        /// </summary>
        [JsonPropertyName("steam_stats")]
        public SteamStats SteamStats { get; set; }

        /// <summary>
        /// The ladder rankings of the Steam user.
        /// </summary>
        [JsonPropertyName("ladder_rank")]
        public LadderRank LadderRank { get; set; }
    }

    /// <summary>
    /// Represents an entry in the Steam ladder, including user and stats information.
    /// </summary>
    public class LadderEntryModel
    {
        [JsonPropertyName("pos")]
        public int Position { get; set; }

        [JsonPropertyName("steam_user")]
        public SteamUser SteamUser { get; set; }

        [JsonPropertyName("steam_stats")]
        public SteamStats SteamStats { get; set; }
    }

    /// <summary>
    /// Represents the response for the Steam ladder, including a list of ladder entries.
    /// </summary>
    public class SteamLadder
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("type_url")]
        public string TypeUrl { get; set; }

        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("ladder")]
        public List<LadderEntryModel> Ladder { get; set; }
    }
}