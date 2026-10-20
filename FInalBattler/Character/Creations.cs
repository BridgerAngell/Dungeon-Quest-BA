namespace FinalBattler.Character
{
    public class Creations
    {
        private string _name = string.Empty;
        private int _level;
        private int _totalHealth;
        private int _totalPower;
        private int _totalLuck;

  
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public int TotalHealth
        {
            get { return _totalHealth; }
            set { _totalHealth = value; }
        }

        public int TotalPower
        {
            get { return _totalPower; }
            set { _totalPower = value; }
        }

        public int TotalLuck
        {
            get { return _totalLuck; }
            set { _totalLuck = value; }
        }

    }


    public enum CombatClass
    {
        None,
        Warrior,
        Wizard,
        Rogue
    }
}