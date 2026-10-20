using FinalBattler.Character;
using FinalBattler.GamePlay;
using FinalBattler.Interfaces;

namespace FinalBattler
{
    public class Program
    {
        static void Main()
        {
        
        List<IAttackBehavior> attacks = new List<IAttackBehavior>();
        attacks.Add(new PhysicalAttack());
        attacks.Add(new MagicalAttack());

        Console.WriteLine("--- Available Attacks ---");
        foreach (IAttackBehavior attack in attacks)
        {
            int damage = attack.CalculateDamage(10, 4);
            Console.WriteLine(attack.GetName() + " would deal " + damage + " damage");
        }


            Hero warrior = new Hero();
            warrior.SetName("Top-dog");
            warrior.SetCombatClass(CombatClass.Warrior);
            warrior.SetPower(12);
            warrior.SetHealth(12);
            warrior.SetLuck(4);

            Hero warrior2 = new Hero();
            warrior2.SetName("Underdog");
            warrior2.SetCombatClass(CombatClass.Wizard);
            warrior2.SetPower(10);
            warrior2.ChangeAttack(new MagicalAttack());
            warrior2.SetHealth(10);

            

            
            Console.WriteLine("\n ---Heroes---");
            warrior.DisplayStats();
            Console.WriteLine();
            warrior2.DisplayStats();
            Console.WriteLine();

            // Battle demo
            Combat.Battle(warrior2, warrior);
        }
    }
}