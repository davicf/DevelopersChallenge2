using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Xayah.Finances.Domain.Common.Exception
{
    [Serializable]
    public class ResourceNotFoundException : System.Exception, IException
    {
        public IEnumerable<string> ErrorMessages { get; }

        public ResourceNotFoundException(string message) : base(message)
        {
            ErrorMessages = new List<string>() { message };
        }

        public ResourceNotFoundException(IEnumerable<string> messages) : base(string.Join(';', messages))
        {
            ErrorMessages = messages;
        }

        [ExcludeFromCodeCoverage]
        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}