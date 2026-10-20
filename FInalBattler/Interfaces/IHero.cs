namespace FinalBattler.Interfaces // ignore
{
    public interface IHero
    {
        void DisplayStats(bool showTotalStats = true);
        void LevelUp();
        void CalculateTotals();
    }
}
