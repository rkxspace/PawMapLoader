# PawMapLoader
This mod was created to load custom maps!

> [!TIP]
> Report issues and give feedback on [Discord](https://starshot.xilenth.space/redirect?dest=eNrLKCkpKLbS10_JLE7OL0rRS0_XN64oKXYrTfUoLAIAoKEKvA)

## Releases
> [!CAUTION]
> These links are the ONLY verified places to download the mod.
> <br>If someone linked you elsewhere, your system may be compromised.

> [!WARNING]
> This mod is currently in development, and will have bugs. Additionally, many features are incomplete or missing.
- Stable: https://github.com/rkxspace/PawMapLoader/releases/latest
- Bleeding Edge: https://github.com/rkxspace/PawMapLoader/releases

## TODO
- [ ] Finish scripting system [Partially done!]
- [ ] Distribution Format
- [ ] Create working damageable
- [ ] Make components for easy creation of different object types
- [ ] Create an SDK for use in Unity
- [ ] Make an in-game editor
- [ ] Documentation
- [ ] Website for documentation

## Error Reporting
This mod reports errors to a server hosted by us.
If you wish to change or disable this behavior, edit `UserData\.rkxspace\PawMapLoader\config.json`.

## How to use
Create `UserData/Maps/maps.json`.

Here is a template to get started:
```
{
    "PawMapFileVersion": 1,
    "PawMaps": [
        {
            "Name": "Testing Map",
            "LeaderboardName": "TestingMap",
            "AssetFile": "rkxspace.TestMap", // this will load the file "Maps/rkxspace/TestMap.pawbox"
            "MapMetadata": {
                "GrowthRateModifier": 1.0, // The multiplier for the growth rate on the map. Down Town is set to 1, Atro City is set to 0.8.
                "GrowthShapeKeyStart": 2.0, // Internal value in which to start increasing the growth shape key.
                "GrowthShapeKeyEnd": 12.0, // Internal value in which to stop increasing the growth shape key.
                "Population": 0, // This is in the game, but never used or shown to the player.
                "ShadowDistanceMax": 200.0, // Not sure why this is defined in each, because it seems to be the same in both built in maps.
                "ShadowHeightMax": 20.0, // Same thing here.
                "SquareKilometers": 0, // Same deal as Population.
                "UnlockedBy": "None", // This is a var that points to an instance of Il2CppGame.SceneConfig, the JSON uses LeaderboardName to assign that for us. Unused by mod currently.
                "UnlockTargetScore": 0, // Score integer to determine if the level was unlocked. Won't work if UnlockedBy is unset. Unused by mod currently.
            }
        }
    ]
}
```
> [!NOTE]
> Unused fields are ignored by the mod. Implementations are planned for UnlockedBy and UnlockTargetScore.

To make a map, create a project in Unity 6000.0.27f1 using the URP pipeline. Create a scene with the name format of `Author.MapName`. Add the scene to an asset bundle. While the SDK is in progress, you will need to do the component work. The root game objects should be the following:
- SceneObjects - For objects in the scene, that's it.
- SceneConfig - Left for the mod to handle, expected to be there. Occasionally could be useful.

After building the bundle, add the entry for your map to the `maps.json` file. AssetFile should be the same as your scene name, and the bundle should be placed as `Author/MapName.pawbox`

## AI and PawMapLoader
We're aware of the drama that arises from using AI in any capacity. Here's the big picture for you: **We don't give a fuck.**
<br>This repository was made for the **explicit purpose of creating a tool by hand**.
<br>And, while we don't endorse AI entirely, we do use it to **reduce time waste better spent developing the project**.

**Code, images, and other assets** within this repository are made by **human beings**. That won't change.
<br>However, when it comes to **automatic pre-releases** we use `deepseek-v4-flash` to create release notes. Further, it is used to help find (**but not fix**) potential issues before testing, saving the headache of restarting the game constantly.
<br>Full, **stable releases** will have release notes **made by humans, for humans**. Additionally, they are manually uploaded to GitHub.
> [!IMPORTANT]
> Creating pull requests with AI is forbidden in this repository. If we suspect you using AI to create or alter code, you will be blocked from making future contributions.

<img src="https://github.com/rkxspace/PawMapLoader/blob/master/assets/rkxspacemulti.png?raw=true" alt="rkxspace logo" width="200" >

<sup>rkxspace and this project are **not affiliated with nor endorsed by Dare Looks**.</sup>
