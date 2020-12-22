using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Common.ErrorHandling
{
    public interface IValidationError : IList<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Add Error of Validation
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(string key, string value);

        /// <summary>
        /// Get Errors and return string splitter for a separator 
        /// for default is <br>
        /// </summary>
        /// <returns></returns>
        string GetErrors(string separator = null);

        /// <summary>
        /// Get List of Errors
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetErrorMessages();

        /// <summary>
        /// Add a Error List
        /// </summary>
        /// <param name="messages"></param>
        void Add(IEnumerable<string> messages);

        /// <summary>
        /// Add a Error List from a Ienumerable of tuples
        /// </summary>
        /// <param name="messages"></param>
        void Add(IEnumerable<(string Code, string message)> messages);
    }
}
