using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Shared
{
    public static class ReferenceUtil
    {
        public static void EnsureStaticReference<T>()
        {
            var dummy = typeof(T);

            if (dummy == null)
                throw new Exception("This code is used to ensure that the compiler will include assembly");
        }
    }
}
