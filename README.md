# Transition System

A reusable scene and UI transition system for Unity.

Provides a collection of configurable transition effects that can be triggered from gameplay systems, including fades, slides, masks, growth effects, and animation-based transitions.

## Features

* Centralized transition management
* Multiple built-in transition types
* Fade transitions
* Slide transitions
* Grow transitions
* Mask transitions
* Animation-based transitions
* Configurable transition presets
* Reusable transition assets
* Plug-and-play `TransitionManager` prefab
* Example scene included as a package sample

## Installation

Install the package through the Unity Package Manager using your preferred package registry.

The package depends on the **Singleton** package.

## Basic Usage

Add the provided `TransitionManager` prefab to your scene.

The transition manager can then be accessed through its singleton instance.

```csharp
TransitionManager.Instance
```

Use the provided transition assets and transition types to configure the desired visual effect.

## Samples

An example scene is available through the Unity Package Manager:

**Package Manager → Transition System → Samples → Example**

The sample demonstrates the available transition effects and configuration options.

## Requirements

* Unity 6000.3 or later
* Singleton package

## License

See [LICENSE.md](LICENSE.md).
