using System;
using System.Collections.Generic;
using System.Linq;


public class Pokemon
{
    public string Name { get; set; }
    public string Element { get; set; }
    public int Health { get; set; }

    public Pokemon(string name, string element, int health)
    {
        Name = name;
        Element = element;
        Health = health;
    }
}


public class Trainer
{
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> PokemonCollection { get; set; }

    public Trainer(string name)
    {
        Name = name;
        Badges = 0;
        PokemonCollection = new List<Pokemon>();
    }

    public void AddPokemon(Pokemon pokemon)
    {
        PokemonCollection.Add(pokemon);
    }

    public bool HasPokemonWithElement(string element)
    {
        return PokemonCollection.Any(p => p.Element == element);
    }

    public void LoseHealth(int amount)
    {
        foreach (var pokemon in PokemonCollection)
        {
            pokemon.Health -= amount;
        }

        PokemonCollection = PokemonCollection.Where(p => p.Health > 0).ToList();
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

       
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Tournament")
            {
                break;
            }

            string[] data = input.Split(' ');
            string trainerName = data[0];
            string pokemonName = data[1];
            string pokemonElement = data[2];
            int pokemonHealth = int.Parse(data[3]);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers[trainerName] = new Trainer(trainerName);
            }

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            trainers[trainerName].AddPokemon(pokemon);
        }

        
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End")
            {
                break;
            }

            foreach (var trainer in trainers.Values)
            {
                if (trainer.HasPokemonWithElement(command))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.LoseHealth(10);
                }
            }
        }

        
        var sortedTrainers = trainers.Values
            .OrderByDescending(t => t.Badges)
            .ThenBy(t => trainers.Keys.ToList().IndexOf(t.Name))
            .ToList();

        foreach (var trainer in sortedTrainers)
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonCollection.Count}");
        }
    }
}
