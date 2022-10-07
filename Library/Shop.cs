namespace DigiWorld
{
    /// <summary>
    /// Class <c>Shop</c> models a store where the Player can purchase Digimon.
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// Instance variable <c>_shopList</c> is a List collection of Digimon.
        /// </summary>
        /// <seealso cref="ShopList"/>
        /// <seealso cref="DigimonList"/>
        private DigimonList _shopList = new DigimonList();

        /// <summary>
        /// Initializes a new instance of the <see cref="Shop"/> class.
        /// </summary>
        public Shop()
        {
            this.GenerateNewShopList();
        }

        /// <value>
        /// The <c>ShopList</c> property represents the List of Digimon available in the Shop.
        /// </value>
        /// <remarks>
        /// The <see cref="ShopList"/> is a <see langword="List"/> of <see cref="Digimon"/>.
        /// </remarks>
        public DigimonList ShopList
        {
            get
            {
                return _shopList;
            }
        }

        /// <summary>
        /// Generates a new List of five Digimon.
        /// </summary>
        public void GenerateNewShopList()
        {
            _shopList.Clear();
            _shopList.Add(SpeciesLibrary.GenerateRandomDigimon(1));
            _shopList.Add(SpeciesLibrary.GenerateRandomDigimon(1));
            _shopList.Add(SpeciesLibrary.GenerateRandomDigimon(1));
            _shopList.Add(SpeciesLibrary.GenerateRandomDigimon(2));
            _shopList.Add(SpeciesLibrary.GenerateRandomDigimon(new Random().Next(2,3)));
        }

        /// <summary>
        /// Prints out the short stats of each Digimon available in the Shop.
        /// </summary>
        /// <returns>
        /// string: The list of available Digimon.
        /// </returns>
        /// <seealso cref="DigimonList.PrintList"/>
        public string PrintShopList()
        {
            string text = "\t -- Available Digimon -- \n";
            text += _shopList.PrintList();
            text += "\n\n\t------------------------\n";
            return text;
        }
    }
}