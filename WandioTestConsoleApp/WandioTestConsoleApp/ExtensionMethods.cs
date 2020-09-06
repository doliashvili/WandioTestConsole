using System;
using System.Collections.Generic;
using System.Text;

namespace WandioTestConsoleApp
{
    public static class ExtensionMethods
    {
        public static T ThisDoesntMakeAnySense<T>(this IEnumerable<T> source,Func<T,bool> predicate, Func<T> func) 
        {
            if (source == null)
                throw new ArgumentNullException("source is null");

            if (predicate == null)
                throw new ArgumentNullException("predicate is null");

            if (func == null)
                throw new ArgumentNullException("func is null");


            foreach (var item in source)
            {
                if (predicate(item))
                    return default;
            }

            return func();
        }

    }
}
