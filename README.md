# Unity-Object-Scattering-Tool
A simple tool that allows customizable scattering of objects across terrains in unity.

How to use - 

(recommended) 
Create a new empty GameObject in the hierarchy and name it "ScatterController" for example, then add the script to the 
GameObject. Everything that you can change will be in the inspector window where the script is located. Then create a folder in 
the main assets folder called "Resources". This is where the Empty GameObject containing all of the scattered objects will be saved.
(you CAN change the directory of where the prefabs save to, however it is not reccomended).

The script REQUIRES some things for it to run properly, such as the "Prefab Name" field, as well as the objects to be 
scattered, under "Scatter Objects". Most of the other settings are optional or not necessary. 

How it works -

The script works by generating random points, based on how many objects you want, and then instantiating the objects at those 
points as child objects to a master Empty GameObject. It also allows for max rotation of the objects on 3 axes. It then saves the 
master Empty to a prefab in the editor,  in the "Resources" folder. This makes it easy to move objects after the fact if necessary. 
Due to the fact that the generation is random, in its current state objects CAN intersect with each other.

(note: this script works when the game is started, so keeping it on the script on the GameObject after it has 
been used is discouraged, due to the fact that it will re-scatter the objects every time you hit play).

Enjoy!
