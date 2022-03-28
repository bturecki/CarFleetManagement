namespace DataLibrary.Models.Entities
{
    internal class Car : Abstract.ICar
    {
        public string Make { get; internal set; }
        public string Model { get; internal set; }
        public int YearOfProduction { get; internal set; }
        public int Milage { get; internal set; }
        public int CarId { get; internal set; }
    }
}
