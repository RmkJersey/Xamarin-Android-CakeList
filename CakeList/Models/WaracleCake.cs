using System;
using CakeList.Utility;

namespace CakeList.Models
{
    /// <summary>
    /// The main WaracleCake class
    /// </summary>
    public class WaracleCake : IEquatable<WaracleCake>
    {
        /// <summary>
        /// Required for JSON deserialization
        /// </summary>
        public WaracleCake()
        {
        }

        /// <summary>
        /// Cake title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Cake description
        /// </summary>
        public string Desc { get; set; } = string.Empty;

        /// <summary>
        /// Cake image url
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>Constructor to create each cake object</summary>
        /// <param name="title">string</param>
        /// <param name="description">string</param>
        /// <param name="imageUrl">string</param>
        /// <returns><c>WaracleCake</c></returns>
        public WaracleCake(string title, string description, string imageUrl)
        {
            Title = FormatString.FirstCharToUpperTrimWhiteSpace(title);
            Desc = FormatString.FirstCharToUpperTrimWhiteSpace(description);
            Image = imageUrl;
        }

        /// <summary>Cleans title and description</summary>
        /// <returns>cleaned <c>WaracleCake</c> object</returns>
        public WaracleCake CleanTitleAndDesc()
        {
            Title = FormatString.FirstCharToUpperTrimWhiteSpace(Title);
            Desc = FormatString.FirstCharToUpperTrimWhiteSpace(Desc);

            return this;
        }

        /// <summary>Determines whether the specified <c>WaracleCake</c> is equal to the current <c>WaracleCake</c> using the <c>Title</c> field.</summary>
        /// <param name="other">The object to compare with the current <c>WaracleCake</c>.</param>
        /// <returns><c>true</c> if the specified <c>WaracleCake.Title</c> is equal to the current <c>WaracleCake.Title</c>; otherwise, <c>false></c></returns>
        public bool Equals(WaracleCake other)
        {
            return string.Equals(Title, other.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Title.ToLowerInvariant().GetHashCode();
        }
    }
}