namespace DigiWorld
{
    /// <summary>
    /// Class <c>SpeciesLibrary</c> models the collection of all digimon Species.
    /// </summary>
    public class SpeciesLibrary
    {
        /// <summary>
        /// Instance variable <c>_filePath</c> points to the hardcoded location of species_library.csv.
        /// </summary>
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../Library", "species_library.csv");
        /// <summary>
        /// Instance variable <c>Library</c> is a Dictionary collection containing each species.
        /// </summary>
        public Dictionary<int, Species> Library = new Dictionary<int, Species>();
        /// <summary>
        /// Instance variable <c>_instance</c> stores a static instance of this class.
        /// </summary>
        /// <remarks>
        /// Static instance avoid re-inialising the library each time it's needed.
        /// </remarks>
        private static readonly SpeciesLibrary _instance = new SpeciesLibrary();

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeciesLibrary"/> class.
        /// </summary>
        /// <remarks>
        /// Reads the species_library.csv, creating a <see cref="Species"/> object with each line and storing
        /// them in the <see cref="Library"/>.
        /// </remarks>
        private SpeciesLibrary()
        {
            // Populate a Dictionary of all Speciess from a CSV file
            using (var reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] values = line.Split(',');

                        Element? element = FindElement(values[2]);
                        if (element == null)
                        {
                            throw new Exception("Abort. Element not found: " + values[2]);
                        }

                        // Read CSV data. Create a Species Object from each row
                        Library.Add(
                                int.Parse(values[0]),
                                new Species(
                                    // ID
                                    int.Parse(values[0]),
                                    // Name
                                    values[1],
                                    // Element
                                    element,
                                    // Rank
                                    int.Parse(values[3]),
                                    // Evolution
                                    values[4] != "" ? int.Parse(values[4]) : null,
                                    // MaxHp
                                    int.Parse(values[5]),
                                    // Attack
                                    int.Parse(values[6]),
                                    // Defense
                                    int.Parse(values[7])
                                )
                            );
                    }
                }
                reader.Close();
            }
        }

        /// <value>
        /// The <c>Instance</c> property represents the static instance of this class.
        /// </value>
        public static SpeciesLibrary Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Retrieves a Species by id from the Library.
        /// </summary>
        /// <param name="id">
        /// The <see cref="Species.ID"/> of the Species to retrieve.
        /// </param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the id can't be found in the Library.
        /// </exception>
        public Species GetSpecies(int id)
        {
            if (Library[id] == null)
            {
                throw new KeyNotFoundException();
            }
            return Library[id];
        }

        /// <summary>
        /// Get a random Species of Digimon.
        /// </summary>
        /// <param name="rank">
        /// The Rank of Digimon to generate. If null a random Rank will be used.
        /// </param>
        public Species GetRandomSpecies(int? rank)
        {
            Random randomGenerator = new Random();
            int id = randomGenerator.Next(1, Library.Count);
            Species Species = GetSpecies(id);

            // There may be a better way of retrieving Species of a specific rank
            if (rank != null)
            {
                while (Species.Rank != rank)
                {
                    id = randomGenerator.Next(1, Library.Count);
                    Species = GetSpecies(id);
                }
            }

            return Species;
        }

        /// <summary>
        /// Generates a new random Digimon.
        /// </summary>
        /// <param name="rank">
        /// The Rank of Digimon to generate. If null a random Rank will be used.
        /// </param>
        /// <seealso cref="SpeciesLibrary.GetRandomSpecies(int?)"/>
        public static Digimon GenerateRandomDigimon(int? rank)
        {
            Species species = SpeciesLibrary.Instance.GetRandomSpecies(rank);
            return species.GenerateDigimon();
        }

        /// <summary>
        /// Retrieves an Element by name
        /// </summary>
        /// <remarks>
        /// Used by the <see cref="Species"/> constructor to retrieve the <see cref="Element"/> object.
        /// </remarks>
        /// <param name="key">
        /// The name of the Element to find.
        /// </param>
        private Element? FindElement(string key)
        {
            switch (key)
            {
                case "Fire":
                    return Element.Fire;
                case "Water":
                    return Element.Water;
                case "Plant":
                    return Element.Plant;
                case "Insect":
                    return Element.Insect;
                case "Beast":
                    return Element.Beast;
                default:
                    return null;
            }
        }
    }
}