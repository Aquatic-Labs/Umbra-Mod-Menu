# Umbra Menu
A small collection of hacks and cheats for Risk of Rain 2.

This is an unofficial fork of the Spektre Menu by [BennettStaley](https://github.com/BennettStaley/)
Was merged with [lodsharpshooter's](https://github.com/lodsharpshooter) unofficial fork.

# Has been updated for the Artifacts Update
# Next Update (ETA: ROR2 Next Update)
# Features

- [ ] Clear items in inventory
- [ ] Give all items
- [ ] Stack inventory (does the same thing as the Shrine of Order)
- [ ] Give XP
- [ ] Give Money
- [ ] Give Lunar Coins
- [ ] Give or Drop yourself items and equipment
- [ ] Give/Remove buffs
- [ ] No ability cooldowns
- [ ] No equipment cooldown
- [ ] See chests and teleporter through walls
- [ ] See mobs through walls - Needs work, laggy and may crash game
- [ ] Teleporter Management - Spawn teleporters(newt, celestine, gold), add Mountain Shrine stack, skip stage, insta charge tp
- [ ] Lobby Management - Kick players from your lobby
- [ ] Flight
- [ ] Always Sprint
- [ ] Stats Modification/View
- [ ] Unlock All

![image](https://user-images.githubusercontent.com/12210881/85503584-03c3e080-b5b8-11ea-8c56-539bff7ece66.png)

Press the `Insert` key to open.

Use `Up Arrow` and `Down Arrow` to activate keyboard navigation.

Navigate current menu options with `Down Arrow` and `Up Arrow`.

Go to the next menu or activate the highlighted cheat with `Right Arrow` or `V`.

Go to the previous menu with `Backspace` or `Left Arrow`.

When highlighting an option with +/- buttons next to it use `Left Arrow` to decrease or `Right Arrow` to increase.

OR

Use mouse to select cheats. This can be done while holding tab ingame or while in the escape menu.

Note: Some features may not work if you are not the host of the lobby

# Next Update (ETA: ROR2 Next Update):
### Upcoming Features:
- [ ] GUI keyboard navigation
- [ ] drop items from inventory

# TODO List:
- [ ] Add filters to ESPs
- [ ] Make ESP less laggy?
- [ ] Clear Items despawn beatle guards/Allies from UI
- [ ] Press X to go down while fly is enabled?

### far fetched features(still possible but idk):
- [ ] Respawn
- [ ] Spawn Mobs

# How to use:
## Download dll from Releases
### Requirements
- [ ] A Mono Injector. [Sharpmonoinjector](https://github.com/warbler/SharpMonoInjector) is recommended and is used in this tutorial.

1. Head to [releases](https://github.com/Acher0ns/Umbra-Mod-Menu/releases) and download `UmbraMenu-vX.X.zip`
2. Extract the zip
3. Use your favorite mono injector to inject the dll (If you do not know how to use sharpmonoinjector, scroll down to that section)
```
Namespace: UmbraRoR
Class: Loader
Method: Load
```

## Build your own dll
### Requirements
- [ ] Microsoft Visual Studios 2017 or later
- [ ] A Mono Injector. [Sharpmonoinjector](https://github.com/warbler/SharpMonoInjector) is recommended and is used in this tutorial.

1. Clone or Download -> Download ZIP 
2. Extract ZIP file
3. Navigate to where you extracted the zip and open the .sln file (if you cannot see file extentions, go to the view tab at the top of file explorer and on the right check the "File name extensions" box)
4. In  Visual Studios Right click on the project > add > Reference... (Image shows where to right click)
![Annotation 2020-04-18 181944](https://user-images.githubusercontent.com/12210881/79672593-8471f500-81a1-11ea-9863-b60943be5108.png)
 

5. Click browse. The required resources are found in > `\Steam\steamapps\common\Risk of Rain 2\Risk of Rain 2_Data\Managed`
```
1) Assembly-CSharp.dll
2) UnityEngine.dll
3) UnityEngine.TextRenderingModule.dll
4) UnityEngine.Networking.dll
5) UnityEngine.IMGUModule.dll
6) UnityEngine.CoreModule.dll
```
6. Press ctrl+b to build dll and it should be located where you found the .sln file -> bin -> Debug -> UmbraRoR.dll

7. Use your favorite mono injector to inject the dll (If you do not know how to use sharpmonoinjector, scroll down to that section)
```
Namespace: UmbraRoR
Class: Loader
Method: Load
```
# How to use sharpmonoinjector
After you have your dll file, you'll need to have a way to inject it into the game. There are 2 option Command line or with a batch file.
### Command line
1. Once you have sharpmonoinjector downloaded from [here](https://github.com/warbler/SharpMonoInjector/releases/download/v2.2/SharpMonoInjector.Console.zip), extract the zip.

2. Next open a command prompt window as administrator and type the command:

`cd "[path to folder with smi.exe in it]"` 

obviously replacing [path to folder with smi.exe in it] with the proper path (keep the quotes). For example my command is:

`cd "C:\Users\Username\Documents\My Cheats\RoR2\SharpMonoInjector.Console\SharpMonoInjector.Console"`

3. You can tell if you're in the proper directory if you type `dir` and you see SharpMonoInjector.dll and smi.exe listed

4. Once you are in the proper directory and Risk of Rain 2 is open, type 

`smi.exe inject -p "Risk of Rain 2" -a "[Path to UmbraRoR.dll]" -n UmbraRoR -c Loader -m Load` 

again replacing [Path to UmbraRoR.dll] with the proper path (keep the quotes)

### Batch file
1. Once you have sharpmonoinjector downloaded from [here](https://github.com/warbler/SharpMonoInjector/releases/download/v2.2/SharpMonoInjector.Console.zip), extract the zip.
2. Right click on your Desktop -> New -> Text Document
3. Open the text document and paste the following
```
@echo off
cd "[path to folder with smi.exe]"
cls
smi.exe inject -p "Risk of Rain 2" -a "[Path to UmbraRoR.dll]" -n UmbraRoR -c Loader -m Load
pause
```
4. Replace [path to folder with smi.exe] and [Path to UmbraRoR.dll] with the proper paths (keep quotes if they are there)
5. Press ctrl+shift+s and name it `start.bat` (make sure you replace .txt with .bat)
6. If everything was done properly, while the game is open just run `start.bat` as administrator and the Menu should automatically be injected into the game

# Changelog:
6/26/2020 v1.2.1:
 - [ ] Added the ability to navigate the menu with a keyboard
 - [ ] Added the ability to drop items from your inventory
 
4/26/2020 v1.2:
 - [ ] Fixed Equipment not dropping sometimes
 - [ ] Reorganized code
 - [ ] Added comments to code

4/23/2020 v1.0:
 - [ ] Repo Changed to Public
# Resources:
https://github.com/0xd4d/dnSpy

https://github.com/BennettStaley/RoR2ModMenu

https://github.com/lodsharpshooter/RoRCheats
