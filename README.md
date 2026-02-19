# PawMapLoader
<sup>The mod that loads maps into Pawperty Damage</sup>

## TODO
- [X] Load a map successfully
- [X] Load map but in a lazy way
- [X] Unload map when exit
- [ ] Create working damageable.
- [ ] Make components for easy creation of different object types.
- [ ] Create an SDK for use in Unity
- [ ] Maybe fix additional things

This mod is made with Melonloader in mind. Not BepInEx.

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
(Comments will work. Don't worry!)

To make a map, create a project in Unity 6000.0.27f1 using the URP pipeline. After creating the project, create a scene with the name format of `Author.MapName`. Add the scene to an assetbundle. As of right now, components needed to create buildings and such need to be stubbed by the user. The root game objects should be the following:
- SceneObjects - For objects in the scene, thats it.
- SceneConfig - Left for the mod to handle, expected to be there. Occasionally could be useful.

After building the bundle, add the entry for your map to the `maps.json` file. AssetFile should be the same as your scene name, and the bundle should be placed as `Author/MapName.pawbox`
