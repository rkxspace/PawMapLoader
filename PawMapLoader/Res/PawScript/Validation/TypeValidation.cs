namespace PawMapLoader.Res.PawScript.Validation
{
    public class TypeValidation
    {
        public static bool Validate<T>(object mem)
        {
            return mem is T;
        }
    }
}