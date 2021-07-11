using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Xayah.Finances.Domain.Common.Exception
{
    [Serializable]
    public class UnauthorizedAccessException : System.Exception, IException
    {
        public IEnumerable<string> ErrorMessages { get; }

        public UnauthorizedAccessException(string message) : base(message)
        {
            ErrorMessages = new List<string>() { message };
        }

        public UnauthorizedAccessException(IEnumerable<string> messages) : base(string.Join(';', messages))
        {
            ErrorMessages = messages;
        }

        [ExcludeFromCodeCoverage]
        protected UnauthorizedAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}