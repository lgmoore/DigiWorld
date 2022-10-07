namespace DigiWorld
{
    public class ViewCommand : Command
    {
        public ViewCommand() : base()
        {
        }

        /// <summary>
        /// Determines the target and returns the appropriate text.
        /// </summary>
        /// <seealso cref="Globals"/>
        public override string Execute(string[] text)
        {
            switch (text[1])
            {
                case "shop":
                    return Globals.DigimonStore.PrintShopList();
                case "me":
                case "player":
                    return Globals.User.PrintPlayerDetails();
                case "digimon":
                case "collection":
                    return Globals.User.PrintDigimonCollection();
                default:
                    return "Unknown Command";
            }
        }
    }
}
