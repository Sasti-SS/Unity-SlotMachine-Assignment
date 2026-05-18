# Unity Slot Machine Game

## Overview

This project is a simple 3-reel Slot Machine Game developed in Unity for the Unity Slot Game Assignment.

The game includes reel spinning animations, betting system, jackpot win detection, audio feedback, responsive UI scaling, and WebGL browser support.

---

## Features

- 3 Reel Slot Machine
- Smooth Reel Spin Animation
- Lever Pull Animation
- Random Symbol Generation (RNG)
- Center-Line Win Detection
- Betting System
  - Bet 50
  - Bet 100
- Coin System
- Jackpot Popup Animation
- Win / Lose Audio Feedback
- Game Over Screen
- Play Again System
- Responsive UI Scaling
- WebGL Browser Build Support

---

## Winning Logic

Player wins when all center symbols match.

Example:

7 | 7 | 7

The player receives a payout based on the selected bet amount.

---

## Controls

| Action | Input |
|---|---|
| Bet 50 | Click BET 50 |
| Bet 100 | Click BET 100 |
| Spin Reels | Automatic after bet |
| Restart Game | Play Again Button |

---

## Project Structure

Assets/
- Animations
- Prefabs
- Scenes
- Scripts
- Sounds
- Sprites
- UI

---

## Technologies Used

- Unity 6
- C#
- TextMeshPro
- Unity UI System
- WebGL Build

---

## How To Run WebGL Build

1. Open the Build/WebGL folder
2. Run index.html using a local server or WebGL hosting platform
3. Play the game in browser

---

## Scripts

### SlotMachineManager.cs
Handles:
- Reel spinning sequence
- Betting system
- Coin system
- Win / Lose logic
- UI updates
- Game Over system

### ReelController.cs
Handles:
- Reel movement
- Symbol randomization
- Smooth stop alignment

### LeverAnimation.cs
Handles:
- Lever pull animation

---

## Bonus Features Added

- Betting System
- Jackpot Popup
- Game Over Screen
- Coin Economy
- Responsive UI Scaling
- Improved Reel Alignment
- Win Audio Synchronization

---

## Development Approach

The project was developed using clean and simple Object-Oriented Programming principles.

Main focus areas:
- Smooth gameplay feel
- Readable code structure
- Responsive UI
- Organized project structure
- WebGL compatibility

---

## Author

Unity Slot Machine Assignment Project

Developed using Unity and C#
