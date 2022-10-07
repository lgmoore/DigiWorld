namespace DigiWorld
{
    public class InsectElement : Element
    {
        public InsectElement() : base("Insect")
        {
            _strengths.Add("Plant", Plant);
            _weaknesses.Add("Fire", Fire);
        }
    }
}