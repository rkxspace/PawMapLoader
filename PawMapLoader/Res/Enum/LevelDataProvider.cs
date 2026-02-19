using System.Collections;
using MelonLoader;
using UnityEngine;

namespace PawMapLoader.Res.Enum
{
    public class LevelDataProvider
    {
        public static void WaitForDataProvider()
        {
            MelonLogger.Msg("Waiting for data provider...");
            MelonCoroutines.Start(ldpw());
            IEnumerator ldpw()
            {
                while (Il2CppGame.LevelDataProvider._instance == null)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                MelonLogger.Msg("Level data provider found.");
                Init.InitMaps();
            }
        }
    }
}