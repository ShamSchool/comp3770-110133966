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
1) 
1. Obj file stored as descriptions of mesh via numbers and characters, fbx is encoded.
2. Both files encode mesh data, obj stores it in vectors fbx stores encoded with stuff like unitscalefactor and frontaxis being visible text
3. obj = approx 7000 lines fbx is approx 14000. fbx is approx double the lines. In a binary representation, three 32-bit floating-point values require only 12 bytes in total because each float occupies 4 bytes.
4. png �PNG this helps a file recognize that its a png
  wav RIFFF/ Wav These readable identifiers indicate a RIFF-format file containing WAVE audio data.
  fbx Kaydara FBX Binary   This identifies the file as a binary FBX document.

2) 

