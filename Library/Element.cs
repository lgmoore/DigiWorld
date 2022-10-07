namespace DigiWorld
{
    /// <summary>
    /// Class <c>Element</c> models a digimon category.
    /// </summary>
    public abstract class Element
    {
        /// <summary>
        /// Instance variable <c>_name</c> represents the Elements name.
        /// </summary>
        /// <seealso cref="Name"/>
        private string _name;
        /// <summary>
        /// Instance variable <c>_strengths</c> collects the Elements this Element is strong against.
        /// </summary>
        /// <seealso cref="Strengths"/>
        protected Dictionary<string, Element> _strengths = new Dictionary<string, Element>();
        /// <summary>
        /// Instance variable <c>_weaknesses</c> collects the Elements this Element is weak against.
        /// </summary>
        /// <seealso cref="Weaknesses"/>
        protected Dictionary<string, Element> _weaknesses = new Dictionary<string, Element>();

        // Static instances of each element to avoid infinite reference loops inside _strengths and _weaknesses.
        public static readonly Element Fire = new FireElement();
        public static readonly Element Water = new WaterElement();
        public static readonly Element Plant = new PlantElement();
        public static readonly Element Insect = new InsectElement();
        public static readonly Element Beast = new BeastElement();

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="name">
        /// The <see cref="Name"/> of the Element to construct.
        /// </param>
        public Element(string name)
        {
            _name = name;
        }

        /// <value>
        /// The <c>Name</c> property represents a name for this Element.
        /// </value>
        /// <remarks>
        /// The <see cref="Name"/> is a <see langword="string"/> used to identify the Element.
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
        /// The first char of this Element.
        /// </value>
        /// <remarks>
        /// The <see cref="Initial"/> is a <see langword="char"/>.
        /// </remarks>
        /// <seealso cref="Digimon.ShortStats"/>
        public char Initial
        {
            get
            {
                return _name[0];
            }
        }

        /// <value>
        /// The Elements this Element of Digimon is strong against.
        /// </value>
        /// <remarks>
        /// <see cref="Strengths"/> is a <see langword="Dictionary"/>.<br />
        /// While defending an attack, if the attackers element is in this list, the defender gains a bonus.
        /// </remarks>
        /// <seealso cref="Battle.ResolveAttack(Digimon, Digimon)"/>
        public Dictionary<string, Element> Strengths
        {
            get
            {
                return _strengths;
            }
        }
        /// <value>
        /// The Elements this Element of Digimon is weak against.
        /// </value>
        /// <remarks>
        /// <see cref="Weaknesses"/> is a <see langword="Dictionary"/>.<br />
        /// While defending an attack, if the attackers element is in this list, the attacker gains a bonus.
        /// </remarks>
        /// <seealso cref="Battle.ResolveAttack(Digimon, Digimon)"/>
        public Dictionary<string, Element> Weaknesses
        {
            get
            {
                return _weaknesses;
            }
        }
    }
}