using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Twitter.Search.App.Models
{
    public partial class TweetSearchResponse
    {
        public Status[] Statuses { get; set; }
        public SearchMetadata SearchMetadata { get; set; }
    }

    public partial class SearchMetadata
    {
        public double CompletedIn { get; set; }
        public double MaxId { get; set; }
        public string MaxIdStr { get; set; }
        public string NextResults { get; set; }
        public string Query { get; set; }
        public string RefreshUrl { get; set; }
        public long Count { get; set; }
        public long SinceId { get; set; }
        public long SinceIdStr { get; set; }
    }

    public partial class Status
    {
        public string CreatedAt { get; set; }
        public double Id { get; set; }
        public string IdStr { get; set; }
        public string Text { get; set; }
        public bool Truncated { get; set; }
        public StatusEntities Entities { get; set; }
        public Metadata Metadata { get; set; }
        public string Source { get; set; }
        public object InReplyToStatusId { get; set; }
        public object InReplyToStatusIdStr { get; set; }
        public object InReplyToUserId { get; set; }
        public object InReplyToUserIdStr { get; set; }
        public object InReplyToScreenName { get; set; }
        public User User { get; set; }
        public object Geo { get; set; }
        public object Coordinates { get; set; }
        public object Place { get; set; }
        public object Contributors { get; set; }
        public RetweetedStatus RetweetedStatus { get; set; }
        public bool IsQuoteStatus { get; set; }
        public long RetweetCount { get; set; }
        public long FavoriteCount { get; set; }
        public bool Favorited { get; set; }
        public bool Retweeted { get; set; }
        public Lang Lang { get; set; }
        public bool? PossiblySensitive { get; set; }
    }

    public partial class StatusEntities
    {
        public object[] Hashtags { get; set; }
        public object[] Symbols { get; set; }
        public UserMention[] UserMentions { get; set; }
        public Url[] Urls { get; set; }
    }

    public partial class Url
    {
        public Uri UrlUrl { get; set; }
        public Uri ExpandedUrl { get; set; }
        public string DisplayUrl { get; set; }
        public long[] Indices { get; set; }
    }

    public partial class UserMention
    {
        public string ScreenName { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public long IdStr { get; set; }
        public long[] Indices { get; set; }
    }

    public partial class Metadata
    {
        public Lang IsoLanguageCode { get; set; }
        public ResultType ResultType { get; set; }
    }

    public partial class RetweetedStatus
    {
        public string CreatedAt { get; set; }
        public double Id { get; set; }
        public string IdStr { get; set; }
        public string Text { get; set; }
        public bool Truncated { get; set; }
        public StatusEntities Entities { get; set; }
        public Metadata Metadata { get; set; }
        public string Source { get; set; }
        public object InReplyToStatusId { get; set; }
        public object InReplyToStatusIdStr { get; set; }
        public object InReplyToUserId { get; set; }
        public object InReplyToUserIdStr { get; set; }
        public object InReplyToScreenName { get; set; }
        public User User { get; set; }
        public object Geo { get; set; }
        public object Coordinates { get; set; }
        public object Place { get; set; }
        public object Contributors { get; set; }
        public bool IsQuoteStatus { get; set; }
        public long RetweetCount { get; set; }
        public long FavoriteCount { get; set; }
        public bool Favorited { get; set; }
        public bool Retweeted { get; set; }
        public bool PossiblySensitive { get; set; }
        public Lang Lang { get; set; }
    }

    public partial class User
    {
        public Id Id { get; set; }
        public string IdStr { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public UserEntities Entities { get; set; }
        public bool Protected { get; set; }
        public long FollowersCount { get; set; }
        public long FriendsCount { get; set; }
        public long ListedCount { get; set; }
        public string CreatedAt { get; set; }
        public long FavouritesCount { get; set; }
        public object UtcOffset { get; set; }
        public object TimeZone { get; set; }
        public bool GeoEnabled { get; set; }
        public bool Verified { get; set; }
        public long StatusesCount { get; set; }
        public object Lang { get; set; }
        public bool ContributorsEnabled { get; set; }
        public bool IsTranslator { get; set; }
        public bool IsTranslationEnabled { get; set; }
        public string ProfileBackgroundColor { get; set; }
        public Uri ProfileBackgroundImageUrl { get; set; }
        public Uri ProfileBackgroundImageUrlHttps { get; set; }
        public bool ProfileBackgroundTile { get; set; }
        public Uri ProfileImageUrl { get; set; }
        public Uri ProfileImageUrlHttps { get; set; }
        public Uri ProfileBannerUrl { get; set; }
        public string ProfileLinkColor { get; set; }
        public string ProfileSidebarBorderColor { get; set; }
        public ProfileColor ProfileSidebarFillColor { get; set; }
        public ProfileTextColor ProfileTextColor { get; set; }
        public bool ProfileUseBackgroundImage { get; set; }
        public bool HasExtendedProfile { get; set; }
        public bool DefaultProfile { get; set; }
        public bool DefaultProfileImage { get; set; }
        public object Following { get; set; }
        public object FollowRequestSent { get; set; }
        public object Notifications { get; set; }
        public TranslatorType TranslatorType { get; set; }
    }

    public partial class UserEntities
    {
        public Description Url { get; set; }
        public Description Description { get; set; }
    }

    public partial class Description
    {
        public Url[] Urls { get; set; }
    }

    public enum Lang { En };

    public enum ResultType { Recent };

    public enum ProfileColor { Ddeef6, Ffffff, The000000 };

    public enum TranslatorType { None };

    public partial struct Id
    {
        public double? Double;
        public long? Integer;

        public static implicit operator Id(double Double) => new Id { Double = Double };
        public static implicit operator Id(long Integer) => new Id { Integer = Integer };
    }

    public partial struct ProfileTextColor
    {
        public ProfileColor? Enum;
        public long? Integer;

        public static implicit operator ProfileTextColor(ProfileColor Enum) => new ProfileTextColor { Enum = Enum };
        public static implicit operator ProfileTextColor(long Integer) => new ProfileTextColor { Integer = Integer };
    }
}