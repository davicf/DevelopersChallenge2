using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Xayah.Finances.Domain.Common.Exception
{
    [Serializable]
    public class BusinessRuleException : System.Exception, IException
    {
        public IEnumerable<string> ErrorMessages { get; }

        public BusinessRuleException(string message) : base(message)
        {
            ErrorMessages = new List<string>() { message };
        }

        public BusinessRuleException(IEnumerable<string> messages) : base(string.Join(';', messages))
        {
            ErrorMessages = messages;
        }

        [ExcludeFromCodeCoverage]
        protected BusinessRuleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}