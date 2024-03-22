# Slingshot Effect #

## Summary ##

In Slingshot Effect two players take control of warship as their must fight to the death. Each player is equipped with the ability to fire gravitionally effected projectile and must maneavuer around the gravity of Jupiter in order to get the perfect shot and win the game. 

## Project Resources

[Web-playable version of your game.](https://samueldmferreira.itch.io/s)  
[Trailor](https://youtu.be/Z78cWUokqOM)  
[Press Kit](https://dopresskit.com/)  
[Proposal: make your own copy of the linked doc.](https://docs.google.com/document/d/1qwWCpMwKJGOLQ-rRJt8G8zisCa2XHFhv6zSWars0eWM/edit?usp=sharing)  

## Gameplay Explanation ##

The game works by spawning two player on opposite sides of Jupiter. Both start with the same limited amount of health, but must kill each other. Each player has a small selection of manuevers that their are able to pull off. 
- Use left thumbstick to turn ship by turning left or right. This form of turning is slow and limited.
- holding left thumbstick up moves the ship forward slowly and again is limited. 
- Use thumpers to activate thrust which accelerates the ship forward quickly. Thrust has a cool down and is locked to a maximum speed. 
- Use right thumbstick to rotate camera. Which gives you more view of the other players. 
- Use A button to fire projectiles. Projectiles are travel much fasting than the ship and able to damage the other player. however their also effected by gravity and can be bent.

The projectile and players are attracted by Jupiters gravity. If you fall into Jupiter, you will start taking damage inside Jupiter. This makes it dangerous to be inside but could alsoprovide useful game tatic if you try hiding from the other player. 

A player wins if the other player's health is reduced to zero, either by getting hit by projectiles or staying in Jupiter to long. 

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least four such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The game's background consists of procedurally generated terrain produced with Perlin noise. The game can modify this terrain at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer

**Describe the steps you took in your role as producer. Typical items include group scheduling mechanisms, links to meeting notes, descriptions of team logistics problems with their resolution, project organization tools (e.g., timelines, dependency/task tracking, Gantt charts, etc.), and repository management methodology.**

*Git Organization* - I was in charge of merging pull requests into main. This involved going into other member's branch on my local repo, to test their changes in unity. I would then merge or close pull request, if their changes were transferable. To track our project progress I also set up a [github project](https://github.com/users/SamuelDMFerreira/projects/4) andcreated [github issue](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/issues) pretaining to the work that each person in the group had to preform.    

*Game Design and Design Documentation* - I initial wrote the core gameplay system in the project plan and collabrated with the other group members to refine them. I than created a one [page design document](https://www.figma.com/file/LSABP4OMuUX36TnWPdPD8U/Slingshot-Effect-One-Page-Design-Doc?type=design&node-id=0-1&mode=design) avalible for the team, so we could have a design reference for gameplay.  

*Document Organization* - I created a [shared google drive](https://drive.google.com/drive/folders/0AItSErCiyZ-TUk9PVA) so that our group members could store code document, design documents, and research.  

*Communication* - I created a discord server for our group which we used as our main form of communcation. Though this we were able to arrange a regular physical meeting time of thursdays from 10:30 to 11:30 AM which we could use as sprint meetings. We also schedule two last emergency meetings at 10:30 sunday and 1:30 tuesday the same way. I was also responsible forcontacting both the GP survivor and Hell Punch groups to preform progress reports. For the Hell Punch progress report I create a second discord server to contact them. (Inspired by what GP survivor did for our meeting).    

## User Interface and Input

**Describe your user interface and how it relates to gameplay. This can be done via the template.**
**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets, including their sources and licenses.**

Spaceship Assets
Source: Unity Asset Store
Modifications: Color adjustments and resizing to fit game aesthetic
License: [https://assetstore.unity.com/packages/3d/vehicles/space/hi-rez-spaceships-creator-free-sample-153363]

Particle Effects
Components:
Space Dust
Engine Fire
Trail Renderer (aligned with spaceship direction)
Creation: Custom-made using Unity's particle system

Planetary Background Materials
Planets: Jupiter and its moon Io and 4 other planest on background
Source: [https://polyhaven.com/textures/rock]
[https://www.deviantart.com/fargetanik/art/Jupiter-True-Color-Texture-Map-Cassini-676015657]
[https://www.deviantart.com/fargetanik/art/Io-Truecolor-Texture-Map-8k-708688293]

Process: Converted pictures into materials for 3D rendering. I have downloaded rock textures from this website to implement textures on 4 background planets. 
Pictures for jupiter and Io are downloaded from the last two websites. 

SkyBox backgrounds
Source: [https://assetstore.unity.com/packages/2d/textures-materials/sky/spaceskies-free-80503]

I have implemented backgrounds based on this file I downloaded from Unity. Originally I had three different backgrounds: purple, pink and green. Since it was difficult to choose one, I originally made SkyboxSetter.cs to handle list of background files and let us choose drag the backgrounds in and choose one. However, at this stage of gamem, I found it unnecessary and ended up choosing pink backgrounds, setting it as a single, default background. This is my original branch that has the function and different backgrounds. [https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/tree/hk_animations]

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

Our game's visual and animation efforts are closely tied to enhancing the overall "game feel" - that intuitive sense of immersion, responsiveness, and satisfaction players get as they interact with the game environment. Through careful design and integration of visual assets, we aim to create a seamless and compelling experience that not only looks good but feels right.

Spaceship Design and Particle Effects
The custom modifications and particle effects added to the spaceship assets from Unity are designed to give players a tangible sense of speed and movement through space. The visual feedback from the engine fire and space dust contributes to a dynamic game feel, where players can feel the thrust and maneuverability of their spacecraft. Although it was not used eventually, I have also implemented second spaceship that looked different from the first one. This was in case we chose to use it for the second player. Just like the first one, I have also implemented particle effects such as engine fire and space dust. Also the spaceship would have trail renderer and pointlight and was modified in colors to differentiate from the frist one. 

Planetary Materials and Backgrounds
The materials created for Jupiter, Io and 4 other planets on the background serve multiple purposes. They not only contribute to the game's graphic design by providing a visually rich backdrop but also play a crucial role in world-building. By rendering these celestial bodies with detailed textures, we create a more immersive and believable universe for players to explore. This attention to detail helps ground the gameplay in a visually consistent and engaging setting.

## Game Logic (Oscar Wang)

**Document the game states and game data you managed and the design patterns you used to complete your task.**

  *Game Manager*: The game manager manages the game flow including scene transition, player instantiation, health management, and event handling. 
1. Architecture
   - It uses the singleton pattern to ensure that only one instance of the Game Manager exists throughout the game. It can be accessed through GameManager.instance.
   - The game states are stored as enums ( menu, play, end ). The GameManager uses a simple FSM to manage between each states.
   - It uses events to implement the observer pattern for player health changes, allowing decoupled communication between components.
  
2. Interactions
   - State management:
       - The state of the game is changed with the public method [UpdateState(GameState newState)](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/6a1ac0aa94ac47e06293623e1a71a3e0aaf3677c/Assets/Scripts/GameManager.cs#L64-L90). It uses SceneController's public methods to handle loading scenes.
           - I worked with the UI lead to ensure that the buttons in menus use Unity Events to trigger game state changes.
            <img width="313" alt="image" src="https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/assets/122497797/c844833a-23e5-4607-9845-c4d825f707f1">
            
           - Ex: If a player clicks the Start button in the main menu, it'll call the GameManager.instance.UpdateState(GameStates.Play) to load the game play scene.
       - The GameManager also subscribes to [SceneManagement.sceneLoaded](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/6a1ac0aa94ac47e06293623e1a71a3e0aaf3677c/Assets/Scripts/GameManager.cs#L113-L120) to make sure scenes are fully loaded before instantiating any objects.
    
   - Player system:
       - [AddPlayers()](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/6a1ac0aa94ac47e06293623e1a71a3e0aaf3677c/Assets/Scripts/GameManager.cs#L125-L141) function initializes two players at predefined spawn points upon entering the gameplay scene. It assigns unique player IDs to each instantiated player and resets the ID stored in winner.
    
   - Health system:
       - [UpdateHealth()](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/6a1ac0aa94ac47e06293623e1a71a3e0aaf3677c/Assets/Scripts/GameManager.cs#L98-L111) is an event that takes in 3 parameters: playerID, currentHealth, and maxHealth. It logs the current health of the player and invokes an event to notify other components of the health change. Additionally, it checks if the player's health has reached zero and determines the winner accordingly and updates the game state with UpdateState(GameState.Won).
    
   - Sound system:
       - The GameManager calls the SoundManager's public method PlayMusicTrack to play audio based on the state and scene.

  *Player Health*: The player health manages the health of a player character in the game. It has a playerID field to identify the player that it manages. 
  
  - [TakeDamage(float dmg)](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/6a1ac0aa94ac47e06293623e1a71a3e0aaf3677c/Assets/Scripts/PlayerHealth.cs#L44-L54) is in charge of updating a player's health changes and notifying GameManager of health changes. It destroys the player object if the currentHealth passed in is less than 0. 

  - The players can take damage in two cases:
      1. Collision from an enemy projectile
      2. The player's proximity to a planet
         - In [Update()](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/6a1ac0aa94ac47e06293623e1a71a3e0aaf3677c/Assets/Scripts/PlayerHealth.cs#L34), the player continously takes damage until they are no longer within the minimum distance threshold.
         - In [TakeOrbitDamage(float distance)](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/6a1ac0aa94ac47e06293623e1a71a3e0aaf3677c/Assets/Scripts/PlayerHealth.cs#L60-L67), the damage taken is determined by a distance and damage factor:
             - As the player gets closer to the planet, it takes more damage. The distance factor is calculated by (1 - distance/orbitRadius)^2. 
             - The damage factor is a constant value.
          
  - In the HealthBarController, I subscribed a [HandleHealthChange(int playerID, float currentHealth, float maxHealth)](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/8ec978729985d846fc5b1f46736a594614b1f2b3/Assets/Scripts/HealthBarController.cs#L70-L78) method to GameManager.instance.OnHealthChange event. 
      - It takes in 3 parameters: playerID, currentHealth, and maxHealth. The playerID needs to match the playerNumber associated with the health bar controller, which ensures that the health bar is only updated for the relevant player.
      - When the player dies, the health bar controller stops listening to health changes.
  - I also added the UI component in Jupiter scene. However, I'm not sure why but the healthbar UI canvas isn't displayed the same way on every device. 

  *Projectile Controller*: I added a projectile script to the projectile prefab. The projectile has a damage field and playerID to track where the projectile is coming from. If the [projectile collides](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/8ec978729985d846fc5b1f46736a594614b1f2b3/Assets/Scripts/Projectile.cs#L15-L27) with the other player, then it destroys itself.

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

[Trailor](https://youtu.be/Z78cWUokqOM)  

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

## Game Feel and Polish

*Level Design* - I created the [Jupiter map scene](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/commit/5de8c3adaa3cf1e48f1df90735b151f097e8bbad) with large planet and high gravity. This more accurately reflected our original image of the game, when compared to our older gameplay testing scene. This map design mitigated issues with players living planet gravitional pulls too quickly, this also gave players more space to manuevaer and fight in. Later on I added a [moon](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/commit/a7e9f1e55adf81dd5c1aac3b52f4fd8ea0b94088) to the jupiter map to make it more dynamic. I also felt this gave a better sense of direction for the players. My final major contribution to the map was adding a [boundary](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/main/Assets/Prefabs/Boundary.prefab) to prevent players from purposely flying away from Jupiter and extending matches. 

*Decoupling movement* - After Diego finish work on player movement I edited his class to [decouple](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/commit/36a4f9c9340338a4b1b02bb1d06fafbf0e821aa4) the inputs from player's movements. This was to prepair the code for Eric's input system to later use.

*Adjustments to Gravity System* - I simplified Diego's gravity control to only [consider force towards the planet](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/commit/e44ac56c5b7ce06b9cdbf1c23479192f8525dcda#diff-cf4309c7de7a548a6b48fd8c657fbb34208ed33315d183eb85b5bf0a42d21261L13). We intialize thought that having the gravitionally object force a circular motion would make the system nicer, but upon testing we found projectile behaviour jarring. This meant we then had an issue of projectile having very straight paths and not bending towards the planet. This led to my decision to add [linear drag](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Prefabs/Projectile.prefab#L121) to the project so It would natural decelerate, increase it's bend towards gravitontal objects. This inturn led to issues of the projectile not firing that far from the ship at certain angles as the gravity and drag cancel out firing force. I added a script to toggle [gravitional attraction](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Scripts/GravitonallyAttracted.cs#L5) of gravitional attracted objects. This script is accessed from [ProjectileController](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Scripts/ProjectileController.cs#L17) to create the delay effect. This meant that projectile went on very straight trajectories for a short time before quickly being bent toward Jupiter which was closer to the feel we wanted.  

*Adjustments to Movement System* - I adjusted player's [angular drag](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Prefabs/Player.prefab#L235) to prevent players from being lost in space and make them more quickly get attracted by Jupiters gravity.

*Debugging Player Collision with Own Projectiles* - Players colliding with their own projectile was in issue we had because we want to use unity force system to enact gravity on projectile but this would turn off if their became triggers. I tried [disabling projectile collision](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/cbb55a455b0b60e954fca60644456af31fe92225/Assets/Scripts/PlayerHealth.cs#L82) when they enter if their from the player, but this didn't solve the issue. So I increased the [linear drag](https://github.com/SamuelDMFerreira/2024_Game_Programming_Slingshot_Effect/blob/9fdeadffbf27e8d4bdf2e6e610ee130ba6293cd4/Assets/Prefabs/Player.prefab#L234) to mitigate the problem of ships proejectile rotating due to colliding with their own projectiles. *This project made me really annoyed at unity's physics system*.  
  

- 
**Document what you added to and how you tweaked your game to improve its game feel.**
