using System.Collections;
using MelonLoader;
using UnityEngine;

namespace PawMapLoader.Enum
{
    public class LevelDataProvider
    {
        public static void WaitForDataProvider()
        {
            MelonCoroutines.Start(ldpw());
            IEnumerator ldpw()
            {
                while (Il2CppGame.LevelDataProvider._instance == null)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                Init.InitMaps();
            }
        }
    }
}