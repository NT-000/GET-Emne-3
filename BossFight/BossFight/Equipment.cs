namespace BossFight
{
    internal class Equipment
    {
        private int Defence { get; set; }
        private int Attack { get; set; }

        public Equipment(int defence, int attack)
        {
            Defence = defence;
            Attack = attack;
        }
    }
}
