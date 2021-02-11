# AMovingExperience
My first unity game!

a. Your name - Lior Tal

b. UNI - ljt2136

c. Date of submission - 2/10/21

d. Computer platform - Mac

e. Mobile platform, OS version, and device name - 

iOS, Mac: Big Sur 11.1 iPhone: XS iOS 14.4, Lior Tal's iPhone 

f. Description of your project, what you did, and how you accomplished it - 

My project is a 3D Platformer controlled mostly with the phone's gyroscope. Starting as a ball you must navigate obstacles including a cannon, a seesaw, icicles falling from the sky, a rotating bridge, a rotating arm, and rings of fire. Over the course of the game you can upgrade your character from just a ball to a full player who can jump as well as slide. 

Beginning - To begin the project, I first added all of the player components to one platform, figured out how to move each one how I wanted with the gyroscope, and how to attach them to each other on collision. Using gyro.attitude to get the phones rotation in the x and z axes I was able to add force relative to how much the phone leaned in that direction to move the player based on rotation. The same was done with sliding movments for the other body pieces except they were translated. Once movement and transformations were completed I then created all the platforms, placed the player components on their respective platforms (1,3, and 5) and worked on platforms incrementally adding each one's specific obstacles. 

Platform 1 - I imported the cannon from the asset store and was able to detect collision with it through its collider. On collision I had 3 UI buttons pop up mapped to functions which aimed and shot it (based on the player facing the direction it was to be shot in)

Platform 2- The seesaw particularly gave me trouble as I originally tried to implement it with a hingejoint but didn't understand it and ended up using a rigidbody instead with code based on the rotation.

Platform 3 - With movement and transformations already done platform 3 was already completed.

Platform 4 - I struggled mostly with destroying instantiated objects in the coroutine but through docs and stackoverflow was able to work around it by destorying the clones based on their name (Clone). The rotating bridge wasn't too bad after seeing the rotate around function in the docs.

Platform 5 - With movement and transformations already done platform 5 was already completed.

Platform 6 - Using the rotate around function from teh rotating bridge it was easy to do the rotating arm I just had to position it.

Platform 7 - I made the ring models myself on blendr and found code through the docs for scaling them. Lea helped me especially for collisions with rings with the mesh collider.

Throughout this process the Unity docs were especially helpful in understanding what functions I could use for the desired effects. After the obstacles and platforms were completed I worked on features of the game such as the flashing light when injured of falling off the platform, the pause menu, the health bar, the timer, and the different camera angles. For this part the YouTube channel Brackeys was an enormous help. With the main scene completed I then worked on the main menu and controls scenes which were simple canvases, took some in game photographs for backgrounds, and added music as a finishing touch.

g. Any problems you overcame (both coding and technical)

My biggest challenge during the development of this game was learning Unity. This was my first experience with the software and it took me almost 2 weeks just to get comfortable with and remember how to navigate it. Coding challenges that stood out and challenged me were movement with the gyroscope (for a long time at first I was trying to us the Translate() function as opposed to adding force), the see saw (I originally tried to used a hinge joint but later realized I could just use a rigid body and code a function based on rotation when it leaned), the spikes (I had an especially challenging time with coroutines as they never seemed to work and once they did I struggled with deleting the instantiated objects), and jumping (registering multiple touches and registering touches in a particular place on the screen). Most of these problems were solved through research in the docs, some forums on stack overflow, and office hours.

h. A list of any free assets you used.

I made my own ring asset in Blendr
I used a cannon model asset called BattleCannon
I used a music asset from Cosmocat

Youtube Link of game demo: https://youtu.be/fYoYXcq5Sqk
