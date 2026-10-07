# comp3770-110133966
bb4498a93b * picture.png

# Lab 02 

Editor version: 6000.3.25f1 LTS
Template: Universal 3D (URP)

Interface explanation
Inspector: Shows object settings
Scene:Place to build world and move objects
Game:Shows what game is to player while running
Hierarchy:List of current objects 
Project: Filesystem for project

Start(): Happens at the beginning of program, initializes everything and starts program
Update(): Happens once per frame to update current gamestate

One concrete responsibility I noticed for the engine was to knwo to automatically call start and update when needed. A concrete example on my part was
to then print out a message whenever start or update occured.
