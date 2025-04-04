# GodotHawk

This project is an attempt to port the excellent suit of tools known as UnityHawk created by the plunderludics working group. 

See the original project [here](https://github.com/plunderludics/unity-hawk).

## UnityHawk

![demo](https://github.com/plunderludics/unity-hawk/assets/8207025/24774607-7bb0-4ba1-9130-4073f39bb883)

UnityHawk lets you run emulated games within a Unity project, using [BizHawk](https://tasvideos.org/BizHawk).

Made as a tool for the development of [plunderludics](https://plunderludics.github.io/).

Only works on Windows currently. Works best with Unity 2022.2 or later.

Under development, may have bugs; issues, feature requests or contributions are welcome.

## Installation
Add these two lines under `dependencies` in your `manifest.json`:
```
"org.plunderludics.unityhawk": "https://github.com/plunderludics/unity-hawk.git?path=/Packages/org.plunderludics.UnityHawk",
"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm"
```

Or, install using [openupm-cli](https://github.com/openupm/openupm-cli):
```
openupm add org.plunderludics.unityhawk
```

UnityHawk should then appear in the Package Manager window. From the Package Manager window you can import the sample called `Demo` for a simple example of how to use this package.

You will probably also need to install the BizHawk prerequisites, which can be installed via [this installer](https://github.com/TASEmulators/BizHawk-Prereqs/releases/download/2.4.8_1/bizhawk_prereqs_v2.4.8_1.zip).

## Usage
- Add an `Emulator` component to an object with an attached `Renderer`.
- Add the rom and savestate files you want to use somewhere in your Unity `Assets/` directory (plus config or lua files if needed).
- Drag those assets onto the corresponding slots on the `Emulator` component.
- If using a platform that requires firmware, put the firmware inside `StreamingAssets/Firmware/`.
- Hit play
  
## Features
- Enable 'Pass Input From Unity' to send keyboard input from Unity to Bizhawk (gamepad input not supported yet). If this isn't enabled Bizhawk will get input directly from the operating system.
  - You can specify the component used to handle input under 'Input Provider'. If unspecified it will default to `BasicInputProvider`, use a `GenericInputProvider` instead if you need more flexibility.
  - `InputProvider` also provides methods called `AddInputEvent` and `AddAxisInputEvent` which can be used to programmatically  add inputs.
  - Alternatively you can also create your own component that inherits from `InputProvider`.
- Enable 'Show Bizhawk Gui' to show the native Bizhawk window; useful for doing plunderludics development (finding save states, tweaking config & scripts, etc) without having to leave Unity
- \[experimental\] Enable 'Capture Emulator Audio' to route emulator audio to an AudioSource, allowing you to use unity's positional audio system or add audio effects
    - (unfortunately the current implementation creates some latency and sometimes distorted audio, especially with multiple emulators running concurrently)
- The live emulator graphics can be grabbed in code via the `Emulator.Texture` property.
- The `Emulator` component provides an interface to basic Bizhawk API methods: `Pause()`, `Unpause()`, `FrameAdvance()`, `LoadState(Savestate s)`, `SaveState(string path)`, `LoadRom(Rom r)`. Use the `ApiControls` component to use these methods directly from the Editor.
- Within a BizHawk Lua script, you can use the `unityhawk.callmethod(methodName, argString)` method to send and receive information from Unity. The method must be registered on the Unity side using `Emulator.RegisterLuaCallback`. See `RegisterMethodExample.lua` and `RegisterMethodExample` in the `Demo` sample for a brief example.


## Building and releasing
- Building (for Windows) should just work; the input files you choose (roms, firmware) will be copied into the build, as well as the necessary Bizhawk dependencies. (Building multiple scenes might work but is untested.)

## Implementation
The `Emulator` component spawns `EmuHawk.exe` as a child process which shares graphics and audio with Unity via [shared memory](https://github.com/justinstenning/SharedMemory).

UnityHawk uses a modified fork of BizHawk which is here: https://github.com/plunderludics/bizhawk/tree/unity-hawk

## Attribution
The included demo scene contains [this shader](https://github.com/yunoda-3DCG/Simple-CRT-Shader), [this model of a TV](https://sketchfab.com/3d-models/crt-tv-9ba4baa106e64319a0b540cf0af5aa9e), and [a rom of Elite for the NES](http://www.iancgbell.clara.net/elite/nes/index.htm).

## Contact
If you want help setting up the tool, or you are interested in contributing, or have any other questions, feel free to join our discord: https://discord.gg/ATJSh8W8dp.
