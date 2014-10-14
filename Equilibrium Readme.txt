Hello from Madhouse Studios!
We are: Manson Chen, Woodrow Cizadlo, David Wesson, Peter Alexander and Benjamin Riddell.
This game was a project for our third-year software engineering course for Agile development.
It represents about 8 full days of actual programming work, due to the limitations of the course. Please note that we were not familiar with Unity when development started! This is not excellent code! It is code that mostly works.

If you're reading this, you're probably in possession of a copy of Equilibrium: The Game Without a Proper Subtitle. And you may be wondering exactly how this rickety bucket of bolts holds itself together!

So are we, honestly.

The game exists in three basic states- the opening menu screen, the primary game screen, and the end summary screen. A player who taps on the end summary screen will reset the scene back to the opening state (the opening menu). This allows the game to run basically constantly without needing to be reset manually.

=====================
THE MENU
=====================

The opening menu scene contains two primary objects- the Bag, a large central rectangle containing all of the objects that players are allowed to use during the primary game, and the Pallets, which are the players' toolkits during the game. Players are prompted by the HUD text to drag objects from the Bag to the Pallets. Objects from the Bag are at double the scale they appear in the game and on the pallets, and the pallets will grow to accommodate all of the chosen objects. When all of the objects have been dragged from the Bag, the game transfers from the opening menu to the primary game.

BUG REPORT: There is a known bug in this system. Attempting to drop two objects from the Bag onto Pallets simultaneously can cause the game to appear to lock up- this is simply due to the bag not properly clearing its objects. An attempt will be made to kill this bug before the handover. This bug can be completely avoided by making sure only one building is dropped at any moment.

During the transfer, any Pallets without cubes in them, and their associated HUD text, are removed from the gameworld. The world loads information from a stored Map file to generate terrain of various kinds. This terrain takes the form of a large grid of cubes which render without seams to give the appearance of a single, unified, seamless world made of obviously repeating tiles. Tiles take various forms- stone, grass, water, fish, et cetera. During this time, the Clock is also generated and added to the gameworld. The Clock becomes important during gameplay.

At this point, the scene is in the primary game screen, where it will stay until the Clock kills it.

=====================
THE GAME
=====================

Players can now place buildings from their Pallet onto the Terrain. Specific buildings have specific rules about where they can and cannot be generated- Farms, for example, have to be placed on Farmland; Cities can be built on Grass or Farmland; Mining can be placed on basically any tile with a Stone texture. These buildings are the core of the gameplay.

Buildings cost Materials to build. Materials, along with Food, Population and Environment, are the resources of Equilibrium. Buildings spend their Materials as soon as they are dragged from the Pallet, and will refund Materials if they are not bulit- for example, if they are placed on a Terrain which is illegal for them, or if they would put the players into a state of having negative Materials. Once placed, buildings can be deleted to refund half of their materials- this is achieved by pressing on their built versions, and then pressing on the red popup menu item.

UNIMPLEMENTED FEATURE REPORT: This popup menu also has a green icon for upgrading buildings. Upgrades are currently partially implemented, in that upgraded buildings have different names in the Unity engine, but they do not 

While buildings are being dragged, the game will generate a white "chalky" outline on the Terrain to display where the building will be built if released. While the buildings can be moved freely above the terrain, the blueprint is strictly locked to the terrain's grid and will hop from Terrain to Terrain. This allows players to see where their building will end up. In the engine, this outline is referred to as a Blueprint.

BUG REPORT: Due to an irritating necessity of Unity, Blueprints are implemented as being rigid objects. Rigid objects do not agree with occupying the same space, and the game engine will slow to a crawl if a pair of Blueprints are made to occupy the same space. This won't cause a crash, but it is worrying when it happens.

BUG REPORT: Tapping a building while it is on the Pallet will occasionally- very occasionally- leave a copy of that building wherever it would be built, without regard to what it is currently on. Power stations in the Pallet can be tapped to force them to build on water, et cetera. This bug persists despite numerous attempts to kill it.

Some built buildings generate materials of various and obvious kinds. Fishing and Farming generate Food, Mining and Lumber generate Materials, Cities generate gold. Other buildings modify the production of resources. Schools improve food production and improve the environment. Power stations improve material production. Factories improve material production more than Power stations. Most buildings have additional effects- farms also generate a moderate amount of Materials, for example- but all of them save Schools deal damage to the Environment, and all of them generate gold.

All of this happens on the clock's tick method. The Clock, generated when the Terrain is produced, holds on to the totals of player resources and calculates the new turn when it is tapped, displaying the current turn count. This starts from zero, because we are computer science people.

FOCUS: All of these systems are done through the BuildingTicker system. Every building that is created needs to have a BuildingTicker, which tracks where they can be placed, what materials they generate, and what effects they have on the environment. Adding new buildings will be quite simple- create a new building, add it to the Bag, make sure it has the Cube and its own extension of BuildingTicker scripts, and that all of the prefab of those scripts are filled in.

The game can be lost in two ways. Every round, half of the population eats a single unit of food. If the players' food store ever drops into negative numbers, the game is over. In addition, every round, most buildings deal damage to the environment. If the environment ever drops into negative numbers, the game is over. This moves the game into the final screen.

In addition, the game can be quit by holding down on the clock and pressing the red button that appears, or reset by pressing the green button that appears.

=====================
THE END SCREEN
=====================

The end screen is a large black box with text in front of it, telling players how they failed, what scores they ended up with, and inviting them to tap the screen to try again. The game tracks events from each round and produces an output summary. This screen is basically bug free at this point.

FOCUS: The game harvests far more data than is displayed in this screen- at a basic level, it takes in every action that every player does at every round. It could show a line graph with all the data we take in, but we didn't have time to implement that.

=====================
THE SYSTEM
=====================

So now you're wondering- how does this thing fit together?

The answer is, it's all in the Cube script. Basically everything that happens either relies on the Cube script or is inside the Cube script. Start there, the Clock, and the Bag, and you have almost all of the main systems that the game works with. The code's fully commented and fully fleshed out.