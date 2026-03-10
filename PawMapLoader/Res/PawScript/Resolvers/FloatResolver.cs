namespace PawMapLoader.Res.PawScript.Resolvers
{
    public class FloatResolver
    {
        public static float ResolveFloat(string input)
        {
            if (input.StartsWith("(float)"))
            {
                return float.Parse(input.Replace("(float)", ""));
            }

            return float.Parse(input);
        }
    }
}