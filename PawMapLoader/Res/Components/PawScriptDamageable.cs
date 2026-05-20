using System;
using Il2CppDestructibles;
using Il2CppInterop.Runtime;
using MelonLoader;
using PawMapLoader.Res.PawScript;
using UnityEngine;
using DamageEvent = PawMapLoader.Res.PawScript.Events.DamageEvent;

namespace PawMapLoader.Res.Components
{
    /// <summary>
    /// Creates a damageable object that triggers its own PawScript when damaged.
    /// The attached object will hide or destroy based on mode.
    /// </summary>
    [RegisterTypeInIl2Cpp]
    public class PawScriptDamageable : MonoBehaviour
    {
        public bool destroyOnNoHealth = true;
        public float health = -1;
        public string eventScriptName = string.Empty;

        void Awake()
        {
            try
            {
                if (health == -1f || eventScriptName == string.Empty)
                {
                    ComponentLogs.UnsetComponent(gameObject);
                    return;
                }

                var dmgble = gameObject.AddComponent<Damageable>();
                dmgble._health = new Health { Max = health, Value = health };
                dmgble.enabled = true;
                dmgble.OnDamage =
                    (Action<Damageable, Damage, DamageEventParams>)
                    ((dgb, dmg, degparam) =>
                    {
                        PawScriptRegister.Start(eventScriptName, new DamageEvent
                        {
                            damage = dmg,
                            damageable = dgb,
                            eventParams = degparam,
                            source = gameObject
                        });
                    });
            }
            catch (Exception e)
            {
                MelonLogger.Error($"PawScriptDamageable component on {gameObject.name} encountered an error.", e);
                ErrorReporter.Report(e);
            }
        }
    }
}