namespace PawMapLoader.Res.PawScript.Resolvers
{
    public class PointerResolver
    {
        public static object ResolvePointer(string input, Interpreter interpreter)
        {
            if (input.StartsWith("(ptr)"))
            {
                return interpreter.Memory[interpreter.NamedPtr[input.Replace("(ptr)", "")]];
            }

            return interpreter.Memory[int.Parse(input)];
        }


        public static object ResolvePointerOrReturnOriginal(string input, Interpreter interpreter)
        {
            if (input.StartsWith("(ptr)"))
            {
                return interpreter.Memory[interpreter.NamedPtr[input.Replace("(ptr)", "")]];
            }

            return input;
        }

        public static int ResolvePointerAddress(string input, Interpreter interpreter)
        {
            if (input.StartsWith("(ptr)"))
            {
                return interpreter.NamedPtr[input.Replace("(ptr)", "")];
            }

            return int.Parse(input);
        }
    }
}