using System.Collections.Generic;

namespace Xayah.Finances.Domain.Common.Exception
{
    public interface IException
    {
        IEnumerable<string> ErrorMessages { get; }
    }
}