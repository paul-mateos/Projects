using System;
using System.Text.RegularExpressions;

namespace YouTube.SDK.Entities
{
    /// <summary>
    /// Contains logic to exctract duration from YouTube Duration Strings
    /// </summary>
    public class DurationParser
    {
        /// <summary>
        /// The duration regex expression
        /// </summary>
        private readonly string durationRegexExpression = @"PT(?<minutes>[0-9]{0,})M(?<seconds>[0-9]{0,})S";

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <param name="durationStr">The duration string.</param>
        /// <returns>return ticks of the song</returns>
        public ulong? GetDuration(string durationStr)
        {
            ulong? durationResult = default(ulong?);
            Regex regexNamespaceInitializations = new Regex(durationRegexExpression, RegexOptions.None);
            Match m = regexNamespaceInitializations.Match(durationStr);
            if (m.Success)
            {
                string minutesStr = m.Groups["minutes"].Value;
                string secondsStr = m.Groups["seconds"].Value;
                int minutes = int.Parse(minutesStr);
                int seconds = int.Parse(secondsStr);
                TimeSpan duration = new TimeSpan(0, minutes, seconds);
                durationResult = (ulong)duration.Ticks;
            }

            return durationResult;
        }
    }
}
