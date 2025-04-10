# CS 735 - VR Escape Room - Group H

## 📌 Project Overview

A virtual reality SciFi escape room experience developed as part of CS 735 coursework. Players solve puzzles and interact with objects to escape a locked virtual environment.

## 🛠 Technical Specifications

- **Unity Version**: 6000.0.38f1
- **Platform**: VR (Virtual Reality)
- **Genre**: Puzzle/Escape Room
- **Tested VR Systems**:
  - Meta Quest 2 (Android)
- **XR Configuration**:
  - **XR Plug-in Management**:
    - Oculus XR Plugin
  - **XR Interaction Toolkit**

## ⚙️ Installation

### Option 1: Clone via Git

```bash
git clone https://github.com/NuNuLwin/VR_EscapeRoom.git
```

### Option 2: Download ZIP

- Visit the [GitHub Repository](https://github.com/NuNuLwin/VR_EscapeRoom)
- Click **"Code"** → **"Download ZIP"**
- Extract the downloaded archive

## 🛠 Setup Instructions

After obtaining the project files:

1. **Launch Unity Hub**

   - Open the Unity Hub application on your computer

2. **Add Project**

   - Click "Add project from disk"
   - Navigate to and select the cloned/downloaded project folder
     ```
     /path/to/VR_EscapeRoom/
     ```

3. **Verify Unity Version**

   - Ensure you have **Unity 6000.0.38f1** installed
   - If needed, install the correct version via Unity Hub

4. **Open Project**

   - Select the project in Unity Hub
   - Click "Open" to launch in Unity Editor

5. **Open the Scene in Unity**

- Navigate to `Assets/Scenes/SciFi` and open the scene.

6. **Switch Platform**

- Go to **File** → **Build Settings** → Select **Android**
- Click **Switch Platform**

7. **Build and run with Device**

- Go to **File** → **Build Profiles** → Select **Build And Run**

## 🗂 SciFi Hierarchy Structure (Hierarchy Window View)

These are the top-level folders visible in Unity's Hierarchy window:

### 🧩 Dynamic

- Contains all puzzle game objects
- Includes interactive elements and mechanics

### ✈️ Teleport

- Holds teleportation area markers
- Contains destination points and visual indicators

### 💻 Interface

- Stores Welcome and Exit UI Canvas

### 🛋️ LivingRoom1

- Default environment setup
- Contains base scene objects and lighting

### 🎮 XR Components

#### XR Origin

- Main VR camera rig with hand controllers
- Handles player movement and height

#### XR Interaction Manager

- Core system for all VR interactions
- Required for grab/use functionality

#### XR Device Simulator

- Keyboard/mouse VR testing tool (development only)
- Test VR interactions directly in Unity Editor

## 🗂 SciFi Project Structure (Unity Project Window)

### 📁 Top-Level Folders

- **Assets** - Main project assets

### 📂 Assets Subfolders

- **Scripts** - All game interaction C# scripts
- **Audio** - Background music and sound effects
- **Video** - Coca Cola Advertisement videos
- **Prefabs** - All reusable game objects
- **Animation** - Door animations
- **Materials** - Surface textures
- **Scene** - SciFi scenes
- **Shader** - Votex Shader Animation for Trash Bin
- **TirgamesAssets** - Default SciFi assets from Unity

## 👥 Team Members

Nu Nu Lwin, Darshan, Swe Zin Oo
