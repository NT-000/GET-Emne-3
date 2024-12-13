namespace ClickerGame
{
    internal class GetPointSpace : ICommand
    {
        public char Key { get; set; } = ' ';
        public GetPointSpace()
        {   

        }

        public void Run(ClickerGame clicker)
        {
            clicker.ClickForPoints();
        }

    }
}
