namespace DigiWorld
{
    public class WaterElement : Element
    {
        public WaterElement() : base("Water")
        {
            _strengths.Add("Fire", Fire);
            _weaknesses.Add("Plant", Plant);
        }
    }
}