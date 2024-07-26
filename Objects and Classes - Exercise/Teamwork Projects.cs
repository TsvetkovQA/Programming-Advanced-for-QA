using System;
using System.Collections.Generic;
using System.Linq;


public class Team
{
    public string Name { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }

    public Team(string name, string creator)
    {
        Name = name;
        Creator = creator;
        Members = new List<string>();
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        int numberOfTeams = int.Parse(Console.ReadLine());
        List<Team> teams = new List<Team>();
        HashSet<string> users = new HashSet<string>();

        
        for (int i = 0; i < numberOfTeams; i++)
        {
            string[] teamData = Console.ReadLine().Split("-");
            string creator = teamData[0];
            string teamName = teamData[1];

            if (teams.Any(t => t.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
            }
            else if (users.Contains(creator))
            {
                Console.WriteLine($"{creator} cannot create another team!");
            }
            else
            {
                Team team = new Team(teamName, creator);
                teams.Add(team);
                users.Add(creator);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }
        }

        
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of assignment")
            {
                break;
            }

            string[] joinData = input.Split("->");
            string user = joinData[0];
            string teamName = joinData[1];

            if (!teams.Any(t => t.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist!");
            }
            else if (teams.Any(t => t.Members.Contains(user)) || teams.Any(t => t.Creator == user))
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
            }
            else
            {
                Team team = teams.First(t => t.Name == teamName);
                team.Members.Add(user);
            }
        }

        
        List<Team> teamsWithMembers = teams.Where(t => t.Members.Count > 0).ToList();
        List<Team> teamsWithoutMembers = teams.Where(t => t.Members.Count == 0).ToList();

        
        foreach (var team in teamsWithMembers.OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name))
        {
            Console.WriteLine(team.Name);
            Console.WriteLine($"- {team.Creator}");
            foreach (var member in team.Members.OrderBy(m => m))
            {
                Console.WriteLine($"-- {member}");
            }
        }

        
        Console.WriteLine("Teams to disband:");
        foreach (var team in teamsWithoutMembers.OrderBy(t => t.Name))
        {
            Console.WriteLine(team.Name);
        }
    }
}
