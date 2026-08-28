namespace PawMapLoader.Res.Enum
{
    using System.Collections;
    using GUI;
    using MelonLoader;
    using UnityEngine;

    public class MenuPersistent
    {
        public static void Rescanner()
        {
            MelonCoroutines.Start(rscn());
            IEnumerator rscn()
            {
                while (EditorEntryButton.MainMenuButton())
                {
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }
}