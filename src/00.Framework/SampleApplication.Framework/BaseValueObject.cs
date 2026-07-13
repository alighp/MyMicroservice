namespace SampleApplication.Framework
{
    public abstract class BaseValueObject
    {
        protected abstract IEnumerable<object?> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
                return false;

            var other = (BaseValueObject)obj;

            return GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        public static bool operator ==(
            BaseValueObject? left,
            BaseValueObject? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(
            BaseValueObject? left,
            BaseValueObject? right)
        {
            return !Equals(left, right);
        }
    }


}