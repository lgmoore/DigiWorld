namespace DigiWorld
{
    public class BuyCommand : Command
    {
        public BuyCommand() : base()
        {
        }

        /// <summary>
        /// Finds a <see cref="Digimon"/> in the <see cref="Shop.ShopList"/> and adds it to the <see cref="Player.DigimonCollection"/>.
        /// </summary>
        /// <seealso cref="CommandProcessor.FindDigimon(List{Digimon}, string)"/>
        public override string Execute(string[] text)
        {
            // Find the target Digimon
            Digimon? digimon = Globals.DigimonStore.ShopList.FindDigimon(text[1]);

            if (digimon == null)
            {
                return "Digimon not found";
            }
            if (digimon.Cost > Globals.User.Coins)
            {
                return "You cannot afford that Digimon\nYou have " + Globals.User.Coins + "C";
            }

            // Add it to the Players collection
            Globals.User.DigimonCollection.Add(digimon);
            // Subtract the cost
            Globals.User.Coins -= digimon.Cost;

            // Remove Digimon from shop
            Globals.DigimonStore.ShopList.Remove(digimon);

            // Name the Digimon
            string answer = Program.PromptInput("Would you like to name your " + digimon.Name + "?");
            if (answer == "y" || answer == "yes")
            {
                digimon.Name = Program.PromptInput(digimon.Name + " name:");
            }

            return digimon.LongName + " purchased for " + digimon.Cost + "C\n" + digimon.Name + " added to your collection";
        }
    }
}
