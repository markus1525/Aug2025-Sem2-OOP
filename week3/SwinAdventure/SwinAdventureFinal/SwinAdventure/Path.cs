// Path.cs - Represents connections between locations
namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {
        private string _description;
        private Location _destination;

        public Path(string[] identifiers, string description, Location destination)
            : base(identifiers)
        {
            _description = description;
            _destination = destination;
        }

        public Location Destination
        {
            get { return _destination; }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}
