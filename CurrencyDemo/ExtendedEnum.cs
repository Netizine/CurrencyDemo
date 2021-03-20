using System;

namespace CurrencyDemo
{
    /// <summary>
    /// ExtendedEnum Abstract Class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ExtendedEnum<T> where T : Enum
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; }
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; }
        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <value>The filter.</value>
        public T Filter { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedEnum{T}"/> class.
        /// </summary>
        protected ExtendedEnum()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedEnum{T}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="filter">The filter.</param>
        protected ExtendedEnum(int id, string name, object value, T filter)
        {
            Id = id;
            Name = name;
            Value = value;
            Filter = filter;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Compares the objects.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Int32.</returns>
        public int CompareTo(object obj)
        {
            return Id.CompareTo(((ExtendedEnum<T>)obj).Id);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is ExtendedEnum<T> enumeration &&
                   Name == enumeration.Name &&
                   Id == enumeration.Id &&
                   enumeration.Filter.Equals(Filter);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id, Filter);
        }
    }
}
