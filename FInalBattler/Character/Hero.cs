using FinalBattler.Character.Upgrades;
using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Hero : Creations, IHero
    {
        public int Health { get; set; }
        public int Power { get; set; }
        public int Luck { get; set; }
        public int Mana { get; set; }
        public int ExperienceRemaining { get; set; }
        public CombatClass CombatClass { get; set; }
        public List<Item> Items { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Spell> Spells { get; set; }
        public List<Equipment> Equipment { get; set; }

        
    public Hero()
    {
            Name = "Unknown";
            Level = 0;
            Health = 1;
            Power = 1;
            Luck = 1;
            Mana = 1;
            ExperienceRemaining = 1;

            Items = new List<Item>();
            Skills = new List<Skill>();
            Spells = new List<Spell>();
            Equipment = new List<Equipment>();
    }





    public void DisplayStats(bool showTotalStats = false)
        {
            Console.WriteLine($"{Name} (Level {Level})");
            Console.WriteLine($"Class: {CombatClass}");

            if (showTotalStats)
            {
                CalculateTotals();
                Console.WriteLine("Totals (with equipment bonus) ");
                Console.WriteLine($"Health: {TotalHealth}");
                Console.WriteLine($"Power: {TotalPower}");
                Console.WriteLine($"Luck: {TotalLuck}");
            }
            else
            {
                Console.WriteLine("Natural Stats");
                Console.WriteLine($"Health: {Health}");
                Console.WriteLine($"Power: {Power}");
                Console.WriteLine($"Luck: {Luck}");
            }

            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"XP to next level: {ExperienceRemaining}");
        }





    public void LevelUp()
        {
            
        Level++;

        Random random = new Random();

        switch (CombatClass)
            {
                case CombatClass.Wizard: 
                    Health += random.Next(1, 6);   
                    Power  += random.Next(8, 12);    
                    Luck   += random.Next(6, 15);    
                    break;

                case CombatClass.Warrior:
                    Health += random.Next(10, 15); 
                    Power  += random.Next(8, 4);    
                    Luck   += random.Next(3, 7);    
                    break;

                case CombatClass.Rogue:
                    Health += random.Next(3, 8);   
                    Power  += random.Next(1, 3);    
                    Luck   += random.Next(3, 10);    
                    break;

                default:
                    
                    Health += random.Next(1, 15);
                    Power  += random.Next(1, 15);
                    Luck   += random.Next(1, 15);
                    break;
            }

            Console.WriteLine($"{Name} leveled up to {Level}");
        }




        public void CalculateTotals()
        {
        }





        


        
    }
}
