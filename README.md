# XCheese

Quick and dirty way to call `StageUpdate.ShowStageRewardUI()` to cheese and automatically clear any stage by pressing F5.  
(For XDiVE offline version)

This is moreorless a "Hello World" I wrote.

## Known Bugs

* Hard lock if you try to show the reward UI before the stage has begun (the "Ready, Go!" sequence has finished playing).

## Building

Don't forget to add BepInEx to your NuGet repositories:

[![Add https://nuget.bepinex.dev/v3/index.json to your NuGet packages repository list](https://i.imgur.com/THZuC8o.png)](https://i.imgur.com/THZuC8o.png)

[![Add BepInEx.* to your package mappings](https://i.imgur.com/RdfBOgT.png)](https://i.imgur.com/RdfBOgT.png)

and have run BepInEx at least once to generate a library dump of the assemblies.

This repository uses [this template](https://github.com/SutandoTsukai181/BepInEx.Templates/releases) and assumes you have XDiVE installed in the default location; `C:\Program Files (x86)\Steam\steamapps\common\MEGA_MAN_X_DiVE_Offline`.
