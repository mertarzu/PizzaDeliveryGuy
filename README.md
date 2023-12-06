# Pizza Delivery Guy - Runner Game Prototype

## Overview
"Pizza Delivery Guy" is a Unity-based runner game where players take on the role of a pizza delivery courier which I developed in Unity as a five day project in November 2022. The game combines elements of navigation, strategy, and dynamic gameplay. Players deliver pizzas to customers while dealing with various challenges and obstacles.

## Features
- **Level-Based Gameplay:** Navigate through different levels, each with its unique layout and challenges.
- **Dynamic Pizza Stacking:** Watch as pizzas stack up on the motorcycle, swaying as the player moves through traffic.
- **Bezier Curve Movements:** Utilize quadratic and cubic Bezier curves for smooth object movements and transitions.
- **Interactive UI Elements:** Manage game progress through UI screens like MoneyView, LevelView, WinScreen, and LoseScreen.
- **Object Pooling System:** Optimize performance using a pooling system for managing game objects.
- **In-Game Economy:** Earn in-game currency for each successful delivery.

## Prerequisites
- Unity (Version 2021.3.32f1 or higher recommended)

## Installation
1. Clone the repository: `git clone [repository URL]`
2. Open the project in Unity.
3. Load the main scene and press play to start the game.

## Gameplay Mechanics
- **Control Mechanism**: Swipe to steer the courier along the road.
- **Collecting Pizzas**: Pick up pizzas from trucks and minibuses along the road.
- **Delivering Pizzas**: Deliver pizzas to customers or markers on the road to earn money.
- **Earning and Progression**: Earn money for each successful delivery, and use it to progress through the game.

## Scripts Overview
- `Bezier.cs`: Implements Bezier curve calculations for object movement.
- `UIView.cs` and subclasses: Manages various UI views within the game.
- `PlayerController.cs`: Handles player input and game state management.
- `PoolManager.cs` and related classes: Manages object pooling for efficient performance.
- Additional scripts include `GameManager.cs`, `LevelController.cs`, `PlayerMover.cs`, each contributing to different aspects of the game.

## License
This project is licensed under the [MIT License](LICENSE.md).

