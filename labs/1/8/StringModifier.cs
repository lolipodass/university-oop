namespace RunProgram
{

    public class StringModifier
    {
        public static string DeleteDots(string str) => str.Replace(".", "");
        public static string InsertDots(string str) => str.Replace(' ', '.');
        public static string Upper(string str) => str.ToUpper();
        public static string Lower(string str) => str.ToLower();
        public static string Reverse(string str) => str.ToArray<char>()?.Reverse()?.ToString() ?? "null";

        public static string DelegateFunc(string str, Func<string, string> fun)
        {
            return fun(str);
        }
    }

}