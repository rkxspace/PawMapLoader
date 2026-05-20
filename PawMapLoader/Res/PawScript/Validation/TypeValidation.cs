using System;

namespace PawMapLoader.Res.PawScript.Validation
{
    public class TypeValidation
    {
        public static void Validate<T>(object mem)
        {
            if (!(mem is T)) throw new ArgumentException("Invalid type passed.");
        }
    }
}