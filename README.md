# Mimics Attack!

_Mimics attack! is an atmospheric First Person Shooter game where you need to survive the mimics and find the portal to another world!_

> Play it here: [Mimics Attack! on itch.io](https://tmseldon.itch.io/mimic-attacks) 


## Game design and technical challenges

While designing and developing this game, I found some interested points that I would like to list and detail. On future versions of this document, I will get more on depth on some of these elements.

- **Main goal**: the goal of this game was to develop an atmospheric game. Exploration is the key element that I wanted to implement into this experience. For that reason, it was important to take all the elements of the game and make them work together. It was important to create an interesting environment to explore, while there is some challenge for the player to survive.

- **Level Design**: In order to achieve this ominous and atmospheric feeling into the game, the first thing that I started playing with was the global lightning. After that, I started designing the terrain. The design of the level is very lineal, but I wanted to make it interesting by arranging different locations and items over the world. Furthermore, by maintaining the attack of the mimics in key locations, the player would have the sense of urgency to traverse the level.
About the visuals, I used post processing with the chromatic aberration, blur and vignette effects to create a more dense and dark feeling.
- **Music and sound FX**: for the selection of the song, I used a song composed by [Roboxel](https://roboxel.itch.io/) that it fits perfectly to what I have in mind for the game. Different sounds effects are from famous game such as Doom, Unreal Tournament, Castlevania, and others. Those are games that I played a lot long time ago. 
- **Easter Egg**: if you have played the game, you might notice that the terrain is open on its edges. There is no invisible wall that prevents you to fall from the edges, and this is intentional so the player can fall down. However, this fall last for a moment before the _game over_ screen appears. But, if the player is looking at the bottom, she will notice that is a giant white canvas with some drawings. This image is the first level mockup that I created.
- **Second Level - mini boss**: I have planned to add a second level where the player will face a mini boss. This will be updated on the next version of the game and published here and in my itch account. Also, I'm thinking on trying to save the states from one level to the other using scriptable objects. Even though, I could use the JSON Save System that I've implemented on _Smitty, the unplayed RPG_, I will try to make a simple system to test the differences.
