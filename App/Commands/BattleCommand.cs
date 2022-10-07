namespace DigiWorld
{
    public class BattleCommand : Command
    {
        public BattleCommand() : base()
        {
        }

        /// <summary>
        /// Initialises a <see cref="Battle"/> and resolves it, handling the result.
        /// </summary>
        /// <seealso cref="CommandProcessor.FindDigimon(List{Digimon}, string)"/>
        /// <seealso cref="Battle.Resolve"/>
        public override string Execute(string[] text)
        {
            if (Globals.User.DigimonCollection.List.Count < 1)
            {
                return "You have no Digimon to battle with. Purchase one from the shop.";
            }

            if (text.Length < 2)
            {
                // Need to specify battle type
                return "What would you like to battle? eg. random, digimon name, level 1";
            }

            Digimon? opponentDigimon;
            Digimon? myDigimon;

            // Determine the opponent
            switch (text[1])
            {
                case "random":
                    Species speciesToGenerate;
                    if (text.Length > 2 && int.TryParse(text[2], out int rank))
                    {
                        if (rank > 4 || rank < 1)
                        {
                            return "Rank number must be 1 to 4";
                        }
                        speciesToGenerate = SpeciesLibrary.Instance.GetRandomSpecies(rank);
                    }
                    else
                    {
                        // Generate a random digimon of rank 1-3
                        speciesToGenerate = SpeciesLibrary.Instance.GetRandomSpecies((new Random()).Next(1, 3));
                    }
                    opponentDigimon = speciesToGenerate.GenerateDigimon();
                    break;
                default:
                    opponentDigimon = Globals.User.DigimonCollection.FindDigimon(text[1]);
                    break;
            }
            if (opponentDigimon == null)
            {
                return "Target not found";
            }

            // Print Players collection
            Console.WriteLine(Globals.User.PrintDigimonCollection());
            // Prompt the user to select a Digimon from their collection
            while (true)
            {
                string? input = Program.PromptInput("Select a Digimon");
                if (input == "exit" || input == "cancel")
                {
                    return "";
                }
                myDigimon = Globals.User.DigimonCollection.FindDigimon(input);
                if (myDigimon == null)
                {
                    Console.WriteLine("Digimon not found");
                }
                else
                {
                    break;
                }
            }

            // Initialise the battle and resolve it
            Battle battle = new Battle(myDigimon, opponentDigimon);
            int battleResult = battle.Resolve();

            // Handle the result
            switch (battleResult)
            {
                case 1:
                    // User won
                    Console.WriteLine(myDigimon.LongName + " was victorious!");

                    // Handle battle rewards
                    switch (text[1])
                    {
                        case "random":
                            int coins = opponentDigimon.Species.Rank * 2;
                            Globals.User.Coins += coins;
                            ++Globals.User.Victories;
                            ++myDigimon.Victories;
                            return "You won " + coins + " coins!";
                        default:
                            return "";
                    }
                case 2:
                    // Opponent won
                    return myDigimon.LongName + " was defeated by " + opponentDigimon.LongName;
                case 3:
                    // Draw
                    Console.WriteLine("Battle was a draw. No Digimon won.");
                    Globals.User.Coins += 1;
                    return "You won a coin";
                case 0:
                default:
                    // Error occured
                    return "Abort. Error occurred in battle.";
            }
        }
    }
}
