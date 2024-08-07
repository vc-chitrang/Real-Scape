public static class StringUtility { 

    public static string ToTitleCase(string str) {
        return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str);
    }

    public static void RemoveString(string removeString, ref string sourceString) {
        sourceString = sourceString.Replace(removeString, string.Empty);
    }
}