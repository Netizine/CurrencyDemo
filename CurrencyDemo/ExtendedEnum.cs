using System;

namespace CurrencyDemo
{
    public abstract class ExtendedEnum<T> where T : Enum
    {
        public string Name { get; }
        public int Id { get; }
        public object Value { get; }
        public T Filter { get; }

        protected ExtendedEnum()
        {
        }

        protected ExtendedEnum(int id, string name, object value, T filter)
        {
            Id = id;
            Name = name;
            Value = value;
            Filter = filter;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            return Id.CompareTo(((ExtendedEnum<T>)obj).Id);
        }

        public override bool Equals(object obj)
        {
            return obj is ExtendedEnum<T> enumeration &&
                   Name == enumeration.Name &&
                   Id == enumeration.Id &&
                   enumeration.Filter.Equals(Filter);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id, Filter);
        }
    }
}
