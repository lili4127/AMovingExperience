# AMovingExperience
My first unity game!

a. Your name - Lior Tal

b. UNI - ljt2136

c. Date of submission - 2/10/21

d. Computer platform - Mac

e. Mobile platform, OS version, and device name - 

iOS, Mac: Big Sur 11.1 iPhone: XS iOS 14.4, Lior Tal's iPhone 

f. Description of your project, what you did, and how you accomplished it - 

My project is a 3D Platformer controlled mostly with the phone's gyroscope. Starting as a ball you must navigate obstacles including a cannon, a seesaw, icicles falling from the sky, a rotating bridge, a rotating arm, and rings of fire. Over the course of the game you can upgrade your character from just a ball to a full player who can jump as well as slide. To begin the project, I first added all of the player components to one platform, figured out how to move each one how I wanted with the gyroscope, and how to attach them to each other on collision. Once movement and transformations were completed I then created all the platforms, placed the player components on their respective platforms, and worked on platforms incrementally adding each one's specific obstacles. Some obstacles were imported from the asset store such as the cannon and I just had to code the UI on collision as well as the functions to add force to the player. I made the ring models myself on blendr. Thought this process the Unity docs were especially helpful in understanding what functions I could use for the desired effects. With obstacles completed I worked on features of the game such as the flashing light when injured of falling off the platform, the pause menu, the health bar, the timer, and the different camera angles. For this part the YouTube channel Brackeys was an enormous help. With the main scene completed I then worked on the main menu and controls scenes, took some in game photographs for backgrounds, and added music as a finishing touch.

g. Any problems you overcame (both coding and technical)

My biggest challenge during the development of this game was learning Unity. This was my first experience with the software and it took me almost 2 weeks just to get comfortable with and remember how to navigate it. Coding challenges that stood out and challenged me were movement with the gyroscope (for a long time at first I was trying to us the Translate() function as opposed to adding force), the see saw (I originally tried to used a hinge joint but later realized I could just use a rigid body and code a function based on rotation when it leaned), the spikes (I had an especially challenging time with coroutines as they never seemed to work and once they did I struggled with deleting the instantiated objects), and jumping (registering multiple touches and registering touches in a particular place on the screen). Most of these problems were solved through research in the docs, some forums on stack overflow, and office hours.

h. A list of any free assets you used.

I made my own ring asset in Blendr
I used a cannon model asset called BattleCannon
I used a music asset from Cosmocat

Youtube Link of game demo: https://youtu.be/fYoYXcq5Sqk
