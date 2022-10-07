namespace DigiWorld
{
    public class DigivolveCommand : Command
    {
        public DigivolveCommand() : base()
        {
        }

        /// <summary>
        /// Finds a <see cref="Digimon"/> and Digivolves it.
        /// </summary>
        /// <seealso cref="CommandProcessor.FindDigimon(List{Digimon}, string)"/>
        /// <seealso cref="Digimon.Digivolve(Player)"/>
        public override string Execute(string[] text)
        {
            // Find the target Digimon
            Digimon? digimon = Globals.User.DigimonCollection.FindDigimon(text[1]);
            if (digimon == null)
            {
                return "Digimon not found";
            }
            else
            {
                int cost = digimon.DigivolutionCost;
                if (cost > Globals.User.Energy)
                {
                    return "You do not have enough Energy to Digivolve that Digimon\nYou have " + Globals.User.Energy + " Energy";
                }
                
                string oldName = digimon.LongName;

                // Digivolve!
                if (digimon.Digivolve(Globals.User))
                {
                    return "*** " + oldName + " digivolved to " + digimon.Species.Name + "! ***";
                }
                else
                {
                    return oldName + " cannont Digivolve";
                }
            }
        }
    }
}
