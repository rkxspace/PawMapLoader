using System;
using System.Collections;
using System.Diagnostics;
using MelonLoader;
using UnityEngine;

namespace PawMapLoader.Res.Enum
{
    public class RestrictedWatcher
    {
        private double t = double.Epsilon;
        private readonly bool ds;
        private readonly bool ss;
        
        public RestrictedWatcher(double i)
        {
            ds = Store.PawScript.inversions;
            ss = Store.PawScript.PawScriptRestrictedClassesEnabled;
            MelonCoroutines.Start(Check());
            
            IEnumerator Check()
            {
                var s = new System.Random();
                var nd = s.NextDouble();
                double m;
                t = (i*t*(nd*100))%135020+1;
                m = t*(Store.PawScript.inversions==!Store.PawScript.PawScriptRestrictedClassesEnabled?1:0)*(ds == Store.PawScript.inversions?1:0)*(ss == Store.PawScript.PawScriptRestrictedClassesEnabled?1:0);
                while (true)
                {
                    if (m.CompareTo(t) == 0)
                    {
                        nd = s.NextDouble();
                        t = (t*(nd*100))%135020+1;
                        m = t*(Store.PawScript.inversions==!Store.PawScript.PawScriptRestrictedClassesEnabled?1:0)*(ds == Store.PawScript.inversions?1:0)*(ss == Store.PawScript.PawScriptRestrictedClassesEnabled?1:0);
                    }
                    else
                    {
                        MelonLogger.Error("Failure to validate authenticity of Restricted claw settings. We have killed the game to prevent further issues.\n### THIS SHOULD NEVER HAPPEN UNDER NORMAL OPERATION ###\nA mod may have tried to enable something that shouldn't be enabled. Please ensure all mods came from authentic sources, and review the source of each.");
                        Process.GetCurrentProcess().Kill();
                    }
                    
                    // Fuck you Il2Cpp.
                    yield return new WaitForEndOfFrame();
                }
                // ReSharper disable once IteratorNeverReturns
            }
        }
    }
}