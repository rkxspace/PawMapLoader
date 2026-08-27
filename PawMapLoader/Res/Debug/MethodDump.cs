using Exception = System.Exception;

namespace PawMapLoader.Res.Debug
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using Il2CppInterop.Runtime;
    using Il2CppSystem;
    using Il2CppSystem.Reflection;
    using Exception = Exception;
    using IntPtr = System.IntPtr;

    public unsafe class MethodDump
    {
        public static void Create()
        {
            StringBuilder strh_DumpText = new StringBuilder();
            strh_DumpText.AppendLine("=================== GAME DUMP ===================");
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                strh_DumpText.AppendLine($"\n\n[] {asm.GetName().Name} ===================\n");
                Type[] types;
                try
                {
                    types = asm.GetTypes();
                }
                catch
                {
                    continue;
                }

                foreach (Type type in types)
                {
                    IntPtr typeptr = IL2CPP.GetIl2CppClass(type.Assembly.FullName, type.Namespace, type.Name);
                    strh_DumpText.AppendLine($"|| {type.FullName} +=> {typeptr.ToInt64()}");

                    foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                                                                  BindingFlags.Static | BindingFlags.Instance |
                                                                  BindingFlags.DeclaredOnly))
                    {
                        try
                        {
                            IntPtr methodptr = method.MethodHandle.Value;

                            string tempstr = string.Join(", ",
                                method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                            strh_DumpText.AppendLine(
                                $"||==> {method.Name}({tempstr}) ==> ret {method.ReturnType.FullName}");
                        }
                        catch (Exception e)
                        {
                            strh_DumpText.AppendLine(
                                $"||==> {method.Name}(Unk) ==> ret Unk +=> Unk [error: {e.Message}]"
                            );
                        }
                    }
                }
            }

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "GameDump.txt"), strh_DumpText.ToString());
        }
    }
}