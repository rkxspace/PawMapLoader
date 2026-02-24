using MelonLoader;
using UnityEngine;

namespace PawMapLoader.Res.PawScript
{
    public class ComponentLogs
    {
        public static void UnsetComponent(GameObject go)
        {
            MelonLogger.Warning("[WARN] Unset Component on GameObject \"" + go.name + ".\"");
        }
    }
}