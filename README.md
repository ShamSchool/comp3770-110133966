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

# Lab 03

Editor version: 6000.3.25f1 LTS
Template: Universal 3D (URP)

1) Callback order
1. Unity calls awake and on enable for capsule, then sphere,then
cube. After this it starts each in the same order. 
2. It calls fixed update right after starting each asset
in the same order as q1. It calls update in the same order 
after fixed update in the same order and then calls late 
update in the same order after finishing the update calls.
3. Upon pressing play a second time, the order is identical
in both runs 

2) Components and exposed attributes
1. The cube holds a transform component, a mesh filter, a 
mesh renderer, a box collider and the lab03 logging script.
The lab03 logger is my script and it logs unity events
2. The fields of lab03 lifecycle logger that are shown are
loginterval, id. and logcount. The hidden ones are 
nextFixedlog, nextUpdateLog, and nextLateLog.
The part of the declaration that makes it shown are the
[serializefield], or by being public. 
3. Even though all three use the same script, since we changed
the loginterval value in the inspector it changes their rates.
4. Once play mode was stopped, unity restored the value that
was in logInterval. This showed that changes made during play
mode are restored after its complete. 

3) Lifecycle timeline
1. At t=3 when the capsule becomes active it calls
awake->OnEnable->Start->LateUpdate->Update->FixedUpdate
2. The lines that the console pritns at t=2 is Mark: Cube script: enabled = false
and at t=4 it calls MARK: Cube script: enabled = true
between these lines ti stops pritnign any update callbacks
3. At t=6 it calls MARK: Sphere: SetActive(false) and at
t=8 it calls MARK: Sphere: SetActive(true). betwene these two lines
the only thing called is sphere.ondisable
4. After being destroyed, the capsule calls OnDisable and Ondestroy

4) Frame rate and fixed step
1.Row                   30fps travel     120fps travel
  Move_Update_dt           22U            30.3U
  Move_Update_perCall      26U            55.8U
  Move_Fixed_dt            21.9U          30.2U
  Move_Fixed_perCall       21.9U          30.2U

2. Rows move_fixed_dt and Move_fixed_percall move atthe same speed for both frame rates
3. Rows move_update_dt and move_update_percall travel a different distance
at different speeds. This tells us that sicne it is dynamic instead of fixed it runs at a variable rate.

5)Update order
1. the fresh count during Update was unchanged and the stale one increased. 
It was the opposite for LastUpdate
2. The setting LastUpdate gives the follower the same position
that the leader has in the same frame
3. In the update lines the position that hcanges over time is 
the world position. The local position does not change and I beleive the reason
for this is that it is the local distance from the cube and the child

6)Interpolation
1. The difference of motion between fixed and interpolated is that
while fixed is at a constant speed, it looks choppier than smooth
even though they are both moving at the same speed
2. Interp_linear goes at a constant speed, smooth speeds up
in the middle and then slows down
3. with delta time unchecked Interp_smooth moves a
fixed amount update rather than scaling movement by elapsed time

7) Game loop
1. int game_loop(float dt)
{
    // Awake()       // runs once when the script is initialized
    // OnEnable()    // runs whenever the component becomes enabled 
    // Start()       // runs once before the first Update

    Input(dt);         // writes the variables of the game directly

    // FixedUpdate()   //runs at fixed time intervals
    // Update()         //runs once per rendered frame

    Action();          //writes the variables of the game directly

    // LateUpdate()     //runs once per rendered frame, after Update()

    Output();          //writes the variables the player perceives

    // OnDisable()    //runs when the component is disabled or becomes inactive
    // OnDestroy()     //runs when the object is destroyed

    return score();    // reads the variables, returns the score
}

int main()
{
    ...

    previous = Now();
    accumulator = 0;

    while (experience)
    {
        current = Now();
        dt = current - previous;
        previous = current;
        accumulator += dt;

        experience_score += game_loop(dt);
        t += dt;
        experience = t < experience_duration && !player_quit_level && !game_over;
    }
}

2. fixed update runs on fixed time intervals regardless or the rendered framerate.
3. Onenable runs when a component becomes enabled and ondisable runs when it is disabled.



8)Challenge
1.Each object stores its own direction in the idrection variable. THe direction
is chosen in the start call so each object gets its own when it starts
The update call moves each using its direction speed and delta time. Multiplying
by deltatime makes it so they all move at the same speed
2. an alternative technique i saw was to use fixedupdate with fixed deltatime
I chose update and deltatime because it adjusts movements ot the time between frames
and looks smoother.



# Lab 04
1) Text and binary files
1. Obj file stored as descriptions of mesh via numbers and characters, fbx is encoded.
2. Both files encode mesh data, obj stores it in vectors fbx stores encoded with stuff like unitscalefactor and frontaxis being visible text
3. obj = approx 7000 lines fbx is approx 14000. fbx is approx double the lines. In a binary representation, three 32-bit floating-point values require only 12 bytes in total because each float occupies 4 bytes.
4. png �PNG this helps a file recognize that its a png
  wav RIFFF/ Wav These readable identifiers indicate a RIFF-format file containing WAVE audio data.
  fbx Kaydara FBX Binary   This identifies the file as a binary FBX document.

2) Mesh data
1. Lab04 propA.obj has 7454lines 3780 faces after import, unity reported the same number. 
2. the model with the most triangles is lab04propC and it has 16604 triangles with about 1.41 per triangle on averagge 
3. v is vertex count , vt is uv, vn is  normals, f is triangles. 
4. read/write being enabled allows unity to keep mesh data accepsible to scripts after its been uploaded. It causes your game to use additional memory
5. mesh report finds the meshes, runs start and goes throguh each object in targets, finds each mesh used. After this it prints out information about the mesh. it reads vertexcount, tringle amount,uv amount, normal  vectors, and the size. It prints out vertecies, triangles, if theres uv, how many normals, and its size.

3) Imported assets
1. for the texture max size controls the resolution for the texture and compression controls how its compressed. for the sound load type controls how it loads data and compression format controls the compression. These only change for unity imports, the original files remain unchanged.
2. the library folder holds unitys imported asset data. Gitignore excludes it because it adds too many unessesary generated files that you can just get from assets. 

4) Prefabs
1. both instances show 25 as points, however instance 2 stays with the spin speed. the reason for this is that it has an override while the points were changed on the asset
2. prefab is a text file and the last three lines hold the values i edited
3. the point edit belongs to the prefab and the spin speed is for the instance
4. the code sets default values for spin speed,  name and points and the callback that runs the rotation is the update function. spin speed uses a floating point number

5) Runtime Instantiation
1. awake and onenable run before instantiate. start and update run after in the same frame.
2. total duration for 500 was 621.6 ms so about 1.24 on avg
3. parts of the game that benefits from instatniating over several frames is projectiles or enemies as they can make the game smoother, Another thing you can do is keep destroying and remakign the same prefab by  object pooling
4. the spawner starts a stopwatch for measuring and calculates columns, after the calculation it instantiates the copies and divvies them up in columns and rows. when the count is 10 or less the script logs information about the copy. finally it stops stopwatch and logs data. 

6) Data file and Managers
1. the value that changed is the points i skipped rebuildng the  game because it read the json file
2. json parse error because of the closing bracket being gone, if the file is invalid like that, datamanager should report the problem and fail intentionally instead of creating from invalid data
3. a text data file is way more readable and allows for easier editing
4. id matches id, prefab matches prefab, x y and z store position, points store points, spinspeed matches spin speed
5. the code finds the json file, reads alll of its contents and then converts it to an entity list, It loops throguh each identity, and stores it by id. Then adds methods to find entities by id or iteration. 

Part 2
1. the entitymanager asks the datamanager because the dataamanager already loads and stores the json data.
2. the log line entitymanager despawned entity_01 shows that the entity was despawned and remvoed from the directory by id. 
3. when an entity is spawned it calls awake and onenable during instantiate, its start runs before the first update. when it is despawned destroy removes it and then ondisable and ondistroy are called
4. manager demo checks the game time, when the time reaches 3 seconds it logs and despawns the fist entity, when it hits 5 it logs ans spawns again. Log lines that say MARK show these changes.
5. start calls spawnall and it loops throguh all entitydata and spawns each one using id. get searches the dictionary for the id and returns its object. Clear destroys all spawned entities, empties the directory, and logs that entitymanager was cleared

7) Scenes
1. while the game runs the hierarchy lists both the main scene and the lab4level
the entities spawned are in the main scene. 
2. once unity unloads lab4 level the objects that belong to it dissapear objects in the main scene stay
3. designers have to decide which scene has thespawned entities and if they will despawn upon scene change
4. lab4scene loader loads lab4level additively and then waits till it finishes loading to call spawnall so they spawn after the level is availible.

8) GIT LFS
1. shows version number, size and a hash that tells contents of file
2. The reason why git lfs isnt as heavy is because it stores all large data files in git lfs and points to them

9) Challange
1. the lab4 entitymanager owns the dictionary of live entities. I used the clear methdo to destroy old ones before new ones spawn. my controller uses time.time to check if 5 seconds have passed
2. I considered usign time.deltatime every frame but i decided to use time.time becuase it would be more imple to check when I had to switch.


# Lab 05

1) Experimental Scene
1. The script selects the next waypoint by storing them all in an array. It starts at the first then goes throguh the list. Once it makes its way throguh the list it repeats.
2. time.deltatime is used when calculating how far the target moves during each frame. It makes sure the target moves at a consistent speed.

2) Camera Projection
1. Changing the Fov changes how much of the scene the camera sees. A lower fov is more narrow and a higher wov is very wide and allows you to see more.
2. In perspective ode the objects looked smaller when the camera moved further away and larger when it was closer. In orthographic mode the objects kept the same size regardless of distance.
3. Objects closer than the clipping distance or too far away from the far clipping distance dissapeared.

3) Coordinate Transformation
1. The coordinates that remained the same were the worlds coodinates
2. The values that changed were the screen coordinates and the camera coordinates
3. The visible conditon is calculate if the target is in front of the camera and can be seen by the camera

4) Camera Tracking
1. The desired position is calculated by adding the cameras offset to the targets world positon. This is how it keeps the camera at a consistent distance.
2. Direct tracking immediately moves the caemera when the target changes direction, smoothtracking does a gradual change.
3. Tracking rate affects responsiveness because it is how quickly the camera approaches, a higher tracking rate means it responds faster
4. THe camera computers rotation seperately from positon because position is where the camera is while rotation is what its facing.

5) Light tracking
1. Directional light used parallel light rays, point light was in all directions from a single point, and spot light was a cone shape.
2. Light direction and surface orientation affected appearance by the direction determining which surface got light, SUfraces closer tot he light were brighter than surfaces facing away.
3. Increasing intensity made the objects brighter, Increasing range let the light reach objects further away.
4. Cast shadows convey spacial relationships because they help show the positon and distance of objects to the light source showing depth.

6) Dynamic lighting
1. THe current intensity is calculated to have a value between 0 and 1. the value is then passed into mathf.letp to go from minumum and maximum intensity
2. transition seconds control the duration of the lighting transition
3. changing intensity and color changes the brightness and the tint of the light

7) Design challange
1. The camera estimates the targets velocity by subtracting its previous positon from its current one and then dividing it by time.deltatime. then it multipies by prediction time and adds the result to the current positionn to determine future one
2. Prediction time changes the visible space by going further away with longer prediction time and remaining closer to target with shorter prediction time
3. at an abrupt direction change the camera can temporarily look in the wrong direction before updating to thw new one
4. direct tracking immediately oves and rotates, smooth does it gradually lagging behind, predictive tracking moves ahead of the targets current position. 
5. an improvement would be to smooth the velocity and limit the max distance. THis wouldstop the sudden direction changes making the camera look the wrong way.

