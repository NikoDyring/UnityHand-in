# Unity QA Student Worker Assignments
Technical task to become a part of Unity's amazing team.
## Assignment 1
### Lurkcity
**_Lurkcity is a top-down zombie shooter, about Carl getting food for his fishes._**
**Features**
- 2D Movement  
    I've implemented simple 2D movement by using a rigidbody, therefore I was able to create movement by using Physics. In this case I've used MovePosition. I do this by taking my players input on the horizontal and vertical axes with the help of the Input.GetAxisRaw method. 

- Player model  
    By using KenneyNL's assets I've been able to smack on a sprite for walking around with the different weapons and reloading. Instead of creating my own assets for this task. I decided to use one of his packs I've previously purchased, simply to save time.

- Shooting  
    To implement shooting I had to make a decision if I was going to be implementing the mechanic with either physics by instantiating objects, or by using raycasts. I decided to go for physics as I wanted to have a more cartoony feel to the bullets as they are instantiated and can be customized with the spritesheet I've chosen to use for the task.

    For shooting I've created prefabs for my bullets as well to give them different looks if needed and to Instantiate the same prefab from a given weapon. In the end, I didn't get to use more looks for the bullets than one.

- 3 Weapons  
    For the weapons I decided to create 3 types. A pistol, a shotgun and a sub machine gun. To make these I decided to use Scriptable objects as they had a lot of the same properties such as firerate, damage, ammo etc. This was clearly a big timesaver as I initially started creating the pistol but later on changed it into a scriptable object and therefore it was a lot easier to create the other weapons by just changing some variables.

- 3 Enemy Types  
    I started creating 1 enemy type, which was a simple zombie, slow and with a lot of health. This made the game really easy. Therefore I decided to created 2 more zombies by copying my prefab and changing the sprite and health attributes to give it a nice feel of variety. For this task, I could've used scriptable objects for this as well to change the attributes to be more dynamic and fun to experiment with, but time was of the essence. 

    I decided to create a simple enemyspawner which utilizes 15 empty gameobjects as waypoints, which then chooses randomly between the 3 enemy types and randomly between the waypoints. By doing this I was making sure the level was never played the same way twice as there would be enemies scattered around the waypoints rather than predefined each time.

    This also saved me time instead by not having to place enemies by hand when creating the level.

- Sounds  
    I decided to find some sound effects for the game and downloaded the ones I saw fit from http://Freesound.org.
    
    Meaning weapons has got following sounds:
    Cocking sound,
    Shooting sound,
    Reloading sound
    and furthermore the shots has got impact sounds if they hit enemies.

    I also decided to implement an upbeat music track for the action level whereas the others don't have the most intrigiuing sounddesign as there's no music.

- Fader  
    I decided to create a fader between the level changes to let the player be more immersed instead of just a hard cut between the scenes.



## Assignment 2
**Statemodel is found inside the assignment folder**
* Created the statemodel using Visual Paradigm Online.
* As I've never made a statemodel before I'm not totally sure how to create a set of tests based on my model.

I have never used a state model before, but it gives a nice overview of what functionality and steps has to be taken in order to get to a goal in the end. This is surely something I'll spend some more time studying as it seems like a nice tool to have in ones toolkit. I've given my shot at it, hopefully It's not too far away from what a statemodel is.

I will research it my book called "Applying UML and Patterns: An Introduction to Object-Oriented Analysis and Design and Iterative Development", and hopefully have a better version ready once I recieve your feedback.

