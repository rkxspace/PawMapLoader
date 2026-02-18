using System.Collections.Generic;
using Il2CppAudio;
using Il2CppDestructibles;
using Il2CppScoring;
using MelonLoader;
using UnityEngine;

namespace PawMapLoader.Res.Components
{
    [RegisterTypeInIl2Cpp]
    public class BuildingSetup : MonoBehaviour
    {
        public float Health = 0f;
        public List<GameObject> Sections = new List<GameObject>();

        void Awake()
        {
            var damageable = gameObject.AddComponent<Damageable>();
            var building = gameObject.AddComponent<Building>();
            var dmgeffectsplayer = gameObject.AddComponent<DamageEffectsPlayer>();
            var dmgtoscore = gameObject.AddComponent<DamageToScore>();
            var playsoundondamage = gameObject.AddComponent<PlaySoundOnDamage>();
            
            damageable.MaxHealth = Health;
            damageable.Health = Health;
            
            Il2CppSystem.Collections.Generic.List<Damageable> cdamageables = new Il2CppSystem.Collections.Generic.List<Damageable>();
            foreach (GameObject section in Sections)
            {
                var childDamageable = section.AddComponent<Damageable>();
                childDamageable.MaxHealth = Health/Sections.Count;
                childDamageable.Health = Health/Sections.Count;
                childDamageable.Parent = damageable;
                cdamageables.Add(childDamageable);
            }
            
            damageable._children = cdamageables;
            
            building.Damageable = damageable;
            building.DamageEffectsPlayer = dmgeffectsplayer;
            
        }
    }
}