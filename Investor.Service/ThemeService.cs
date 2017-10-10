using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Service
{
    public class ThemeService
    {
        public Dictionary<string, string> categoryBorderTheme;
        public Dictionary<string, string> categoryPublishedTimeTheme;
        public Dictionary<string, string> categoryMoreButtonTheme;
        public Dictionary<string, int> largePostPreviewCount;
        public Dictionary<string, int> postPreviewCount;

        public ThemeService()
        {
            postPreviewCount = new Dictionary<string, int>
            {
                { "policy", 8 },
                { "culture", 8 },
                { "economy", 4 },
                { "it", 4 }
            };
            largePostPreviewCount = new Dictionary<string, int>
            {
                { "policy", 2 },
                { "culture", 2 },
                { "economy", 1 },
                { "it", 1 }
            };
            categoryMoreButtonTheme = new Dictionary<string, string>
            {
                { "policy", "circle-policy-color" },
                { "culture", "circle-culture-color" },
                { "economy", "circle-economy-color" },
                { "it", "circle-it-color" }
            };

            categoryBorderTheme = new Dictionary<string, string>
            {
                { "policy", "policy-today-color" },
                { "culture", "culture-border-color" },
                { "economy", "economy-border-color" },
                { "it", "it-border-color" }
            };

            categoryPublishedTimeTheme = new Dictionary<string, string>
            {
                { "policy", "policy-today-color" },
                { "culture", "culture-today-color" },
                { "economy", "economy-today-color" },
                { "it", "it-today-color" }
            };
        }
    }
}
