# Umbra // An unofficial Fork of Spektre Developed by BennettStaley
A small collection of hacks and cheats for Risk of Rain 2. 

# Has been updated for the Artifacts Update
# Features

- [ ] Clear items in inventory
- [ ] Give all items
- [ ] Stack inventory (does the same thing as the Shrine of Order)
- [ ] Give XP
- [ ] Give Money
- [ ] Give Lunar Coins
- [ ] Give yourself items and equipment
- [ ] Give/Remove buffs
- [ ] No ability cooldowns
- [ ] No equipment cooldown
- [ ] See chests and teleporter through walls

Can press `Insert` key to open.
Have to use mouse to select cheats. This can be done while holding tab ingame or while in the escape menu.

# Upcoming
- [ ] Teleporter Management
- [ ] Lobby Management
- [ ] GUI Improvements
- [ ] Clear Inventory Fix
- [ ] Drop Items
- [ ] Fly
- [ ] Always Sprint
- [ ] Stats Modification/View
- [ ] Unlock All

# How to use:
## Download dll from Releases
### Requirements
- [ ] A Mono Injector. [Sharpmonoinjector](https://github.com/warbler/SharpMonoInjector) is recommended and is used in this tutorial.

1. Head to [releases](https://github.com/kamron030702/RoR2ModMenu-Renewed/releases) and download Umbra v0.04.zip
2. Extract the zip
3. Use your favorite mono injector to inject the dll (If you do not know how to use sharpmonoinjector, scroll down to that section)
```
Namespace: RoRCheats
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
6. Press ctrl+b to build dll and it should be located where you found the .sln file -> bin -> Debug -> RoRCheats.dll

7. Use your favorite mono injector to inject the dll (If you do not know how to use sharpmonoinjector, scroll down to that section)
```
Namespace: RoRCheats
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

`cd "C:\Users\Kamron Cole\Documents\My Cheats\RoR2\SharpMonoInjector.Console\SharpMonoInjector.Console"`

3. You can tell if you're in the proper directory if you type `dir` and you see SharpMonoInjector.dll and smi.exe listed

4. Once you are in the proper directory and Risk of Rain 2 is open, type 

`smi.exe inject -p "Risk of Rain 2" -a "[Path to RoRCheats.dll]" -n RoRCheats -c Loader -m Load` 

again replacing [Path to RoRCheats.dll] with the proper path (keep the quotes)

### Batch file
1. Once you have sharpmonoinjector downloaded from [here](https://github.com/warbler/SharpMonoInjector/releases/download/v2.2/SharpMonoInjector.Console.zip), extract the zip.
2. Right click on your Desktop -> New -> Text Document
3. Open the text document and paste the following
```
@echo off
cd "[path to folder with smi.exe]"
cls
smi.exe inject -p "Risk of Rain 2" -a "[Path to RoR2Cheats.dll]" -n RoRCheats -c Loader -m Load
pause
```
4. Replace [path to folder with smi.exe] and [Path to RoR2Cheats.dll] with the proper paths (keep quotes if they are there)
5. Press ctrl+shift+s and name it `start.bat` (make sure you replace .txt with .bat)
6. If everything was done properly, while the game is open just run `start.bat` as administrator and the Menu should automatically be injected into the game

# Resources:
https://github.com/0xd4d/dnSpy

https://github.com/BennettStaley/RoR2ModMenu

# Media: 
https://www.youtube.com/watch?v=ragMPNvDY44
