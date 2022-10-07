namespace DigiWorld
{
    public class FireElement : Element
    {
        public FireElement() : base("Fire")
        {
            _strengths.Add("Plant", Plant);
            _weaknesses.Add("Water", Water);
        }
    }
}