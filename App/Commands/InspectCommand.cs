namespace DigiWorld
{
    public class InspectCommand : Command
    {
        public InspectCommand() : base()
        {
        }

        /// <summary>
        /// Returns the full details of a <see cref="Digimon"/>.
        /// </summary>
        /// <seealso cref="CommandProcessor.FindDigimon(List{Digimon}, string)"/>
        public override string Execute(string[] text)
        {
            if (text.Length != 3)
            {
                return "What would you like to inspect?";
            }
            // Determine the List to search in
            DigimonList targetList;
            switch (text[1])
            {
                case "shop":
                    targetList = Globals.DigimonStore.ShopList;
                    break;
                case "my":
                case "digimon":
                    targetList = Globals.User.DigimonCollection;
                    break;
                default:
                    return "Unknown Command";
            }
            // Search the List
            Digimon? digimon = targetList.FindDigimon(text[2]);
            // Handle the result
            if (digimon == null)
            {
                return "Digimon not found";
            }
            else
            {
                string details = digimon.FullDetails;
                if (text[1] == "shop")
                {
                    details += "\tPrice: " + digimon.Cost + "C";
                }
                return details;
            }
        }
    }
}
