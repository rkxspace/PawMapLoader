using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class MathClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cMath =
            new Dictionary<string, InstructionDelegate>
            {
                { "Float", Math.Float },
                { "Int", Math.Int },
                { "Vector2", Math.Vector2 },
                { "Vector3", Math.Vector3 },
                { "Vector4", Math.Vector4 },
                { "FloatAdd", Math.FloatAdd },
                { "FloatSub", Math.FloatSub },
                { "FloatMul", Math.FloatMul },
                { "FloatDiv", Math.FloatDiv },
                { "FloatMod", Math.FloatMod },
                { "IntAdd", Math.IntAdd },
                { "IntSub", Math.IntSub },
                { "IntMul", Math.IntMul },
                { "IntDiv", Math.IntDiv },
                { "IntMod", Math.IntMod }
            };
    }
}