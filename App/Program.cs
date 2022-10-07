namespace DigiWorld
{
    public class Program
    {
        /// <summary>
        /// Main program starting point.<br />
        /// Initialises the <see cref="Player"/> and the <see cref="CommandProcessor"/> and then Executes input.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Welcome to DigiWorld!");

            // Get Player name and initialise
            string name = Program.PromptInput("Enter Player Name: ");
            Globals.User = new Player(name);
            Console.WriteLine("Hello " + Globals.User.Name);

            CommandProcessor processor = new CommandProcessor();

            while (true)
            {
                Console.WriteLine("Please enter a command:");
                // Read the users input
                string? input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (input == "exit" || input == "quit")
                {
                    break;
                }
                // Print the result to console
                Console.WriteLine(processor.Process(input.Split(" ")));
            }
        }

        /// <summary>
        /// Static re-usable function to get text input from user
        /// </summary>
        public static string PromptInput(string prompt)
        {
            string? input = null;
            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            }
            return input;
        }
    }
}