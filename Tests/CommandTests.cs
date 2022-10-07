namespace DigiWorld.Tests
{
    public class CommandTests
    {
        private SpeciesLibrary _library = SpeciesLibrary.Instance;
        private Player _player = new Player("Test Player");
        DigimonList _testList = new DigimonList();

        [SetUp]
        public void Setup()
        {
            Species Species1 = _library.GetSpecies(1);
            Species Species2 = _library.GetSpecies(2);
            Digimon digimon1 = Species1.GenerateDigimon();
            Digimon digimon2 = Species2.GenerateDigimon();

            _testList.Clear();
            _testList.Add(digimon1);
            _testList.Add(digimon2);
        }

        [Test]
        // Test finding a Digimon by name from a List
        public void TestFindDigimon()
        {
            Digimon? foundDigimon = _testList.FindDigimon("Sparkmon");
            Assert.NotNull(foundDigimon);
            if (foundDigimon != null)
            {
                Assert.IsTrue(foundDigimon.Species.ID == 1);
                Assert.IsTrue(foundDigimon.Name == "Sparkmon");
            }
        }
    }
}

