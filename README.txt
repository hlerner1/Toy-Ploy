---------------------------------------------

        Toy Ploy: A Compsci-576 Final Project

---------------------------------------------


---------------------------------------------
Team Members:
---------------------------------------------
- Cody Richter
- Hannah Lerner

---------------------------------------------
Work Done:
---------------------------------------------


Overview:
All of the scripts located in `Assets/Scripts` were created by us and us alone (the small exception to this is Guard and Looker which were made with help from https://www.red-gate.com/simple-talk/development/dotnet-development/creating-a-simple-ai-with-unity-and-c/ tutorial. We modified a significant portion of the logic within these files, but the base template came from the tutorial).
We collected all main game assets together and placed them in `Assets/MainGameObjects`



---------------
 Work Done Together
---------------
- Cody and Hannah created the tutorial level together (See tutorial level in video)
- Cody and Hannah both worked together on getting animations and animation controllers to work for both the player and the AI. We
did not create the animations ourselves, but integrated it into the other assets we found on the store such as the robot and enemy AI
ourselves.




---------------
 Cody's Work
---------------
- Cody created the level design for level 1 and level 2
- Cody implemented all of the audio in the game. Sounds are located in Assets/Audio and relevant lines of code are in (Assets/Character/CharacterFunctions/Scripts/PlayerScripts/MoveBehaviour.cs, Lines: 89-90, 144-154)
- Cody worked on the animation controller for the enemy and connecting it to the main game object (Assets/Character/CharacterFunctions/Animators/EnemyController.controller).
- Cody handled game logic of scene transitions, dying, and respawning. (EndGame.cs, Title.cs, Storyline.cs)
- Cody did a lot of work on the main game scene (all in Game.cs). The scene files are all found in `Assets/Scenes` and the assets used are found in Assets/MainGameObjects.

---------------
 Hannah's Work
---------------
- Hannah created much of the game logic for the AI with the assistance of this tutorial: https://www.red-gate.com/simple-talk/development/dotnet-development/creating-a-simple-ai-with-unity-and-c/
See guard.cs and looker.cs for this code.
- Hannah created a system to allow for easy additions of different AI toys that dealt different amounts of damage. This is guard.cs
- Hannah fine-tuned the existing AnimationController for the enemy AI (Assets\MainGameObjects\Enemies\AIController.cs)
- Hannah fine-tuned the player character controller (Setting movement specific variables in Assets\Character\CharacterFunctions\Scripts\PlayerScripts\MoveBehaviour.cs)
- Hannah modified some of the physics in the player character to be more realistic for this game (Kyle.cs)
- Hannah worked with the NavMeshAgents to allow for AI pathfinding (Guard.cs)

---------------------------------------------
Packages Used:
---------------------------------------------

- 3D Character Dummy: https://assetstore.unity.com/packages/3d/characters/humanoids/humans/3d-character-dummy-178395
- 3rd Person Controller + Fly Mode: https://assetstore.unity.com/packages/templates/systems/3rd-person-controller-fly-mode-28647
- Basic Motions FREE: https://assetstore.unity.com/packages/3d/animations/basic-motions-free-154271
- Bubble Font (Free Version): https://assetstore.unity.com/packages/2d/fonts/bubble-font-free-version-24987
- Cloth Animation Based Flag: https://assetstore.unity.com/packages/3d/props/exterior/cloth-animation-based-flag-65842
- Fantasy Skybox FREE: https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353
- Github for Unity: https://assetstore.unity.com/packages/tools/version-control/github-for-unity-118069
- Low Poly Crates: https://assetstore.unity.com/packages/3d/props/low-poly-crates-80037
- Pack Gesta Furniture #1: https://assetstore.unity.com/packages/3d/props/furniture/pack-gesta-furniture-1-28237
- Space Robot Kyle: https://assetstore.unity.com/packages/3d/characters/robots/space-robot-kyle-4696
- Tughues Free Wooden Floor Materials: https://assetstore.unity.com/packages/2d/textures-materials/wood/yughues-free-wooden-floor-materials-13213