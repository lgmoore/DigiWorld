namespace DigiWorld
{
    /// <summary>
    /// Class <c>Globals</c> stores re-occuring objects that are used thoughout the app.
    /// </summary>
    public class Globals
    {
        private static Shop? _digimonStore;
        private static Player? _user;

        /// <value>
        /// The <c>DigimonStore</c> property represents a static instance of the <see cref="Shop"/> class.
        /// </value>
        public static Shop DigimonStore
        {
            get
            {
                if (_digimonStore == null)
                {
                    _digimonStore = new Shop();
                }
                return _digimonStore;
            }
            set
            {
                _digimonStore = value;
            }
        }
        /// <value>
        /// The <c>User</c> property represents a static instance of the <see cref="Player"/> class.
        /// </value>
        public static Player User
        {
            get
            {
                if (_user == null)
                {
                    // This shouldnt occur but needed for constructor
                    _user = new Player("New Player");
                }
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
