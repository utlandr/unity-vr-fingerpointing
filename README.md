# Networked VR/AR Unity Application

A 'barebones' implementation of a networked VR/AR Unity application with player models.
In its current state, this application was designed for two individuals to participate
in a simple 'finger-tracing' task in virtual reality. 


I have made this application using free Unity assets and open source software.
As such, all major features (networking, inverse kinematics, animations etc) are completely free
for you to use under the conditions of the GNU GPLv3. 


## Features

-	Multiplayer networking using the Mirror networking 
-	Compatable with all SteamVR supported devices 
-	*Decent* arm and leg tracking using Unity's Mechanim Inverse Kinematics Solver  
-	Implementation of layered animations to support IK movement and controller (hand) poses/gestures 

## Installation

### Requirements

- Unity 2019.x.xfx (may work on 2018 versions, but has not been tested)
- SteamVR version 2.x.x (1.x.x will not work)
- Mirror (via Unity Asset Store)



### Setup

This application has been tested to work on a simple host-client setup. Two machines under the same network
(each powering a VR/AR device) connect to other via local IP address. One machine instantiates a host server
that other machines can connect to. By default the game uses port 7777.

A server-client setup is also possible, but has not been thoroughly tested

The HTC Vive and the Samsumg Odyssey have both been tested and work. In theory, any headset that
is supported by SteamVR (Oculus, Valve Index, Other Windows Mixed Reality HMDs) should also work.


1. Clone using git:

    `git clone https://github.com/utlandr/unity-vr-fingerpointing`

2. Load the project into Unity Editor (most of the dependencies should install automatically. SteamVR may require an update if you have it already installed)

3. Press 'Play' to run the game in-editor (or build the project into an executable)

4. Setup host-client or server-client in the Networking UI

Done!


### Contact

Contact me via email (rbell11235@hotmail.co.nz) or raise an issue if you have any installation problems.



### Current Progress 

Currently, this project is extremely bloated. I have a bunch of prefabs, scripts, animations etc that 
are completely useless and need to be removed. 
