using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory herofactory;
        private readonly ICollection<IHero> heros;

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.herofactory = heroFactory;
            heros = new List<IHero>();
        }
        public void Run()
        {
            int n = int.Parse(reader.ReadLine());
            while(n > 0)
            {
                string heroType = reader.ReadLine();
                string heroName = reader.ReadLine();
                try
                {
                    heros.Add(herofactory.CreateHero(heroName, heroType));
                    n--;
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            foreach (var hero in heros)
            {
                writer.WriteLine(hero.CastAbility());
            }
            int bossPower = int.Parse(reader.ReadLine());
            if (heros.Sum(h => h.Power) >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
