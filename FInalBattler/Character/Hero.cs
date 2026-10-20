using FinalBattler.Character.Upgrades;
using FinalBattler.GamePlay;
using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Hero : Creations, IHero
    {
        private int _health;
        private int _power;
        private int _luck;
        private int _mana;
        private int _experienceRemaining;
        private CombatClass _combatClass;
        private List<Item> _items;
        private List<Skill> _skills;
        private List<Spell> _spells;
        private List<Equipment> _equipment;
        private IAttackBehavior _attackBehavior;



        
        public int Health
        {
        get { return _health; }
        private set { _health = value; }
        }


        public void SetHealth(int amount)
        {
            _health = amount;
        }

        public int Power
        {
            get { return _power; }
            private set { _power = value; }
        }


        public void SetPower(int amount)
        {
            _power = amount;
        }

        public int Luck
        {
            get { return _luck; }
            private set { _luck = value; }
        }

        public void SetLuck(int amount)
        {
            _luck = amount;
        }


        public CombatClass CombatClass
        {
            get { return _combatClass; }
            private set { _combatClass = value; }
        }

        public void SetCombatClass(CombatClass combatClass)
        {
            _combatClass = combatClass;
        }


        public int Mana
        {
            get { return _mana; }
            private set { _mana = value; }
        }


        public int ExperienceRemaining
        {
            get { return _experienceRemaining; }
            private set { _experienceRemaining = value; }
        }


        public List<Item> Items
        {
            get { return _items; }
            private set { _items = value; }
        }


        public List<Skill> Skills
        {
            get { return _skills; }
            private set { _skills = value; }
        }


        public List<Spell> Spells
        {
            get { return _spells; }
            private set { _spells = value; }
        }


        public List<Equipment> Equipment
        {
            get { return _equipment; }
            private set { _equipment = value; }
        }


        public IAttackBehavior AttackBehavior
        {
            get { return _attackBehavior; }
            private set { _attackBehavior = value; }
        }






        public Hero()   
        {
            SetName("Unknown");
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

            AttackBehavior = new PhysicalAttack();
        }
        
        
        
        public void LevelUp() //ignore
        {
            
            Level++;

            Random random = new Random();

            switch (CombatClass)
            {
                case CombatClass.Wizard:
                    Health += random.Next(1, 6);
                    Power += random.Next(4, 10);
                    Luck += random.Next(6, 15);
                    break;

                case CombatClass.Warrior:
                    Health += random.Next(8, 15);
                    Power += random.Next(4, 8);
                    Luck += random.Next(2, 6);
                    break;

                case CombatClass.Rogue:
                    Health += random.Next(3, 8);
                    Power += random.Next(2, 6);
                    Luck += random.Next(5, 12);
                    break;

                default:
                    Health += random.Next(1, 15);
                    Power += random.Next(1, 15);
                    Luck += random.Next(1, 15);
                    break;

            
            }

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
            Console.WriteLine($"Attack Style: {AttackBehavior.GetName()}");
        }



        



        public void CalculateTotals()
        {
            TotalHealth = Health;
            TotalPower = Power;
            TotalLuck = Luck;

            foreach (var eq in Equipment)
            {
                switch (eq.StatBoostType)
                {
                    case StatBoostType.Health:
                        TotalHealth += eq.BoostValue;
                        break;
                    case StatBoostType.Power:
                        TotalPower += eq.BoostValue;
                        break;
                    case StatBoostType.Luck:
                        TotalLuck += eq.BoostValue;
                        break;
                }
            }
        }



        public int Attack(int defenderLuck)
        {
            return AttackBehavior.CalculateDamage(Power, defenderLuck);
        }

        public void ChangeAttack(IAttackBehavior newBehavior)
        {
            AttackBehavior = newBehavior;
            Console.WriteLine($"{Name} switched to {AttackBehavior.GetName()}.");
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }
    }
}