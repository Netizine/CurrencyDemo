using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyDemo
{
    /// <summary>
    /// BuilderException Class.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class BuilderException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderException"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public BuilderException(Dictionary<string, string> errors) : this(null, errors)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errors">The errors.</param>
        public BuilderException(string message, Dictionary<string, string> errors) : base(GetErrorMessage(message, errors))
        {
            Errors = errors;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>System.String.</returns>
        private static string GetErrorMessage(string message, Dictionary<string, string> errors)
        {
            if (message != null)
                return message;
            var sb = new StringBuilder();
            sb.AppendLine("Error building object. The following properties have errors:");
            foreach (var error in errors)
                sb.AppendLine($"   {error.Key}: {error.Value}");

            return sb.ToString();
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public Dictionary<string, string> Errors { get; }
    }
}
