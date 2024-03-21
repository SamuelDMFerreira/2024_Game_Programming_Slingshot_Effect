# Slingshot Effect #

## Summary ##

**A paragraph-length pitch for your game.**

## Project Resources

[Web-playable version of your game.](https://itch.io/)  
[Trailor](https://youtube.com)  
[Press Kit](https://dopresskit.com/)  
[Proposal: make your own copy of the linked doc.](https://docs.google.com/document/d/1qwWCpMwKJGOLQ-rRJt8G8zisCa2XHFhv6zSWars0eWM/edit?usp=sharing)  

## Gameplay Explanation ##

In Slingshot Effect two players each take control of a warship and fight to the death within the orbit of jupiter. Each player is equipped with the ability to fire gravitional effect projectiles and have to take advantage of the planets gravity to hit the other player.

Each player has a small selection of manuevers.
- Use left thumbstick to turn ship and move forward at slow speed. 
- Use thumpers to acelerate player quickly.
- Use right thumbstick to rotate camera.
- Use B button to fire projectiles.

The projectile and players are attracted by Jupiters gravity. Be carefull not to fall into the planet or else you will start taking damage.
A player wins if the other player's health is reduced to zero. 

**Add it here if you did work that should be factored into your grade but does not fit easily into the proscribed roles! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least four such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The game's background consists of procedurally generated terrain produced with Perlin noise. The game can modify this terrain at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer

**Describe the steps you took in your role as producer. Typical items include group scheduling mechanisms, links to meeting notes, descriptions of team logistics problems with their resolution, project organization tools (e.g., timelines, dependency/task tracking, Gantt charts, etc.), and repository management methodology.**

- in charge of merge git pull requests
- used git project https://github.com/users/SamuelDMFerreira/projects/4 and git issues https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/issues
- set up google drive https://drive.google.com/drive/folders/0AItSErCiyZ-TUk9PVA
- made reference gameplay one page design document that team can work off of https://www.figma.com/file/LSABP4OMuUX36TnWPdPD8U/Slingshot-Effect-One-Page-Design-Doc?type=design&node-id=0-1&mode=design
- contacted both GP survivor and Hell Punch group to intial report and review processes. 
- Made groups discord server 
- made hell punch / slingshot server, inspired by survivor made by GP surivor for are meeting with them
- arranged sprint meetings on thursdays 10:30 - 11:30 AM. Used when to meet 
- arranged last two group meetings on sunday 10:30 and tuesday 1:30 

## User Interface and Input

**Describe your user interface and how it relates to gameplay. This can be done via the template.**
**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets, including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Game Logic

**Document the game states and game data you managed and the design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets, including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

## Game Feel and Polish

- created [Jupiter map scene](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/commit/5de8c3adaa3cf1e48f1df90735b151f097e8bbad) with large planet and high gravity that more accurately reflected our original image of the game. this map design mitigated issues with players flying off the map easily 
- edited player controller class to [decouple](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/commit/36a4f9c9340338a4b1b02bb1d06fafbf0e821aa4) input from player's movements, handed code off to Eric to handle inputs.
- simplified Diego's gravity control to only [consider force](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/commit/e44ac56c5b7ce06b9cdbf1c23479192f8525dcda#diff-cf4309c7de7a548a6b48fd8c657fbb34208ed33315d183eb85b5bf0a42d21261L13). found that it lead to less jarring behavior.
- added a [moon](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/commit/a7e9f1e55adf81dd5c1aac3b52f4fd8ea0b94088) to the jupiter map to make feel a bit more dynamic.
- added a script to toggle [gravitional attraction](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Scripts/GravitonallyAttracted.cs#L5) of gravitional attracted objects, this was to mitigate the issue in which projectiles where to quickly getting bent toward jupiter, it didn't feel good to fire projectiles. This script is accessed from [ProjectileController](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Scripts/ProjectileController.cs#L17) to create the delay effect.
- added [boundary](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/main/Assets/Prefabs/Boundary.prefab) to jupiter map to prevent players from flying out too far.
- Adjusted player's [angular drag](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Prefabs/Player.prefab#L235) and [linear drag](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Prefabs/Player.prefab#L234) to slow down boast speed after some time to prevent players from getting lost, and prevent the ships projectile from rotating the ship too much respectively.
- Adjusted projectile [linear drag](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Prefabs/Projectile.prefab#L121), so that the projectiles slow down and are more likely to get bent or fall into jupiter. 


**Document what you added to and how you tweaked your game to improve its game feel.**
