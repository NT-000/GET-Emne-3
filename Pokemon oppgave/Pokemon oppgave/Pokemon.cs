﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_oppgave
{
    public class Pokemon
    {
        public string Name;
        public int Health;
        public int Level;


            public Pokemon(string pname, int hp, int lvl) {
            Name = pname;
            Health = hp;
            Level = lvl;
            }
        public static Pokemon CreatePokemon()
        {
            Console.WriteLine("Give your Pokemon a name");
            var name = Console.ReadLine();
            
            Console.WriteLine("HP");
            int hp = int.Parse(Console.ReadLine());

            Console.WriteLine("Which lvl?");
            int lvl = int.Parse(Console.ReadLine());

            return new Pokemon(name, hp, lvl);
        }
        public void RevealPokemon()
        {
            Console.WriteLine($"Name is: {Name} Health: {Health} Level: {Level}");
        }
    }
}

