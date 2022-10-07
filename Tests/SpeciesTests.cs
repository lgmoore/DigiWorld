namespace DigiWorld.Tests
{
    public class SpeciesTests
    {
        private SpeciesLibrary _library = SpeciesLibrary.Instance;

        [Test]
        // Test generating a new Digimon
        public void TestGenerateDigimon()
        {
            Species species = _library.GetSpecies(1);
            Assert.IsInstanceOf<Species>(species);

            var digimon = species.GenerateDigimon();
            Assert.IsInstanceOf<Digimon>(digimon);
            Assert.IsTrue(digimon.Species.ID == 1);
        }

        [Test]
        // Test elemental weaknesses detect correctly
        public void TestElementalWeakness()
        {
            Species Sparkmon = _library.GetSpecies(1);
            Species Sproutmon = _library.GetSpecies(9);

            Assert.IsTrue(Sproutmon.Element.Weaknesses.ContainsKey(Sparkmon.Element.Name));
        }

        [Test]
        // Test elemental strengths detect correctly
        public void TestElementalStrength()
        {
            Species Sparkmon = _library.GetSpecies(1);
            Species Sproutmon = _library.GetSpecies(9);

            Assert.IsTrue(Sparkmon.Element.Strengths.ContainsKey(Sproutmon.Element.Name));
        }
    }
}

