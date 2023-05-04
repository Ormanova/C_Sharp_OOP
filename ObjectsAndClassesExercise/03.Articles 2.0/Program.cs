using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 1; i <= n; i++)
            {
                string[] currArg = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currTitle = currArg[0];
                string currContent = currArg[1];
                string currAuthor = currArg[2];

                Article currArticle = new Article(currTitle,currContent,currAuthor);
                articles.Add(currArticle);
            }
            string comand = Console.ReadLine();
            if (comand == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
               
            }
            else if (comand == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
               
            }
            else if (comand == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
                
            }
            Console.WriteLine(string.Join(Environment.NewLine,articles));
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
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
                
        }
    }
}
