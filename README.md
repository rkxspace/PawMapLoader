# PawMapLoader
<sup>The mod that loads maps into Pawperty Damage</sup>

It's funny, you spend 30 minutes in a game, realize you've seen all of it, 400 hours later you're making a mod that adds more.

Anyway, this mod's goal is to offer what is essentially a full map-making toolkit. Right now it's a bit rough, but I plan on smoothing out those edges a bit.

## TODO <sup>(In no specific order.)</sup>
- [ ] Finish scripting system [Partially done!]
- [ ] Distribution Format
- [ ] Create working damageable
- [ ] Make components for easy creation of different object types
- [ ] Create an SDK for use in Unity
- [ ] Make an in-game editor
- [ ] Documentation
- [ ] Website for documentation

> This mod is made with Melonloader in mind. Not BepInEx.

## Error Reporting
This mod reports errors to a server hosted by rkxspace.
If you wish to change or disable this behavior, edit `UserData\.rkxspace\PawMapLoader\config.json`.
The server, hosted by rkxspace, only collects errors and stack traces.

## Releases
- Stable: https://github.com/rkxspace/PawMapLoader/releases/latest
- Bleeding Edge: https://github.com/rkxspace/PawMapLoader/releases

## How to use
The mod will create a `Maps` folder in `Pawperty Damage/UserData`.
It is up to the user to make a `maps.json` inside `Maps`.

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
> Comments are ignored by newtonsoft.json.
> Unused fields are ignored by the mod. Implementations are planned.

To make a map, create a project in Unity 6000.0.27f1 using the URP pipeline. After creating the project, create a scene with the name format of `Author.MapName`. Add the scene to an assetbundle. As of right now, components needed to create buildings and such need to be stubbed by the user. The root game objects should be the following:
- SceneObjects - For objects in the scene, thats it.
- SceneConfig - Left for the mod to handle, expected to be there. Occasionally could be useful.

After building the bundle, add the entry for your map to the `maps.json` file. AssetFile should be the same as your scene name, and the bundle should be placed as `Author/MapName.pawbox`

## AI and PawMapLoader
- **PawMapLoader is not, and will never be, written using AI.** However, that doesn't mean it isn't used. rkxspace uses AI for automatic release notes in **bleeding-edge** builds.
- We use the following model for release notes: deepseek-v4-flash
- Release notes for **stable builds** are written by rkxspace directly.
- AI **WILL NEVER WRITE CODE** inside this repository.

<img src="https://github.com/rkxspace/PawMapLoader/blob/master/assets/rkxspacemulti.png?raw=true" alt="rkxspace" width="200" >

<sup>rkxspace and this project are **not affiliated with nor endorsed by Dare Looks**.</sup>
