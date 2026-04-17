# 🎮 Quiz Battle RPG

A 2D quiz-based battle game built in Unity where knowledge becomes your weapon.
Answer questions correctly to defeat enemies, survive battles, and progress through increasingly difficult stages.

---

## 🚀 Features

* ⚔️ Turn-based battle system
* 🧠 Multiple-choice quiz gameplay
* 📚 Topic selection (Networking, Programming, General Knowledge)
* 👾 Multiple enemies with increasing difficulty
* ❤️ Dynamic HP system (Player & Enemy)
* 🎨 Animated characters with unique visuals
* 🌄 Background changes per enemy
* 🏆 Win / Game Over screens
* 📊 Score tracking system

---

## 🕹️ Gameplay

1. Select a topic from the main menu
2. Enter battle against enemies
3. Answer questions:

   * ✅ Correct → Enemy takes damage
   * ❌ Wrong → Player takes damage
4. Defeat all enemies to win
5. Survive as long as possible and maximize your score

---

## 🧩 Technologies Used

* Unity (2D)
* C#
* TextMeshPro (UI)
* Unity Animator System

---

## 📂 Project Structure

```plaintext
Assets/
├── Scripts/
│   ├── GameManager.cs
│   ├── QuestionManager.cs
│   ├── UIManager.cs
│   ├── MenuManager.cs
│   ├── Enemy.cs
│   └── BossBackgroundManager.cs
├── Animations/
├── Sprites/
├── Scenes/
│   ├── MainMenu.unity
│   └── Game.unity
```

---

## ⚙️ Setup Instructions

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/yourrepo.git
   ```

2. Open the project in Unity Hub

3. Open the `MainMenu` scene

4. Make sure scenes are added in Build Profiles:

   * MainMenu
   * Game

5. Press **Play**

---

## 🎯 Controls

* Mouse Click → Select answer
* Buttons → Navigate menu

---

## 🧠 Topics Included

* 🌐 Networking
* 💻 Programming
* 📘 General Knowledge

---

## 📊 Scoring

* Correct Answer → +10 points
* Wrong Answer → No points
* Final score displayed at end screen

---

## 🧨 Known Limitations

* No sound effects (can be added)
* Limited animation states (idle only)
* Static question set (no dynamic loading)

---

## 🚀 Future Improvements

* 🔊 Add sound effects and music
* 🎭 More animations (attack, damage, idle variations)
* 📈 Difficulty scaling per question
* 🧠 Smarter question randomization
* 🎨 Enhanced UI polish

---

## 👤 Author

Developed by Tanush

---

## 📜 License

This project is for educational and hackathon purposes.
