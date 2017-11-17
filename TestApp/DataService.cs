using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class DataService
    {
        public static IList<Article> GetArticles()
        {
            return new List<Article>
            {
                new Article
                {
                    Title = "Team Liquid SC2 wiki page",
                    Author = "Test author",
                    ArticleUrl = "http://wiki.teamliquid.net/starcraft2/Team_Liquid"
                },
                new Article
                {
                    Title = "Team Liquid website",
                    Author = "Test author",
                    ArticleUrl = "http://www.teamliquid.net"
                },
                new Article
                {
                    Title = "Team Liquid website",
                    Author = "Test author",
                    ArticleUrl = "http://www.teamliquid.net"
                }

            };
        }
    }
}
