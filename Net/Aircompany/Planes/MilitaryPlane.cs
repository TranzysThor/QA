using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        private readonly MilitaryType _militaryType;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType militaryType)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _militaryType = militaryType;
        }

        public override bool Equals(object obj)
        {
            return obj is MilitaryPlane plane &&
                   base.Equals(obj) &&
                   _militaryType == plane._militaryType;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _militaryType.GetHashCode();
            return hashCode;
        }

        public MilitaryType GetPlaneType()
        {
            return _militaryType;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + _militaryType +
                    '}');
        }        
    }
}
