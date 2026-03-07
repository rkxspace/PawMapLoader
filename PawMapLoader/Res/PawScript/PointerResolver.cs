namespace PawMapLoader.Res.PawScript
{
    public class PointerResolver
    {
        public static object ResolvePointer(string input, Interpreter interpreter)
        {
            if (input.StartsWith("(ptr)"))
            {
                return interpreter.Memory[interpreter.NamedPtr[input.Replace("(ptr)", "")]];
            }

            return input;
        }
    }
}