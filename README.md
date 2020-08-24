# Umbra Menu ![Downloads](https://img.shields.io/github/downloads/Acher0ns/Umbra-Mod-Menu/total)

![UmbraInjecter-icon](https://user-images.githubusercontent.com/12210881/87236402-2d05ae80-c3b7-11ea-96d9-61f2136e8607.png)

A small collection of hacks and cheats for Risk of Rain 2.

Open to any pull requests.

Doesn't require BepInEx or R2API!

This is an unofficial fork of the Spektre Menu by [BennettStaley](https://github.com/BennettStaley/)
and was merged with [Lodington's](https://github.com/Lodington/) unofficial fork.

This menu is for testing/personal fun. I do not condone the use of this menu in competitive modes such as the Prismatic Trials nor do I condone the use of this menu if it harms the experience of other players in any way. Thank you.


# Just released Umbra-Injector to auto inject/update Umbra Menu. Check it out [here](https://github.com/Acher0ns/Umbra-Menu-Injector)
# Features

- [ ] Unlock All
- [ ] Change Character
- [ ] Spawn Mobs and Interactables
- [ ] God Mode
- [ ] Flight
- [ ] Play as mobs/unreleased characters
- [ ] Stats Modification/View
- [ ] No ability cooldowns
- [ ] No equipment cooldown
- [ ] See chests and teleporter through walls
- [ ] Give XP
- [ ] Give Money
- [ ] Give Lunar Coins
- [ ] Give or Drop yourself items and equipment
- [ ] Give/Remove buffs
- [ ] Always Sprint
- [ ] Clear items in inventory
- [ ] Stack inventory (does the same thing as the Shrine of Order)
- [ ] Lobby Management - Kick players from your lobby
- [ ] See mobs through walls - Needs work, laggy and may crash game
- [ ] Teleporter Management - Spawn teleporters(newt, celestine, gold), add Mountain Shrine stack, skip stage, insta charge tp
[![Preview](https://user-images.githubusercontent.com/12210881/87210926-51915600-c2e5-11ea-9b44-961f05be79ee.png)](https://www.youtube.com/watch?v=XakIkkCxtRA)

Press the `Insert` key to open.

Use `Up Arrow` and `Down Arrow` to activate keyboard navigation. Can be disabled with `Backspace` or `Left Arrow`.

Navigate current menu options with `Down Arrow` and `Up Arrow`.

Go to the next menu or activate the highlighted cheat with `Right Arrow` or `V`.

Go to the previous menu with `Backspace` or `Left Arrow`.

When highlighting an option with +/- buttons next to it use `Left Arrow` to decrease or `Right Arrow` to increase.

OR

Use mouse to select cheats. This can be done while holding tab ingame or while in the escape menu.

Note: Some features may not work if you are not the host of the lobby

- Z -> Toggle Player Menu
- I -> Toggle Item Spawn Menu
- C -> Toggle Flight
- B -> Toggle Teleporter Menu


# List of Improvements I Might Add:
- [ ] Add filters to ESPs?
- [ ] Make ESP less laggy?


# Getting Started:
## v1.2.4 and above
1. Head to [releases](https://github.com/Acher0ns/Umbra-Menu-Injector/releases/latest/) and download `Umbra-Injector-vX.X.X.zip`
2. Extract the zip.
3. Run `UmbraInjector.exe`
4. Press the `Inject` button while the game is open.

Note: Make sure `UmbraInjector.exe` and the `Data` folder stay in the same directory.

## v1.2.3 and below
### Requirements
- [ ] A Mono Injector. [Sharpmonoinjector](https://github.com/warbler/SharpMonoInjector) is recommended and is used in this tutorial.

Note: Must use the CLI version of sharp mono injector. The GUI version doesn't work properly.


1. Head to [releases](https://github.com/Acher0ns/Umbra-Mod-Menu/releases) and download `UmbraMenu-vX.X.zip`
2. Extract the zip
3. Use your favorite mono injector to inject the dll (If you do not know how to use sharpmonoinjector, scroll down to that section)
```
Namespace: UmbraRoR
Class: Loader
Method: Load
```

## How to use sharpmonoinjector
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


# Set Up Dev Environment
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
2) netstandard.dll
3) Rewired_Core.dll
4) System.dll
5) UnityEngine.CoreModule.dll
6) UnityEngine.dll
7) UnityEngine.IMGUIModule.dll
8) UnityEngine.Networking.dll
9) UnityEngine.TextRenderingModule.dll
```
6. You will also have to add ```Octokit.dll``` that is in the project's source folder. `Umbra-Mod-Menu-master\Octokit.dll`. This is used to check for updates.

### Build
1. Press ctrl+b to build dll and it should be located where you found the .sln file -> bin -> Release (or Debug) -> UmbraRoR.dll


# Changelog:
### X/XX/XXXX v1.3.1:
- [ ] Added Menu to change whats inside chests/equipment barrels.
- [ ] Added Scrappers and Barrels to Interactables ESP.
- [ ] Added what item is in chests to Interactable ESP.
- [ ] Added Keybinds:
 - Z -> Toggle Player Menu
 - I -> Toggle Item Spawn Menu
 - C -> Toggle Flight
 - B -> Toggle Teleporter Menu
- [ ] Added better support for low resolution monitors (less than 1080p).
- [ ] Item/Equipment list now shows friendly item names and their color based on rarity.
- [ ] Slightly improved Navigation logic.
- [ ] Greatly Improved Interactable ESP performance.
- [ ] Slightly Improved the Menus Load() method.
- [ ] Improved how teleporters are spawned
- [ ] Fixed a bug allowing menu index to be set while Navigation was off
- [ ] Fixed a bug not allowing you to scroll on list menus while Navigation was on


### 8/11/2020 v1.3.0:
- [ ] Updated for Risk of Rain 2 1.0 Update.
- [ ] Slightly improved ESP performances.
- [ ] Updated Unlockables List.


### 8/5/2020 v1.2.6:
- [ ] Added a box around mobs for Render Mobs.
- [ ] Added the ability to despawn spawned interactables.
- [ ] Improved Kill All. Now kills mobs spawned on the players team.
- [ ] Improved Show Stats Menu Style.
- [ ] Improved how the menu gets the local player.
- [ ] Fixed a bug allowing navigation to be enabled in the main menu.
- [ ] Added some comments to my source code.
- [ ] Made a wrapper method for drawing buttons.
- [ ] Bunch of code formatting/organization/refactoring.
- [ ] Various other minor improvements.


### 7/20/2020 v1.2.5:
- [ ] Added JumpPack.
- [ ] Added the ability to Spawn Interactables and Mobs.
- [ ] Added the ability to insta-kill all Mobs.
- [ ] Moved Movement mods to their own menu/file.
- [ ] Moved Stats Modifications/Menu to their own menu.
- [ ] Made the menu slightly more transparent and smaller.
- [ ] Fixed View Stats Menu styling.
- [ ] Some code cleanup.


### 7/11/2020 v1.2.4:
- [ ] Added Active Mobs list to bottom of screen.
- [ ] Added Unload button to the main menu.
- [ ] Updated Menu positions to support 1080p & 1440p.
- [ ] Improved how the menu checks for updates.
- [ ] Fixed some things not showing in item/equipment lists.
- [ ] Fixed bug causing Roll Items to not work.
- [ ] Fixed Clear Inventory not clearing the UI properly.
- [ ] Fixed ClearInventory not clearing buffs given by items.
- [ ] Fixed a bug that sometimes caused mob & interactable ESP to conflict.
- [ ] Fixed a bug causing Always Sprint & Flight to conflict.
- [ ] Fixed a bug causing Stats Menu & drag location to reset when insert was pressed while Navigation was toggled.
- [ ] Some code cleanup.


### 7/9/2020 v1.2.3:
- [ ] Added the ability to change characters and play as unreleased characters and mobs.
- [ ] Added Keyboard Navigation to change character menu, give buff menu, give item menu, and give equipment menu.
- [ ] Completely reworked how Keyboard Navigation works behind the scenes.
- [ ] Made the menu more compact.
- [ ] Refactored a few things.


### 7/3/2020 v1.2.2:
- [ ] Menu now `checks for updates` on inject and will tell you if its outdated.
- [ ] Added ability to disable keyboard navigation if `Backspace` or `Left Arrow` is pressed in the main menu.
- [ ] Improved Flight:
 - Can now press `X` to fly down.
 - No longer take fall damage while flight is enabled.
- [ ] Improved Roll Item:
 - Added Lunar and Boss items to loot pool.
 - No longer uses a depricated method.
- [ ] Refactored a few things.
 
 
### 6/26/2020 v1.2.1:
 - [ ] Added the ability to navigate the menu with a keyboard.
 - [ ] Added the ability to drop items from your inventory.
 
 
### 4/26/2020 v1.2:
 - [ ] Fixed Equipment not dropping sometimes.
 - [ ] Reorganized code.
 - [ ] Added comments to code.


### 4/23/2020 v1.0:
 - [ ] Repo Changed to Public.
 
 
# Resources:
https://github.com/0xd4d/dnSpy

https://github.com/BennettStaley/RoR2ModMenu

https://github.com/Lodington/RoRCheats

https://github.com/octokit/octokit.net
