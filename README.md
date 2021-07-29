# Synthetic Data Generator
 Unity project for creating synthetically generated images for object detection and classification. Uses Perception package from Unity3D.
 
 ## Noisy Random Data
 The tutorial for the Perception package sets up a scene with a noisy distracting background and objects placed randomly in front. 
 
 ![noisy data](https://github.com/exiaohuaz/SamplePerception/blob/main/Images/rgb_30.png?raw=true)
 
 The scene consists of a simulation scenario, which contains a randomizer seed, number of iterations, and other parameters. Most importantly, it also contains the randomizers that produce the dataset:
 - Background objects: position, rotation, texture, hue
 - Foreground objects (stuff to detect): position, rotation
 - Lighting: hue, intensity
 
 The scene also contains a camera, which essentially takes annotated screenshots every frame of the simulation. 
 Put together, it looks like this:
 
 ![noisy scene](https://github.com/exiaohuaz/SamplePerception/blob/main/Images/Screenshot%202021-07-28%20233932.jpg?raw=true)
 
 
 ## More Realistic Data
 The data from the prior scene showed some results in one test and performed abysmally in another. We decided to pursue creating a data generator that suits our purposes more closely. 
 
 ![realistic data](https://github.com/exiaohuaz/SamplePerception/blob/main/Images/rgb_481.png?raw=true)
 
 Same as before, the scene consists of a simulation scenario with randomizers, and a camera that annotates -- but several changes needed to be made.
 - Background: I textures a plane with wood (similar to my floor), but this can be replaced with any texture and can even be randomized in later tests.
 - Object placement: We want only one object per frame, and have it placed in a plausible manner on the surface of a table or floor. To do this I added a rigidbody and capsule collider so that it lands on the plane in a realistic position.
 - Lighting: For speed, the previous scene had no shadows. Real life definitely has shadows. I created a lighting rig using two spot lights similar to my setup of two lamps when taking the test data (real data). 
 - Camera: The camera fov has been modified to be closer to that of a phone camera's. It is now placed at an angle to the surface rather than perpendicular.
 
 ![realistic scene](https://github.com/exiaohuaz/SamplePerception/blob/main/Images/Screenshot%202021-07-28%20235616.jpg?raw=true)
 
 #### Randomizing:
 - I wrote a script to drop the objects at a random rotation within a certain location above the surface, so it lands differently every time.
 - Wrote scripts to randomize rotation of floor and lighting rig, instead of calculating position and angle of the camera moving in a circle around the model.
 - Wrote a script to randomize the angle of the camera within a certain threshold (0 is horizontal, 90 is vertical) with a distance parameter such that the camera is always looking at the model and is a fixed radius away from it.




