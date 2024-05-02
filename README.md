<p align="center"><img src="https://github.com/Dunnatello-DifferentFusion/Visions/blob/main/GitHub%20Readme%20Assets/Visions%20Graph.png" /></p>

# Visions
## Dunnatello-DifferentFusion

### Project Objective
Our goal for this project was to design a video game in the Unity game engine featuring weapon physics simulation & game AI programming for our Advanced Game & Simulation Development course project.

This project involved game design, level design, weapon physics simulation, and a light focus on game AI (the AI just follows the player around using the NavMesh).

Our main objective was to simulate gun physics in a game, which we achieved in this project by following tutorials and prototyping our own systems.

## Team Members
| Team Member | Roles |
| ------------- | ------------- |
| <p align="center"><img src="https://avatars.githubusercontent.com/u/84809371" width="40"></img><br>[@DifferentFusion](https://github.com/DifferentFusion)</p> | Backend Developer, Game Design, Documentation |
| <p align="center"><img src="https://avatars.githubusercontent.com/u/11823777" width="40"></img><br>[@Dunnatello](https://www.github.com/Dunnatello)</p> | Backend Developer, UI Developer, Game Design, Level Design, Documentation |

## Visions
The game, <i>Visions</i>, is a FPS zombie shooter taking place in a futuristic dystopian city. Originally, we were intending to make a multiplayer 5v5 competitive movement shooter, but we discovered how difficult that would be to implement pretty quickly and pivoted to a more <i>reasonable</i> course project.

The game features realistic ballistic physics by utilizing raycasting along with Unity rigidbody motion for bullet gravity.

<p align="center"><img src="https://github.com/Dunnatello-DifferentFusion/Visions/blob/main/GitHub%20Readme%20Assets/Visions%20Isometric%20View.png" width="750" /></p>
<p align="center"><b>Figure 1:</b> We wanted our game to feature a chaotic urban environment that takes place in a dystopian/cyberpunk future.</p>

## Level Design
The game features an endless wave shooter that will continously spawn zombies until the player dies. Players can use the level design to outsmart the zombie opponents in order to survive longer.

<p align="center"><img src="https://github.com/Dunnatello-DifferentFusion/Visions/blob/main/GitHub%20Readme%20Assets/Visions%20Center%20Garden.png" width="750" /></p>
<p align="center"><b>Figure 2:</b> The map center is designed to be a focus point that the player can use to find their way around the map.</p>

<b>Why are the zombies dancing?</b>
The real question is: why not? Honestly, at the time, we did not have much experience with creating animations, so we used free animations included in the character package. However, we know about the ample amount of free animations available online now.

<p align="center"><img src="https://github.com/Dunnatello-DifferentFusion/Visions/blob/main/GitHub%20Readme%20Assets/Visions%20Gas%20Station.png" width="750" /></p>
<p align="center"><b>Figure 3:</b> We incorporated some open areas for the player to use to their advantage.</p>

## Conclusions And Lessons Learned
### Weapon Physics & Handling
While making this game, we discovered how game weapons work and how to simulate a hybrid projectile/hitscan weapon accurately. We were able to learn how to create scriptable objects to make our weapon system modular and scalable.

### AI Navigation
This project taught us how to effectively use Unity's AI Navigation system fully to make AI bots that follow the player around the map. Our level design features verticality, so AI bots can use all of the available navigation tools to reach the player efficiently. Although the current AI bot behavior is simple (it only follows the player), it can be expanded in the future to feature more complex behaviors.

<p align="center"><img src="https://github.com/Dunnatello-DifferentFusion/Visions/blob/main/GitHub%20Readme%20Assets/Visions%20NavMesh.png" width="750" /></p>
<p align="center"><b>Figure 4:</b> The Unity AI Navigation system automatically creates fall points for the AI bots to use.</p>

### Level Design
We used the grayboxing level design technique of designing the initial map layout before implementing 3D assets to complete the final design. Using this technique, we were able to plan out the level scale and features to ensure that the level would complement the gameplay. This also taught us the importance of using level design to make the game world seem larger than it actually is by using 3D assets to obscure sightlines. We also implemented natural barriers to the level so that players would be able to understand how to navigate through the level intuitively.

<p align="center"><img src="https://github.com/Dunnatello-DifferentFusion/Visions/blob/main/GitHub%20Readme%20Assets/Visions%20Map%20View.png" width="750" /></p>
<p align="center"><b>Figure 5:</b> We originally drafted the floor plans for the map and then built the map around those initial designs.</p>

### Blood Splatter Effects
We additionally learned how to implement blood splatter on the screen to indicate that the player was taking damage. Implementing this feature allowed us to learn how to position UI elements in Unity canvases by giving us a better understanding of the Unity 2D positional system.

### Scope Reduction
This project also taught us on how to reduce scope creep to deliver a completed project. Our original idea was not feasible, so scaling down our game design allowed us to deliver a product with all of the functional requirements met.

## Future Plans
There is definitely potential for more features to be added to this project in the future.

### User Interface Improvements
Currently, the UI is minimal with only information about the weapon state. However, score and time survived information could be added as UI elements to make the game more engaging.

Additionally, a conclusion screen could show the player's final results and lead the player to a high scores menu with their top scores.

### Universal Render Pipeline Conversion
The project could be converted to the Universal Render Pipeline to improve graphical fidelity and allow for better lighting/shaders.

### Weapon Improvements
The weapon could be rendered on a separate camera layer so that the weapon does not clip (stick) into walls. Furthermore, the weapon could be animated to feature weapon shake and muzzle flashes to improve the feedback loop.

### Sounds
More sounds could be added to the environment to improve the user's immersion. Currently, the zombies do not make noise, but adding footstep and zombie noises could help the player know when zombies are near.

### Animations
The zombie animation controller could be improved to feature zombie walking and attacking animations.

### Map Improvements
The map can be improved by creating more interactive elements in the environment. The cop car could feature flashing lights, some cars could be on fire, and there could be some additional improvements to the map's lighting. Any additional special effects added to the map environment could add to the player's immersion and experience.

### Web Support
Since the project currently has low graphical overhead (since it features minimalistic graphics), it could potentially be converted to run in HTML5.

## Unity Information
Standard Render Pipeline  
Originally developed in Unity 2021.3.10f1 but upgraded to 2023.2.11f1.

## Credits
You can view the list of sources [here](https://docs.google.com/document/d/1kCJQO2Be8SUjDou7ko9dmy5VDGZGp_c4wOohntj0oFM).
