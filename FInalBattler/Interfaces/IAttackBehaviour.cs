namespace FinalBattler.Interfaces
{
    public interface IAttackBehavior
    {
        int CalculateDamage(int power, int luck);
        string GetName();
    }
}