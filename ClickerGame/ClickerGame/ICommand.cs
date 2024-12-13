namespace ClickerGame
{
    public interface ICommand
    {   
        public char Key { get; set; }
        void Run(ClickerGame clicker);
    }
}
