# Star-Trek

# Story Board

![](https://github.com/SeanLynch1/Star-Trek/blob/main/Images/StartTrek2.png)

# Game Information
## What Classes did I Write Myself?
-All classes, logic and the design pattern were thought up and written by me with the help of https://www.youtube.com/user/mikedolan03 simulating the final battle in the last scene

## Did I Use a FSM or Behaviour Tree or Similar?
-Yes, in the final scene a behaviour tree was used to determine the states of the ship AI. Each script which is responsible for a ships state inherits from the BTNode abstract class that contains an abstract function of type BTNodeStates(an interface) called "Evaluate()". The scripts then override this function, modifying the logic to suit their own needs, the function then returns success, failure or running to its return type (BTNodeStates) determining whether if the state has succeeded, whether it is still running or whether it has failed or not. The states are then selected in the AIController script which each AI ship gameobject has attached to it, this script will instance different scripts based on what state is has chosen. These scripts contain a constructor assigning values to different variables encapsulated in their associated overriden Evaluate functions each time they are instanced.

## Where did my Assets Come From?
-My assets came from sketchfab, mixamo, the unity assetstore (standard assets were used for textures), and freesounds.org for sound effects. All assets used can be found in the game credits below

## Additional Information Related to the Grading
-The use of a behaviour tree.
-The use of a singleton which acted as a data base used throughout the project.
-The use of delegates and events allowing for the reuse of functions and for clean organised code.
-The use of interfaces, abstract classes, polymorphism in general.

## What Graphical Techniques Were Used?
Particle Effect Systems, Textures and Flares(for the sunlight) all were used to contribute to the games aesthetic

# Game Credits
"Star Trek - Sovereign Class" (https://skfb.ly/6Rnw6) by Wholock is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Star Trek - Danube Class" (https://skfb.ly/6RZrA) by Wholock is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Star Trek Romulan Vreedex Class" (https://skfb.ly/UpA7) by Cleeve is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Star Trek - D'Deridex Class Warbird" (https://skfb.ly/6RCqE) by Wholock is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Star Trek - Klingon D5 Tanker" (https://skfb.ly/6WVNt) by Wholock is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Star Trek - Bird Of Prey" (https://skfb.ly/6Tx8p) by Wholock is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Star Trek - Arkonian Military Vessel" (https://skfb.ly/6WMSK) by Wholock is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Star Trek - Olympic Class" (https://skfb.ly/6RKGx) by Wholock is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Star Trek - Bajoran Raider" (https://skfb.ly/6WVOy) by Wholock is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Space Dock Nar30974" (https://skfb.ly/OY8r) by morenostefanuto is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Shuttle Typ 15" (https://skfb.ly/onnqF) by riker446 is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"An alternate Miranda Class" (https://skfb.ly/6SQzy) by Gingerswitch is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Assessment Two - AIE - Sci Fi Ship Interior" (https://skfb.ly/6y8ME) by Callum McKeown is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Control Panel" (https://skfb.ly/6FUvZ) by Vinny Passmore is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

"Control Painel" (https://skfb.ly/6Xs99) by FlavioBC is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

https://freesound.org/people/Buss1000/sounds/204968/

https://assetstore.unity.com/packages/2d/textures-materials/dynamic-space-background-lite-104606

https://freesound.org/people/pushkin/sounds/445372/

# AI Implementation Resources

https://www.youtube.com/channel/UC5h9h8heDq1bjsSBsoq0CQg
