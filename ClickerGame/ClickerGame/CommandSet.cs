namespace ClickerGame
{
    internal class CommandSet
    {   

        private List<ICommand> Commands { get; set; }
        public CommandSet()
        {
            Commands =
            [
               new GetPointSpace(),
               new BuyUpgrade(),
               new BuySuperUpgrade(),
               new ExitProgram(),
            ];
        }

        public void RunCommand(Char key, ClickerGame clicker)
        {
            foreach (var cmd in Commands)
            {
                if (cmd.Key == key)
                {
                   cmd.Run(clicker);
                }
            }


        }

        public void PrintChar()
        {
            
        }
    }
}
