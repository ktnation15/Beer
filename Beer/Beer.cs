using System.Diagnostics;

namespace Beer
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Abv { get; set; }

        public override string ToString() =>
            $"{Id} {Name} {Abv}";
        public void ValidateName()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("Name is null");
            }
            if (Name.Length < 3)
            {
                throw new ArgumentException("Name must be at least 3 characters long");
            }
        }

        public void ValidateAbv()
        {
            if (Abv < 0 || Abv > 67)
            {
                throw new ArgumentOutOfRangeException("ABV must be between 0 and 67.");
            }
        }
    }
}
