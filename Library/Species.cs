namespace DigiWorld
{
    /// <summary>
    /// Class <c>Species</c> models the broad characteristics of a type/species/breed of digimon creature.
    /// </summary>
    public class Species
    {
        /// <summary>
        /// Instance variable <c>_id</c> is a primary key for this Species.
        /// </summary>
        /// <seealso cref="ID"/>
        private int _id;
        /// <summary>
        /// Instance variable <c>_name</c> represents the Species name.
        /// </summary>
        /// <seealso cref="Name"/>
        private string _name;
        /// <summary>
        /// Instance variable <c>_element</c> represents the Species category.
        /// </summary>
        /// <seealso cref="Element"/>
        private Element _element;
        /// <summary>
        /// Instance variable <c>_rank</c> represents the Species level.
        /// </summary>
        /// <seealso cref="Rank"/>
        private int _rank = 1;
        /// <summary>
        /// Instance variable <c>_digivolvesInto</c> is the id of the Species into which this Species of Digimon transforms into.
        /// </summary>
        /// <seealso cref="DigivolvesInto"/>
        private int? _digivolvesInto;
        /// <summary>
        /// Instance variable <c>_baseHp</c> represents the lowest amount of health a Digimon of this Species can have.
        /// </summary>
        /// <seealso cref="BaseHp"/>
        private int _baseHp;
        /// <summary>
        /// Instance variable <c>_baseAttack</c> represents the lowest amount of attack power a Digimon of this Species can have.
        /// </summary>
        /// <seealso cref="BaseAttack"/>
        private int _baseAttack;
        /// <summary>
        /// Instance variable <c>_baseDefense</c> represents the lowest amount of defensive power a Digimon of this Species can have.
        /// </summary>
        /// <seealso cref="BaseDefense"/>
        private int _baseDefense;

        /// <summary>
        /// Initializes a new instance of the <see cref="Species"/> class.
        /// </summary>
        /// <seealso cref="SpeciesLibrary"/>
        public Species(int id, string name, Element element, int rank, int? digivolvesInto, int hp, int attack, int defense)
        {
            _id = id;
            _name = name;
            _element = element;
            _rank = rank;
            _digivolvesInto = digivolvesInto;
            _baseHp = hp;
            _baseAttack = attack;
            _baseDefense = defense;
        }

        /// <value>
        /// The <c>ID</c> property represents an identifying number for this Species.
        /// </value>
        /// <remarks>
        /// The <see cref="ID"/> is a <see langword="int"/> used to identify the Species.<br />
        /// Used by <see cref="DigivolvesInto"/> to identify the next Species to digivolve into.
        /// </remarks>
        /// <seealso cref="Digimon.Digivolve(Player)"/>
        public int ID
        {
            get
            {
                return _id;
            }
        }
        /// <value>
        /// The <c>Name</c> property represents a name for this Species.
        /// </value>
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
        /// The <c>Element</c> property represents a category for this Species.
        /// </value>
        /// <remarks>
        /// The <see cref="Element"/> is a <see langword="object"/> of type <see cref="DigiWorld.Element"/>.<br />
        /// It is used in <see cref="Battle"/> to determine bonuses to attack and defense.
        /// </remarks>
        /// <seealso cref="Battle.ResolveAttack(Digimon, Digimon)"/>
        public Element Element
        {
            get
            {
                return _element;
            }
        }
        /// <value>
        /// The <c>Rank</c> property represents the level of this Species.
        /// </value>
        /// <remarks>
        /// <see cref="Rank"/> is a <see langword="int"/> used in calculating <see cref="Digimon"/> statistics.
        /// </remarks>
        /// <seealso cref="Digimon.Digimon(Species)"/>
        /// <seealso cref="Digimon.Digivolve(Player)"/>
        public int Rank
        {
            get
            {
                return _rank;
            }
        }
        /// <value>
        /// The <c>BaseHp</c> property represents the floor amount of HP for a Digimon of this Species.
        /// </value>
        /// <remarks>
        /// <see cref="BaseHp"/> is a <see langword="int"/> used in calculating the <see cref="Digimon.MaxHp"/> of a <see cref="Digimon"/>.
        /// </remarks>
        /// <seealso cref="Digimon.Digimon(Species)"/>
        public int BaseHp
        {
            get
            {
                return _baseHp;
            }
        }
        /// <value>
        /// The <c>BaseAttack</c> property represents the floor attack power for a Digimon of this Species.
        /// </value>
        /// <remarks>
        /// <see cref="BaseAttack"/> is a <see langword="int"/> used in calculating the <see cref="Digimon.Attack"/> of a <see cref="Digimon"/>.
        /// </remarks>
        /// <seealso cref="Digimon.Digimon(Species)"/>
        public int BaseAttack
        {
            get
            {
                return _baseAttack;
            }
        }
        /// <value>
        /// The <c>BaseDefense</c> property represents the floor defensive power for a Digimon of this Species.
        /// </value>
        /// <remarks>
        /// <see cref="BaseDefense"/> is a <see langword="int"/> used in calculating the <see cref="Digimon.Defense"/> of a <see cref="Digimon"/>.
        /// </remarks>
        /// <seealso cref="Digimon.Digimon(Species)"/>
        public int BaseDefense
        {
            get
            {
                return _baseDefense;
            }
        }
        /// <value>
        /// The <c>DigivolvesInto</c> property represents the Species Digimon of this Species digivolve into.
        /// </value>
        /// <remarks>
        /// <see cref="DigivolvesInto"/> is a <see langword="object"/> of type <see cref="DigiWorld.Species"/>.<br />
        /// If null this Species cannot digivolve.
        /// </remarks>
        /// <seealso cref="Digimon.Digivolve(Player)"/>
        public Species? DigivolvesInto
        {
            get
            {
                if (_digivolvesInto == null) {
                    return null;
                }
                return SpeciesLibrary.Instance.GetSpecies(_digivolvesInto.Value);
            }
        }

        /// <summary>
        /// Simple method to generate a new Digimon of this Species.
        /// </summary>
        /// <returns>
        /// Digimon: A digimon of this Species
        /// </returns>
        public Digimon GenerateDigimon()
        {
            return new Digimon(this);
        }
    }
}