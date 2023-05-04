using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 1; i <= n; i++)
            {
                string[] teamArg = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string creatorName = teamArg[0];
                string teamName = teamArg[1];
                // проверяваме дали има поне един отбор на който името да съвпада с името на отбора който искам да създам.Any връща true or false. Проверява се дали е изпълнено условие
                //  С contain не може да се направи такава проверка, защото той търси съществува ли такъв обект в листа
                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teams.Any(t => t.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }
                Team newTeam = new Team(teamName, creatorName);
                teams.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }
            string comand = Console.ReadLine();
            while (comand != "end of assignment")
            {
                string[] joinArg = comand.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string memberName = joinArg[0];
                string teamName = joinArg[1];
                Team searchedTeam = teams.FirstOrDefault(t => t.Name == teamName);
                // връща първия обект от листа отговарящ на това име,и го записва в
                if (searchedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    comand = Console.ReadLine();
                    continue;
                }
                if (IsAlreadyMemberOfTeam(teams, memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    comand = Console.ReadLine();
                    continue;
                }
                // или if(teams.Any(t => t.Members.Contains(memberName)))
                //     Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                if (teams.Any(t => t.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    comand = Console.ReadLine();
                    continue;
                }
                searchedTeam.AddMember(memberName);
                comand = Console.ReadLine();
            }

            List<Team> teamWithMembers = teams.Where(t => t.Members.Count > 0).OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).ToList();
            List<Team> teamsToDisband = teams.Where(t => t.Members.Count == 0).ToList();

            PrintValidTeams(teamWithMembers);
            Console.WriteLine("Teams to disband:");
            foreach (Team invalidTeam in teamsToDisband)
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }
        }
        static bool IsAlreadyMemberOfTeam(List<Team> teams, string memberName)
        {
            foreach (Team team in teams)
            {
                if (team.Members.Contains(memberName))
                {
                    return true;
                }
            }
            return false;
        }
        static void PrintValidTeams(List<Team> validTeams)
        {
            foreach (Team validTeam in validTeams)
            {
                Console.WriteLine($"{validTeam.Name}");
                Console.WriteLine($"- {validTeam.Creator}");

                foreach (string member in validTeam.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
        }
    }

    class Team
    {
        public Team(string teamName, string creatorName)
        {
            this.Name = teamName;
            this.Creator = creatorName;
            // Always remember to initialize collections in the ctor!!!
            this.Members = new List<string>();
        }
        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }

        public void AddMember(string member)
        {
            this.Members.Add(member);
        }
    }
}
