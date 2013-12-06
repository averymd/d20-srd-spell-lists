using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel
{
    public static class BindingListExtensions
    {
        public static void AddRange<T>(this BindingList<T> collection, List<T> elements) {
            foreach (var e in elements)
            {
                collection.Add(e);
            }
        }

        public static void ReloadFromList<T>(this BindingList<T> collection, List<T> list)
        {
            collection.Clear();
            collection.AddRange(list);
        }

        public static void Sort<T>(this BindingList<T> collection, IComparer<T> comparer)
        {
            List<T> list = collection.ToList();
            list.Sort(comparer);
            collection.ReloadFromList(list);
        }
    }
}
