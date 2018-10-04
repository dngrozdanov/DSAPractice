using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PostsFormalContest
{
    static class Program
    {
        public static SortedDictionary<string, User> Users = new SortedDictionary<string, User>();
        public static SortedSet<Post> Posts = new SortedSet<Post>();

        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var strBuilder = new StringBuilder();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                var command = input.Split()[0];
                var args = input.Replace(command + " ", "").Split(new char[] { ' ' });

                if (command == "add")
                {
                    AddUser(args[0]);
                }
                else if (command == "subscribe")
                {
                    var message = Subscribe(args[0], args[1]);
                    strBuilder.AppendLine(message);
                }
                else if (command == "post")
                {
                    var message = Post(args[0], args[1]);
                    strBuilder.AppendLine(message);
                }
                else if (command == "listposts")
                {
                    var message = ListPosts(args[0]);
                    strBuilder.AppendLine(message);
                }
            }

            Console.WriteLine(strBuilder.ToString().TrimEnd());
        }

        static string ListPosts(string user)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine($"{user}: {Users[user].Following.Count} subscriptions");

            foreach (var post in Posts.Where(x => x.Creator == Users[user] || Users[user].Following.Contains(x.Creator)).Take(10))
            {
                strBuilder.AppendLine(post.ToString());
            }

            return strBuilder.ToString().TrimEnd();
        }

        static void AddUser(string name)
        {
            Users.Add(name, new User(name));
        }

        static string Subscribe(string firstUser, string secondUser)
        {
            //if (Users[firstUser].Following.Contains(Users[secondUser]))
            //    return "";

            Users[firstUser].Following.Add(Users[secondUser]);
            return $"{firstUser} subscribed to {secondUser}";
        }

        static string Post(string user, string text)
        {
            var post = new Post
            {
                Creator = Users[user],
                Text = text,
                Order = Posts.Count + 1
            };

            Posts.Add(post);

            return $"{user} created post {Posts.Count}: {text}";
        }
    }

    class Post : IComparable<Post>
    {
        public Post(string text, int order, User creator)
        {
            Text = text;
            Order = order;
            Creator = creator;
        }

        public Post()
        {

        }

        public override string ToString()
        {
            return $"- Post {this.Order}: {this.Text}";
        }

        public int CompareTo(Post other)
        {
            return other.Order.CompareTo(this.Order);
        }

        public string Text { get; set; }
        public int Order { get; set; }
        public User Creator { get; set; }
    }

    class User
    {
        public User(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<User> Following { get; set; } = new List<User>();
    }
}