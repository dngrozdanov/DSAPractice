using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerRanking
{
    static class Program
    {
        static readonly SortedDictionary<int, Player> RankListByPosition = new SortedDictionary<int, Player>();
        static readonly List<Player> RankListByName = new List<Player>();

        static void Main()
        {
            var strBuilder = new StringBuilder();
            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                var command = input.Split()[0];
                var args = input.Replace(command + " ", "").Split(new char[] { ' ' });

                if (command == "add")
                {
                    var message = AddPlayer(args[0], args[1], int.Parse(args[2]), int.Parse(args[3]));
                    strBuilder.AppendLine(message);
                }
                else if (command == "find")
                {
                    var message = Find(args[0]);
                    strBuilder.AppendLine(message);
                }
            }

            Console.WriteLine(strBuilder.ToString().TrimEnd());
        }

        static string Find(string type)
        {
            if (RankListByName.Count > 0)
                return $"Type {type}: {string.Join("; ", RankListByName.OrderByDescending(x => x.Age), 0, 5)}";
            else
                return $"Type {type}: ";
        }

        static string AddPlayer(string name, string type, int age, int position)
        {
            var newPlayer = new Player(name, type, age, position);

            RankListByName.Add(newPlayer);

            if (RankListByPosition.ContainsKey(position))
            {

            }
            RankListByPosition.Add(position, newPlayer);

            return $"Added player {name} to position {position}";
        }
    }

    class Player : IComparable<Player>
    {
        public Player(string name, string type, int age, int position)
        {
            Name = name;
            Type = type;
            Age = age;
            Position = position;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Position { get; set; }

        public override string ToString()
        {
            return $"{Name}({Age})";
        }

        public int CompareTo(Player other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var nameComparison = string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
            if (nameComparison != 0) return nameComparison;
            var typeComparison = string.Compare(Type, other.Type, StringComparison.InvariantCultureIgnoreCase);
            if (typeComparison != 0) return typeComparison;
            var positionComparison = Position.CompareTo(other.Position);
            if (positionComparison != 0) return positionComparison;
            return Age.CompareTo(other.Age);
        }
    }
}