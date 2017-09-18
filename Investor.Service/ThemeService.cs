using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Service
{
    public class ThemeService
    {
        public Dictionary<string, string> categoryBorderTheme;
        public Dictionary<string, string> categoryPublishedTimeTheme;

        public ThemeService()
        {
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
