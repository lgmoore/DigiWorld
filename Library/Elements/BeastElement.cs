namespace DigiWorld
{
    public class BeastElement : Element
    {
        public BeastElement() : base("Beast")
        {
            _strengths.Add("Fire", Fire);
            _weaknesses.Add("Water", Water);
            _weaknesses.Add("Insect", Insect);
        }
    }
}