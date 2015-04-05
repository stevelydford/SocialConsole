using System;

namespace SocialConsole
{
    public class Post
    {
        public string Body { get; set; }

        public DateTime Timestamp { get; set; }

        public Post(string body)
        {
            Body = body;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            var timeSincePosted = (DateTime.Now - Timestamp);
            return string.Format("{0} ({1} ago)", this.Body, GetFriendlyTimeSincePosted(timeSincePosted));
        }

        private static string GetFriendlyTimeSincePosted(TimeSpan timeSincePosted)
        {
            const int secondsInOneHour = 60 * 60;
            const int secondsInOneDay = secondsInOneHour * 24;

            if (timeSincePosted.TotalSeconds < 60)
            {
                return (int)timeSincePosted.TotalSeconds == 1 ?
                    string.Format("{0} second", (int)timeSincePosted.TotalSeconds) :
                    string.Format("{0} seconds", (int)timeSincePosted.TotalSeconds);
            }
            if (timeSincePosted.TotalSeconds < secondsInOneHour)
            {
                return (int)timeSincePosted.TotalMinutes == 1 ?
                    string.Format("{0} minute", (int)timeSincePosted.TotalMinutes) :
                    string.Format("{0} minutes", (int)timeSincePosted.TotalMinutes);
            }
            if (timeSincePosted.TotalSeconds < secondsInOneDay)
            {
                return (int)timeSincePosted.TotalHours == 1 ?
                    string.Format("{0} hour", (int)timeSincePosted.TotalHours) :
                    string.Format("{0} hours", (int)timeSincePosted.TotalHours);
            }
            return (int)timeSincePosted.TotalDays == 1 ?
                    string.Format("{0} day", (int)timeSincePosted.TotalDays) :
                    string.Format("{0} days", (int)timeSincePosted.TotalDays);
        }
    }
}