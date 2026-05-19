using Il2CppDestructibles;
using UnityEngine;

namespace PawMapLoader.Res.PawScript.Events
{
    public class DamageEvent
    {
        public Damage damage;
        public Damageable damageable;
        public DamageEventParams eventParams;
        public GameObject source;

        DamageEvent(GameObject sourceGameObject, Damageable dgb, Damage dmg, DamageEventParams degparam)
        {
            source = sourceGameObject;
            damageable = dgb;
            damage = dmg;
            eventParams = degparam;
        }
    }
}