# Random Enemies & Loot

Update on 31.12.2021: Save game crash issues fixed. Random loot had issues spawning nulls which ended up crashing game. Ended up moving to use parts of random equipment by Hambeard. 

Update on 16.12.2021: Hopefully fixed all the issues with saves corrupting. Loot logic changed, took performance hit but no idea how to implement it on load area without issues with saves.

PLEASE NOTE THIS IS VERY EARLY VERSION - it is highly likely that it will cause issue of replacing some important NPC! Toybox can most likely fix that. 



What does this mod do? Basically when a monster spawns, this mod will replace it with new one of similar kind of power level (in some cases you might roll a really hard fight). Every zone will have a theme and a backup theme chosen when loading into area from which the monsters pool is fetched first. If no match is found, then all pools are to be used. 

Also all monsters have a chance to drop a random loot. Loot level is based on the CR of enemy with a roll for multipliers. 

The mod has blacklisted the tutorial areas (and couple other). Also some mobs are blacklisted, but i have only played upto ~ending of act2 atm so i do not know for sure what happens in later acts with the mod on. 

I actually have three different models for this and this seemed most stable (other ones were replacing unit groups / units with new units, but i couldnt figure out how to have them spawn in realistic places).

You can contact me on Discord Pathfinder channel with name Ode

**How to install**

1. Download and install [Unity Mod Manager](https://github.com/newman55/unity-mod-manager), make sure it is at least version 0.23.0
2. Run Unity Mod Manager and set it up to find Wrath of the Righteous
3. Download the mod
4. Install the mod by dragging the zip file from step 5 into the Unity Mod Manager window under the Mods tab

**Thanks**

Hambeard for creating Random equipment mod. This uses part of it for random loots. 

Vek17 and their Tabletop Tweaks mod, couldn't understand how to actually do some of this stuff I couldn't dissect and take apart how your mod worked. 
Bubbles and rest of the discord <3
