using System.IO;
using System.Linq;
using System.Text;
using Il2CppSystem;
using Il2CppSystem.Reflection;
using Exception = System.Exception;

namespace PawMapLoader.Res.Debug
{
    public class MethodDump
    {
        public static void Create()
        {
            var strh_DumpText = new StringBuilder();
            strh_DumpText.AppendLine("=================== GAME DUMP ===================");
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                strh_DumpText.AppendLine($"[] {asm.GetName().Name} ===================");
                Type[] types;
                try {types = asm.GetTypes();} catch { continue; }

                foreach (var type in types)
                {
                    strh_DumpText.AppendLine($"|| {type.Name}");

                    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                                                           BindingFlags.Static | BindingFlags.Instance |
                                                           BindingFlags.DeclaredOnly))
                    {
                        try
                        {
                            var tempstr = string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                            strh_DumpText.AppendLine($"||==> {method.Name}({tempstr}) ==> ret {method.ReturnType.Name}");
                        }
                        catch (Exception e)
                        {
                            strh_DumpText.AppendLine($"||==> {method.Name}(Unk) ==> ret Unk [error: {e.Message}]");
                        }                    }
                }
            }
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "GameDump.txt"), strh_DumpText.ToString());
        }
    }
}