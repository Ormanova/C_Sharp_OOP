using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Article
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> article = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string title = article[0];
            string content = article[1];
            string author = article[2];
            
            int n = int.Parse(Console.ReadLine());
            List<Article> newArticle = new List<Article>();
            for (int i = 1; i <= n; i++)
            {
               
                List<string> arg = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string action = arg[0];

                if (action == "Edit")
                {
                     string newContent = arg[1];
                    article.Edit(content,newArticle);
                }
                else if (action == "ChangeAuthor")
                {
                    author = arg[1];
                    newArticle.ChangeAuthor(author);
                }
                else if (action == "Rename")
                {
                    title = arg[1];
                    newArticle.Rename(title);
                    
                }
            }
            
            foreach (var item in article)
            {
                Console.WriteLine(article);
            }
        }
        class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }

            public string Content { get; set; }

            public string Author { get; set; }

            public string Edit(string content, List<Article> newArticle)
            {
                return content;
            }
            public string ChangeAuthor(string author)
            {
                return author;
            }
            public string Rename(string title)
            {
                return title;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }


    }
}
