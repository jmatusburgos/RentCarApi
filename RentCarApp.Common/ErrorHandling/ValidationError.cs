using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentCarApp.Common.ErrorHandling
{
    /// <summary>
    /// Implamentacion class for handling Errors
    /// </summary>
    public class ValidationError : List<KeyValuePair<string, string>>, IValidationError
    {
        #region Private Members

        private const string DefaultSeparator = "<br/>";

        #endregion

        /// <inheritdoc />
        public void Add(string key, string value)
        {
            var item = new KeyValuePair<string, string>(key, value);
            if (Contains(item))
                return;
            Add(item);
        }

        /// <inheritdoc />
        public void Add(IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                Add(message, message);
            }
        }

        /// <inheritdoc />
        public void Add(IEnumerable<(string Code, string message)> messages)
        {
            foreach ((string Code, string message) message in messages)
                Add(message.Code, message.message);
        }


        /// <inheritdoc />
        public IEnumerable<string> GetErrorMessages()
        => this.Select(x => x.Value);

        /// <inheritdoc />
        public string GetErrors(string separator = null)
        => string.Join(separator ?? DefaultSeparator, GetErrorMessages().ToArray());
    }
}
