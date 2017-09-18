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
                { "Політика", 8 },
                { "Культура", 8 },
                { "Економіка", 4 },
                { "IT технології", 4 }
            };
            largePostPreviewCount = new Dictionary<string, int>
            {
                { "Політика", 2 },
                { "Культура", 2 },
                { "Економіка", 1 },
                { "IT технології", 1 }
            };
            categoryMoreButtonTheme = new Dictionary<string, string>
            {
                { "Політика", "circle-politics-color" },
                { "Культура", "circle-culture-color" },
                { "Економіка", "circle-economy-color" },
                { "IT технології", "circle-it-color" }
            };

            categoryBorderTheme = new Dictionary<string, string>
            {
                { "Політика", "politics-today-color" },
                { "Культура", "culture-border-color" },
                { "Економіка", "economy-border-color" },
                { "IT технології", "it-border-color" }
            };

            categoryPublishedTimeTheme = new Dictionary<string, string>
            {
                { "Політика", "politics-today-color" },
                { "Культура", "culture-today-color" },
                { "Економіка", "economy-today-color" },
                { "IT технології", "it-today-color" }
            };
        }
    }
}
