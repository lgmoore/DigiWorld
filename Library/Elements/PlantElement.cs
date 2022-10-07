namespace DigiWorld
{
    public class PlantElement : Element
    {
        public PlantElement() : base("Plant")
        {
            _strengths.Add("Water", Water);
            _weaknesses.Add("Fire", Fire);
        }
    }
}