using System;
using Il2CppDestructibles;
using Il2CppInterop.Runtime;
using MelonLoader;
using PawMapLoader.Res.PawScript;
using UnityEngine;

namespace PawMapLoader.Res.Components
{
    /// <summary>
    /// Creates a damageable object that triggers its own PawScript when damaged.
    /// These do not share main PawScript memory. The attached object will hide or destroy based on mode.
    /// </summary>
    [RegisterTypeInIl2Cpp]
    public class PawScriptDamageable : MonoBehaviour
    {
        public bool destroyOnNoHealth;
        public float health;
        public int eventScriptIndex;

        void Awake()
        {
            if (health == -1f | eventScriptIndex == -1) {ComponentLogs.UnsetComponent(gameObject);
                return;
            }
            var dmgble = gameObject.AddComponent<Damageable>();
            dmgble._health = new Health() {Max = health, Value = health};
            IntPtr ptr = IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DamageEvent>.NativeClassPtr);
            dmgble.enabled = true;
        }

        void RunRegisteredOnEvent()
        {
            
        }
    }
}