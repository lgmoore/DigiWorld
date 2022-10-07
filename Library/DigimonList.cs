namespace DigiWorld
{
    /// <summary>
    /// Class <c>DigimonList</c> models a List of Digimon.
    /// </summary>
    public class DigimonList
    {
        /// <summary>
        /// Instance variable <c>_list</c> is a List collection of Digimon.
        /// </summary>
        private List<Digimon> _list = new List<Digimon>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DigimonList"/> class.
        /// </summary>
        public DigimonList()
        {
        }

        /// <value>
        /// The <c>List</c> property represents a List of Digimon.
        /// </value>
        /// <remarks>
        /// The <see cref="List"/> is a <see langword="List"/> of <see cref="Digimon"/>.
        /// </remarks>
        public List<Digimon> List
        {
            get
            {
                return _list;
            }
        }

        /// <summary>
        /// Add a <see cref="Digimon"/> to the <see cref="List"/>.
        /// </summary>
        /// <param name="newDigimon">
        /// The <see cref="Digimon"/> to add to the list.
        /// </param>
        public void Add(Digimon newDigimon)
        {
            _list.Add(newDigimon);
        }

        /// <summary>
        /// Remove a <see cref="Digimon"/> from the <see cref="List"/>.
        /// </summary>
        /// <param name="digimon">
        /// The <see cref="Digimon"/> to remove from the list.
        /// </param>
        public void Remove(Digimon digimon)
        {
            _list.Remove(digimon);
        }

        /// <summary>
        /// Clears all <see cref="Digimon"/> from the <see cref="List"/>.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Prints out the short stats of each <see cref="Digimon"/> in the <see cref="List"/>.
        /// </summary>
        /// <returns>
        /// string: A formatted list of all Digimon in the List in shorthand format.
        /// </returns>
        public string PrintList()
        {
            string text = "";
            foreach (Digimon digimon in this.List)
            {
                text += "\n\t" + digimon.Cost + "C" + " - " + digimon.LongName + " " + digimon.ShortStats;
            }
            return text;
        }

        /// <summary>
        /// Searches the List for a <see cref="Digimon"/> by <see cref="Digimon.Name"/>.<br />
        /// Prompts the user if more then one <see cref="Digimon"/> is found.
        /// </summary>
        /// <returns>
        /// Digimon: The Digimon found. Returns null if none found.
        /// </returns>
        /// <param name="key">
        /// The <see cref="Digimon.Name"/> to search for.
        /// </param>
        public Digimon? FindDigimon(string key)
        {
            List<Digimon> foundDigimon = this.List.Where(digimon => digimon.Name.Equals(key)).ToList();

            if (foundDigimon.Count > 1)
            {
                // Multiple Digimon found. Prompt the user to select one.
                while (true)
                {
                    Console.WriteLine("Which " + key + "?");
                    foreach (Digimon d in foundDigimon)
                    {
                        Console.WriteLine("#" + (foundDigimon.IndexOf(d) + 1) + " - " + d.Name + " " + d.ShortStats);
                    }
                    string? input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        continue;
                    }
                    if (input == "exit" || input == "cancel")
                    {
                        return null;
                    }
                    input = input.Replace("#", string.Empty);
                    int i = int.Parse(input);
                    if (foundDigimon[i - 1] == null)
                    {
                        Console.WriteLine("Unknown input");
                        continue;
                    }
                    else
                    {
                        return foundDigimon[i - 1];
                    }
                }
            }
            else
            {
                if (foundDigimon.Count == 1)
                {
                    // One Digimon found. Return it.
                    return foundDigimon.First();
                }
                // No Digimon found.
                return null;
            }
        }
    }
}