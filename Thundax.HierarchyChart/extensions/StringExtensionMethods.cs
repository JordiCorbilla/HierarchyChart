using System;

namespace Thundax.HierarchyChart.extensions
{
    public static class StringExtensionMethods
    {
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search, StringComparison.Ordinal);
            if (pos < 0)
                return text;
            return string.Format("{0}{1}{2}", text.Substring(0, pos), replace, text.Substring(pos + search.Length));
        }

        public static string ReplaceLast(this string text, string search, string replace)
        {
            int place = text.LastIndexOf(search, StringComparison.Ordinal);
            if (place == -1)
                return text;
            return text.Remove(place, search.Length).Insert(place, replace);
        }
    }
}
