using System;

namespace Timesheets.Infrastructure.Extensions
{
    public static class ObjectExtenstions
    {
        public static void EnsureNotNull(this object @object, string name)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(name, $"Parameter {name} cannot be null.");
            }
        }
    }
}