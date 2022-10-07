namespace DigiWorld
{
    /// <summary>
    /// Class <c>Player</c> represents the programs User.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Instance variable <c>_name</c> represents the name of the Player.
        /// </summary>
        /// <seealso cref="Name"/>
        private string _name;
        /// <summary>
        /// Instance variable <c>_digimonCollection</c> represents the collection of Digimon belonging to the Player.
        /// </summary>
        /// <seealso cref="DigimonList"/>
        private DigimonList _digimonCollection = new DigimonList();
        /// <summary>
        /// Instance variable <c>_coins</c> represents the amount of Coins owned by the Player.
        /// </summary>
        /// <remarks>
        /// Initially set to 25.
        /// </remarks>
        /// <seealso cref="Coins"/>
        private int _coins = 25;
        /// <summary>
        /// Instance variable <c>_energy</c> represents the amount of Energy owned by the Player.
        /// </summary>
        /// <remarks>
        /// Initially set to 100.
        /// </remarks>
        /// <seealso cref="Energy"/>
        private int _energy = 100;
        /// <summary>
        /// Instance variable <c>_victories</c> represents the amount of battles won by the Player.
        /// </summary>
        /// <remarks>
        /// Initially set to 0.
        /// </remarks>
        /// <seealso cref="Victories"/>
        private int _victories = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="sp">
        /// The <see cref="Name"/> of the Player to construct.
        /// </param>
        public Player(string name)
        {
            _name = name;
        }

        /// <value>
        /// The <c>Name</c> property represents a name for this Player.
        /// </value>
        /// <remarks>
        /// The <see cref="Name"/> is a <see langword="string"/> used to identify the Player.
        /// </remarks>
        public string Name
        {
            get
            {
                return _name;
            }
        }
        /// <value>
        /// The <c>Coins</c> property represents the number of Coins owned Player.
        /// </value>
        /// <remarks>
        /// <see cref="Coins"/> is an <see langword="int"/>.<br />
        /// Coins are used to purchase <see cref="Digimon"/> from the <see cref="Shop"/>.<br />
        /// More coins are rewarded from <see cref="Battle"/>.
        /// </remarks>
        /// <seealso cref="Digimon.Cost"/>
        public int Coins
        {
            get
            {
                return _coins;
            }
            set
            {
                _coins = value;
            }
        }
        /// <value>
        /// The <c>Energy</c> property represents the amount of Digivolution Energy posessed by the Player.
        /// </value>
        /// <remarks>
        /// <see cref="Energy"/> is an <see langword="int"/>.<br />
        /// Energy is used to <see cref="Digimon.Digivolve(Player)"/> a <see cref="Digimon"/>.<br />
        /// More energy are rewarded from <see cref="Battle"/>.
        /// </remarks>
        /// <seealso cref="Digimon.DigivolutionCost"/>
        public int Energy
        {
            get
            {
                return _energy;
            }
            set
            {
                _energy = value;
            }
        }
        /// <value>
        /// The <c>Victories</c> property represents the amount of Battles won by the Player.
        /// </value>
        public int Victories
        {
            get
            {
                return _victories;
            }
            set
            {
                _victories = value;
            }
        }
        /// <value>
        /// The <c>DigimonCollection</c> represents the collection of Digimon belonging to the Player.
        /// </value>
        /// <remarks>
        /// The <see cref="DigimonCollection"/> is a <see langword="DigimonList"/>
        /// used to store the Digimon belonging to the Player.
        /// </remarks>
        public DigimonList DigimonCollection
        {
            get
            {
                return _digimonCollection;
            }
        }

        /// <summary>
        /// Method to print the Players full details.
        /// </summary>
        /// <returns>
        /// string: The players details
        /// </returns>
        public string PrintPlayerDetails()
        {
            string text = "\t -- " + Name + " -- \n\t";
            text += "Coins: " + Coins + "\n\t";
            text += "Digivolution Energy: " + Energy + "\n\t";
            text += "Total Victories: " + Victories + "\n\t";
            return text;
        }

        /// <summary>
        /// Method to print the Players full digimon collection.
        /// </summary>
        /// <returns>
        /// string: The digimon collection
        /// </returns>
        /// <seealso cref="DigimonCollection"/>
        /// <seealso cref="Digimon.ShortStats"/>
        public string PrintDigimonCollection()
        {
            string text = "\t -- My Digimon -- \n";
            text += DigimonCollection.PrintList();
            text += "\n\n\t------------------------\n";
            return text;
        }
    }
}