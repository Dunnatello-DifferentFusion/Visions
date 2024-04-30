# Visions
## Dunnatello-DifferentFusion

### Project Objective
Our goal for this project was to design a video game in the Unity game engine featuring weapon physics simulation & game AI programming for our Advanced Game & Simulation Development course project.

This project involved game design, level design, weapon physics simulation, and a light focus on game AI (the AI just follows the player around using the NavMesh).

Our main objective was to simulate gun physics in a game, which we achieved in this project by following tutorials and prototyping our own systems.

## Visions
The game, <i>Visions</i>, is a FPS zombie shooter taking place in a futuristic dystopian city. Originally, we were intending to make a multiplayer 5v5 competitive movement shooter, but we discovered how difficult that would be to implement pretty quickly and pivoted to a more <i>reasonable</i> course project.

The game features realistic ballistic physics by utilizing raycasting along with Unity rigidbody motion for bullet gravity.

## Level Design
The game features an endless wave shooter that will continously spawn zombies until the player dies. Players can use the level design to outsmart the zombie opponents in order to survive longer.

<b>Why are the zombies dancing?</b>
The real question is: why not? Honestly, at the time, we did not have much experience with creating animations, so we used free animations included in the character package. However, we know about the ample amount of free animations available online now.

## Conclusions And Lessons Learned
### Weapon Physics & Handling
While making this game, we discovered how game weapons work and how to simulate a hybrid projectile/hitscan weapon accurately. We were able to learn how to create scriptable objects to make our weapon system modular and scalable.

### AI Navigation
This project taught us how to effectively use Unity's AI Navigation system fully to make AI bots that follow the player around the map. Our level design features verticality, so AI bots can use all of the available navigation tools to reach the player efficiently. Although the current AI bot behavior is simple (it only follows the player), it can be expanded in the future to feature more complex behaviors.

### Level Design
We used the grayboxing level design technique of designing the initial map layout before implementing 3D assets to complete the final design. Using this technique, we were able to plan out the level scale and features to ensure that the level would complement the gameplay. This also taught us the importance of using level design to make the game world seem larger than it actually is by using 3D assets to obscure sightlines. We also implemented natural barriers to the level so that players would be able to understand how to navigate through the level intuitively.

### Blood Splatter Effects
We additionally learned how to implement blood splatter on the screen to indicate that the player was taking damage. Implementing this feature allowed us to learn how to position UI elements in Unity canvases by giving us a better understanding of the Unity 2D positional system.

### Scope Reduction
This project also taught us on how to reduce scope creep to deliver a completed project. Our original idea was not feasible, so scaling down our game design allowed us to deliver a product with all of the functional requirements met.
## Team Members
| Team Member | Roles |
| ------------- | ------------- |
| <p align="center"><img src="https://avatars.githubusercontent.com/u/84809371" width="40"></img><br>[@DifferentFusion](https://github.com/DifferentFusion)</p> | Backend Developer, Game Design, Documentation |
| <p align="center"><img src="https://avatars.githubusercontent.com/u/11823777" width="40"></img><br>[@Dunnatello](https://www.github.com/Dunnatello)</p> | Backend Developer, UI Developer, Level Design, Documentation |

## Unity Information
Standard Render Pipeline  
Originally developed in Unity 2021.3.10f1 but upgraded to 2023.2.11f1.

## Credits
You can view the list of sources [here](https://docs.google.com/document/d/1kCJQO2Be8SUjDou7ko9dmy5VDGZGp_c4wOohntj0oFM).
