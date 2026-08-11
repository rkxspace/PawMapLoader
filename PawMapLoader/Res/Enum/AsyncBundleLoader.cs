using System;
using System.Collections;
using Il2CppGame;
using Il2CppUI;
using MelonLoader;
using UnityEngine;

namespace PawMapLoader.Res.Enum
{
    public class AsyncBundleLoader
    {
        public static void LoadBundleAndStart()
        {
            Store.MapLoadLocked = true;
            DialogueManager.Instance.DialogueWindow.Show(Strings.GetString("LoadingHeader"),
                Strings.GetString("LoadingMessage"), true, Strings.GetString("LoadingOkayButton"));
            DialogueManager.Instance.DialogueWindow.ConfirmButton.gameObject.SetActive(false);
            DialogueManager.Instance.DialogueWindow.CancelButton.gameObject.SetActive(false);
            MelonCoroutines.Start(lbs());

            IEnumerator lbs()
            {
                AssetBundleCreateRequest asyncBundle = AssetBundle.LoadFromStreamAsync(Store.BundleStream);
                while (!asyncBundle.isDone)
                {
                    DialogueManager.Instance.DialogueWindow.MessageLabel.text =
                        $"{Strings.GetString("LoadingMessage")}\n{Math.Round(asyncBundle.progress * 100)}%";
                    yield return null;
                }

                Store.LoadedAssetBundle = asyncBundle.assetBundle ??
                                          throw new NullReferenceException("Map AssetBundle failed to load.");

                if (Store.AdditiveBundleStream != null)
                {
                    asyncBundle = AssetBundle.LoadFromStreamAsync(Store.AdditiveBundleStream);

                    while (!asyncBundle.isDone)
                    {
                        DialogueManager.Instance.DialogueWindow.MessageLabel.text =
                            $"{Strings.GetString("LoadingMessageAdditional")}\n{Math.Round(asyncBundle.progress * 100)}%";
                        yield return null;
                    }

                    Store.ExtraAssetBundle = asyncBundle.assetBundle ??
                                             throw new NullReferenceException(Strings.GetString("AdditionalLoadFail"));
                }

                try
                {
                    DialogueManager.Instance.DialogueWindow.MessageLabel.text =
                        $"{Strings.GetString("LoadingFinish")}\n{asyncBundle.progress * 100}%";
                    DialogueManager.Instance.DialogueWindow.Close();
                }
                catch (Exception e)
                {
                    Store.MapLoadLocked = false;
                    DialogueManager.Instance.DialogueWindow.MessageLabel.text = Strings.GetString("MapLoadFailText");
                    DialogueManager.Instance.DialogueWindow.ConfirmButton.gameObject.SetActive(true);
                    MelonLogger.Error($"{Strings.GetString("BundleLoadError")}{e}");
                    Store.BundleStream?.Close();
                    Store.BundleStream?.Dispose();
                    Store.AdditiveBundleStream?.Close();
                    Store.AdditiveBundleStream?.Dispose();
                    yield break;
                }

                Store.MapLoadLocked = false;
                GameManager.Instance.StartGame();
            }
        }
    }
}