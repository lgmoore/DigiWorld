namespace DigiWorld
{
    /// <summary>
    /// Class <c>Digimon</c> models a digimon creature.
    /// </summary>
    public class Digimon
    {
        /// <summary>
        /// Instance variable <c>_name</c> represents the Digimons name.
        /// </summary>
        /// <remarks>
        /// Initially set to the Species name.
        /// </remarks>
        /// <seealso cref="Name"/>
        private string _name;
        /// <summary>
        /// Instance variable <c>_species</c> represents the Digimons species/breed/type.
        /// </summary>
        /// <seealso cref="Species"/>
        private Species _species;
        /// <summary>
        /// Instance variable <c>_maxHp</c> represents the Digimons maximum health points.
        /// </summary>
        /// <remarks>
        /// Initially set to Species.BaseHp + (random(1, 10) * Species.Rank).
        /// </remarks>
        /// <seealso cref="MaxHp"/>
        private int _maxHp;
        /// <summary>
        /// Instance variable <c>_attack</c> represents the Digimons attack power.
        /// </summary>
        /// <remarks>
        /// Initially set to Species.BaseAttack + (random(1, 10) * Species.Rank).
        /// </remarks>
        /// <seealso cref="Attack"/>
        private int _attack;
        /// <summary>
        /// Instance variable <c>_defense</c> represents the Digimons defensive power.
        /// </summary>
        /// <remarks>
        /// Initially set to Species.BaseDefense + (random(1, 10) * Species.Rank).
        /// </remarks>
        /// <seealso cref="Defense"/>
        private int _defense;
        /// <summary>
        /// Instance variable <c>_maxHp</c> represents amount of battles the Digimon has won.
        /// </summary>
        /// <seealso cref="Victories"/>
        private int _victories;

        /// <summary>
        /// Initializes a new instance of the <see cref="Digimon"/> class.
        /// </summary>
        /// <remarks>
        /// Calculates the Digimons attributes.
        /// </remarks>
        /// <param name="sp">
        /// The <see cref="DigiWorld.Species"/> of the Digimon to construct.
        /// </param>
        public Digimon(Species sp)
        {
            _species = sp;
            _name = sp.Name;

            Random rnd = new Random();
            // Stat = Species.initialValue + (random(0, 10) * Species.Rank)
            _maxHp = sp.BaseHp + (rnd.Next(0, 10) * sp.Rank);
            _attack = sp.BaseAttack + (rnd.Next(0, 10) * sp.Rank);
            _defense = sp.BaseDefense + (rnd.Next(0, 10) * sp.Rank);
            _victories = 0;
        }

        /// <value>
        /// The <c>Name</c> property represents a name for this Digimon.
        /// </value>
        /// <remarks>
        /// The <see cref="Name"/> is a <see langword="string"/> used to identify the Digimon.
        /// </remarks>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        /// <value>
        /// The <c>MaxHp</c> property represents the maximum hit points of this Digimon.
        /// </value>
        /// <remarks>
        /// <see cref="MaxHp"/> is a <see langword="int"/> 
        /// used to identify the amount of damage this Digimon can take before being defeated.
        /// </remarks>
        /// <seealso cref="Battle.Resolve"/>
        public int MaxHp
        {
            get
            {
                return _maxHp;
            }
        }
        /// <value>
        /// The <c>Attack</c> property represents the attack power of this Digimon.
        /// </value>
        /// <remarks>
        /// <see cref="Attack"/> is a <see langword="int"/> 
        /// used to determine the amount of damage Digimon does when it attacks
        /// </remarks>
        /// <seealso cref="Battle.ResolveAttack(Digimon, Digimon)"/>
        public int Attack
        {
            get
            {
                return _attack;
            }
        }
        /// <value>
        /// The <c>Defense</c> property represents the defense of this Digimon.
        /// </value>
        /// <remarks>
        /// <see cref="Defense"/> is a <see langword="int"/> 
        /// used to determine the amount subtracted from incoming attacks targeting this Digimon
        /// </remarks>
        /// <seealso cref="Battle.ResolveAttack(Digimon, Digimon)"/>
        public int Defense
        {
            get
            {
                return _defense;
            }
        }
        /// <value>
        /// The <c>Victories</c> property represents the number of <c>Battles</c> won by this Digimon.
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
        /// The <c>Species</c> property represents the Digimons species/breed/type.
        /// </value>
        /// <remarks>
        /// <see cref="Species"/> is a <see langword="object"/> of type <see cref="DigiWorld.Species"/> 
        /// </remarks>
        /// <seealso cref="DigiWorld.Species"/>
        /// <seealso cref="SpeciesLibrary"/>
        public Species Species
        {
            get
            {
                return _species;
            }
        }
        /// <value>
        /// The <c>Cost</c> property represents the amount of Coins needed to purchase this Digimon from the Shop.
        /// </value>
        /// <remarks>
        /// <see cref="Cost"/> is a derived <see langword="int"/><br />
        /// Calculated from <see cref="DigiWorld.Species.Rank"/> * 5
        /// </remarks>
        /// <seealso cref="Species"/>
        /// <seealso cref="Player.Coins"/>
        /// <seealso cref="Shop"/>
        public int Cost
        {
            get
            {
                return _species.Rank * 5;
            }
        }
        /// <value>
        /// The <c>DigivolutionCost</c> property represents the amount of Energy needed to digivolve this Digimon.
        /// </value>
        /// <remarks>
        /// <see cref="DigivolutionCost"/> is a derived <see langword="int"/><br />
        /// Calculated from <see cref="DigiWorld.Species.Rank"/> * 20
        /// </remarks>
        /// <seealso cref="Species"/>
        /// <seealso cref="Player.Energy"/>
        /// <seealso cref="Digivolve"/>
        public int DigivolutionCost
        {
            get
            {
                return _species.Rank * 20;
            }
        }

        /// <summary>
        /// Name of the Digimon with the Species name concatenated.
        /// </summary>
        public string LongName
        {
            get
            {
                string result = "";

                if (_name != _species.Name)
                {
                    result += _name + " the ";
                }
                result += _species.Name;

                return result;
            }
        }
        /// <summary>
        /// Single string of the Digimons stats for quick view and listing.
        /// </summary>
        /// <remarks>
        /// MaxHp Attack Defense Element.Initial
        /// </remarks>
        public string ShortStats
        {
            get
            {
                return _maxHp + " " + _attack + " " + _defense + " " + _species.Element.Initial;
            }
        }
        /// <summary>
        /// Full information about the Digimon.
        /// </summary>
        public string FullDetails
        {
            get
            {
                string result = "\n\t----------\n\t";

                if (_name != _species.Name)
                {
                    result += "Name: " + _name + "\n\t";
                }
                result += "Species: " + _species.Name + "\n\t";
                result += "Element: " + _species.Element.Name + "\n\t";
                result += "MaxHp: " + _maxHp + "\n\t";
                result += "Attack: " + _attack + "\n\t";
                result += "Defense: " + _defense + "\n\t";
                if (_victories > 0)
                {
                    result += "Victories: " + _victories + "\n\t";
                }
                if (this.Species.DigivolvesInto != null)
                {
                    result += "Digivolves Into: " + Species.DigivolvesInto.Name + "\n\t";
                    result += "Digivolution Cost: " + DigivolutionCost;
                }
                result += "\n";

                return result;
            }
        }

        /// <summary>
        /// Changes a Digimon into a new Species, increasing it's stats.
        /// </summary>
        /// <returns>
        /// bool: True if method was succesful
        /// </returns>
        /// <param name="player">
        /// The <see cref="Player"/> the Digimon belongs to
        /// and from who the <see cref="DigivolutionCost"/> should be subtracted from.
        /// </param>
        /// <seealso cref="Species.DigivolvesInto"/>
        public bool Digivolve(Player player)
        {
            Species? nextDigivolution = Species.DigivolvesInto;
            if (nextDigivolution == null)
            {
                return false;
            }
            if (_name == _species.Name)
            {
                _name = nextDigivolution.Name;
            }
            Random rnd = new Random();
            // digivolvedStat = currentStat + random(nextSpecies.Rank, 10) + 5 + nextSpecies.Rank
            _maxHp = _maxHp + rnd.Next(nextDigivolution.Rank, 10) + 5 + nextDigivolution.Rank;
            _attack = _attack + rnd.Next(nextDigivolution.Rank, 10) + 5 + nextDigivolution.Rank;
            _defense = _defense + rnd.Next(nextDigivolution.Rank, 10) + 5 + nextDigivolution.Rank;
            player.Energy -= this.DigivolutionCost;
            _species = nextDigivolution;

            return true;
        }
    }
}