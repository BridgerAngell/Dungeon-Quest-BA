using FinalBattler.Character;
using FinalBattler.Interfaces;

namespace FinalBattler.GamePlay
{
    public class Combat
    {
        public static void Battle(Hero attacker, Hero defender)
        {
            Console.WriteLine("--Battle Start-- ");
            Console.WriteLine(attacker.Name + " vs " + defender.Name);
            Console.WriteLine();

            int damage = attacker.Attack(defender.Luck);
            Console.WriteLine(attacker.Name + " uses " + attacker.AttackBehavior.GetName());
            Console.WriteLine("Deals " + damage + " damage to " + defender.Name);

            defender.TakeDamage(damage);

            Console.WriteLine(defender.Name + " has " + defender.Health + " health left!");
            Console.WriteLine();
        }
    }



    public class PhysicalAttack : IAttackBehavior
    {
        public int CalculateDamage(int power, int luck)
        {
            return power + (luck / 1);
        }

        public string GetName()
        {
            return "Bludgeon";
        }
    }



    public class MagicalAttack : IAttackBehavior
    {
        public int CalculateDamage(int power, int luck)
        {
            return (power / 2) + (luck / 2);
        }

        public string GetName()
        {
            return "Fireball!";
        }
    }
}