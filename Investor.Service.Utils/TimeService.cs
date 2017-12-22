using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Service.Utils
{
    public class TimeService
    {
        public string GetFormattedDate(DateTime publishedDate)
        {
            TimeSpan todayDate = ConvertToUnixTimestamp(DateTime.Now);
            TimeSpan postPublishedDate = ConvertToUnixTimestamp(publishedDate);
            int res = todayDate.Days - postPublishedDate.Days;
            switch (res)
            {
                case 0: return String.Format("Сьогодні, {0}:" + (postPublishedDate.Minutes < 10 ? "0{1}" : "{1}"), postPublishedDate.Hours, postPublishedDate.Minutes);
                case 1: return String.Format("Вчора, {0}:" + (postPublishedDate.Minutes < 10 ? "0{1}" : "{1}"), postPublishedDate.Hours, postPublishedDate.Minutes);
                default:
                    return String.Format(publishedDate.ToString("dd.MM.yyyy HH:mm"));
            }   
        }
        private TimeSpan ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return date - origin;
        }
    }
}
