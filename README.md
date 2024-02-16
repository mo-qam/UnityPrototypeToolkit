# UnityPrototypeToolkit
This repository contains a collection of Unity scripts designed to enhance game development workflows and add dynamic functionality to your projects. These scripts range from basic object manipulation, such as rotation and activation, to more complex behaviors like ragdoll physics and camera field of view (FOV) adjustments.

## Scripts Overview

### Rotate

The `Rotate` script provides an easy way to rotate game objects around their axes. It supports both forward and reverse rotations along the X, Y, and Z axes.

### RagdollController

`RagdollController` dynamically transitions a character model between an animated and a ragdoll state based on collisions, with options for automatic reset after a specified duration.

### RandomObjectActivator

This script randomly activates one object from a predefined list while ensuring all others are deactivated, useful for scenarios where a random selection from multiple objects is needed.

### CinemachineFOVController

Designed for use with Cinemachine Virtual Cameras, `CinemachineFOVController` adjusts the camera's field of view based on the speed of a target object, enhancing the perception of motion and speed.

## Getting Started

To use these scripts in your Unity project, follow these steps:

1. Clone this repository or download the desired scripts directly.
2. Import the scripts into your Unity project's `Assets` folder.
3. Attach the scripts to your game objects or cameras as needed.
4. Customize the public variables exposed in the Unity Inspector to fit your project requirements.

### Dependencies

- The `CinemachineFOVController` script requires the Cinemachine package. Ensure you have Cinemachine installed in your project (`Window > Package Manager > Cinemachine`).
---

Happy Coding!
