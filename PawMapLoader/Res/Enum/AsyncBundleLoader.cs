using System;
using System.Collections;
using Il2CppGame;
using Il2CppSystem.IO;
using Il2CppUI;
using MelonLoader;
using UnityEngine;

namespace PawMapLoader.Res.Enum
{
    public class AsyncBundleLoader
    {
        public static void LoadBundleAndStart(Stream stream)
        {
            Store.MapLoadLocked = true;
            DialogueManager.Instance.DialogueWindow.Show("Loading...", "Loading Custom Level", true, "Okay...");
            DialogueManager.Instance.DialogueWindow.ConfirmButton.gameObject.SetActive(false);
            DialogueManager.Instance.DialogueWindow.CancelButton.gameObject.SetActive(false);
            MelonCoroutines.Start(lbs());

            IEnumerator lbs()
            {
                var asyncBundle = AssetBundle.LoadFromStreamAsync(stream);
                while (!asyncBundle.isDone)
                {
                    DialogueManager.Instance.DialogueWindow.MessageLabel.text =
                        "Loading Custom Level...\n" + asyncBundle.progress * 100 + "%";
                    yield return null;
                }

                try
                {
                    DialogueManager.Instance.DialogueWindow.MessageLabel.text =
                        "Done!\n" + asyncBundle.progress * 100 + "%";
                    DialogueManager.Instance.DialogueWindow.Close();
                    Store.LoadedAssetBundle = asyncBundle.assetBundle??throw new NullReferenceException("asyncBundle.assetBundle failed to load.");
                }
                catch (Exception e)
                {
                    Store.MapLoadLocked = false;
                    DialogueManager.Instance.DialogueWindow.MessageLabel.text = "Failed to load!";
                    DialogueManager.Instance.DialogueWindow.ConfirmButton.gameObject.SetActive(true);
                    MelonLogger.Error("Failed to load bundle " + e);
                    Store.BundleStream?.Close();
                    Store.BundleStream?.Dispose();
                    MelonLogger.Msg(e.ToString());
                    yield break;
                }
                Store.MapLoadLocked = false;
                GameManager.Instance.StartGame();
            }
        }
    }
}