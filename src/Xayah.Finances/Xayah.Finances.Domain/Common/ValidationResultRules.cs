using System.Collections.Generic;

namespace Xayah.Finances.Domain.Common
{
    public class ValidationResultRules
    {
        public bool IsValid { get; internal set; }
        public IEnumerable<string> Errors { get; internal set; }
    }
}