namespace DigiWorld
{
    /// <summary>
    /// Class <c>CommandProcessor</c> maps Player input to a Command.
    /// </summary>
    public class CommandProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandProcessor"/> class.<br />
        /// This initializes a new instance of <see cref="Shop"/> and stores it in <see cref="Globals"/>
        /// </summary>
        public CommandProcessor()
        {
            Globals.DigimonStore = new Shop();
        }

        /// <summary>
        /// Determines the type of <see cref="Command"/> to initialise and executes it.
        /// </summary>
        /// <returns>
        /// string: The resolution of the excecuted command.
        /// </returns>
        /// <param name="text">
        /// The <see cref="Player"/> input as an array.
        /// </param>
        public string Process(string[] text)
        {
            Command com;
            switch (text[0])
            {
                case "view":
                    com = new ViewCommand();
                    break;
                case "inspect":
                    com = new InspectCommand();
                    break;
                case "buy":
                case "purchase":
                    com = new BuyCommand();
                    break;
                case "digivolve":
                    com = new DigivolveCommand();
                    break;
                case "battle":
                    com = new BattleCommand();
                    break;
                default:
                    return "Unknown Command";
            }
            string result = com.Execute(text);

            return result;
        }
    }
}