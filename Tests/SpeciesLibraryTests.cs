namespace DigiWorld.Tests
{
    public class SpeciesLibraryTests
    {
        private SpeciesLibrary _library = SpeciesLibrary.Instance;

        [Test]
        // Test getting a Species from the Library
        public void TestGetSpecies()
        {
            int id = 1;
            Species Species1 = _library.Library[1];

            Species Species = _library.GetSpecies(id);
            Assert.IsInstanceOf<Species>(Species);
            Assert.That(Species, Is.SameAs(Species1));
        }

        [Test]
        // Test getting a random Species
        public void TestGetRandomSpecies()
        {
            Assert.IsInstanceOf<Species>(_library.GetRandomSpecies(null));
        }

        [TestCase(1)]
        [TestCase(4)]
        // Test getting a Species of a specific Rank
        public void TestGetRandomSpeciesOfRank(int rank)
        {
            Species Species = _library.GetRandomSpecies(rank);
            Assert.IsInstanceOf<Species>(Species);
            Assert.IsTrue(rank == Species.Rank);
        }

        [Test]
        // Test getting a random Digimon
        public void TestGetRandomDigimon()
        {
            Assert.IsInstanceOf<Digimon>(SpeciesLibrary.GenerateRandomDigimon(null));
        }
    }
}

