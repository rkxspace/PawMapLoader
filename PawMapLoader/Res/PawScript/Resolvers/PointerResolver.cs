namespace PawMapLoader.Res.PawScript.Resolvers
{
    public class PointerResolver
    {
        public static object ResolvePointer(string input, Interpreter interpreter)
        {
            if (input.StartsWith("(ptr)"))
            {
                return interpreter.RtMemory.Memory[interpreter.RtMemory.NamedPtr[input.Replace("(ptr)", string.Empty)]];
            }

            return interpreter.RtMemory.Memory[int.Parse(input)];
        }


        public static object ResolvePointerOrReturnOriginal(string input, Interpreter interpreter)
        {
            if (input.StartsWith("(ptr)"))
            {
                return interpreter.RtMemory.Memory[interpreter.RtMemory.NamedPtr[input.Replace("(ptr)", string.Empty)]];
            }

            return input;
        }

        public static int ResolvePointerAddress(string input, Interpreter interpreter)
        {
            if (input.StartsWith("(ptr)"))
            {
                return interpreter.RtMemory.NamedPtr[input.Replace("(ptr)", string.Empty)];
            }

            return int.Parse(input);
        }
    }
}