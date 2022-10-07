namespace DigiWorld.Tests
{
    public class DigimonTests
    {
        private SpeciesLibrary _library = SpeciesLibrary.Instance;
        private Player _player = new Player("Test Player");

        [Test]
        // Test digivolving a Digimon
        public void TestDigivolution()
        {
            Species Species = _library.GetSpecies(1);
            Assert.IsInstanceOf<Species>(Species);

            var digimon = Species.GenerateDigimon();
            // Test we have a Digimon
            Assert.IsInstanceOf<Digimon>(digimon);

            // Digivolve!
            digimon.Digivolve(_player);

            // Test the Digimon changed form 
            Assert.IsTrue(digimon.Species.ID == 2);
            Assert.IsTrue(digimon.Name == "Flamemon");

            // Test energy was subtracted from the Player
            Assert.IsTrue(_player.Energy == (100 - 20));
        }
    }
}

