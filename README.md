# Sweet Mayhem


<img src="Readme images/kapak.png">

---

## Team
#### Team Leader
* [Murat Türköz](https://www.linkedin.com/in/muratturkoz/)

#### Designers
* [Galip Diler](https://www.linkedin.com/in/galip-diler-01546b244/)
* [Alper Dinler](https://www.linkedin.com/in/alperdinler/)

#### Artists
* [Elvan Nilhan Korkmazel](https://www.linkedin.com/in/elvannilhankorkmazel/)
* [Eray Türker](https://www.linkedin.com/in/eray-türker-a731b8259/)

#### Developers
* [Baran Öner](https://www.linkedin.com/in/baran-öner-2a4a62157/)
* [Eyüp Öztürk](https://www.linkedin.com/in/eyupozturk04/)
* [Yaşar Düzgün](https://www.linkedin.com/in/yaşar-düzgün-72660726b)
* [Murat Türköz](https://www.linkedin.com/in/muratturkoz/)
* [Emircan İsanç](https://www.linkedin.com/in/emircan-isanc/)
* [Mert Çakır](https://www.linkedin.com/in/mert-cakir0)


## Summary
You play as a character who tries to survive against an endless amount of candy enemies and as you kill your enemies you will get upgrades to make you stronger.

## How to play
You move your character with a joystick and your character automatically shoots bullets/arrows the way it faces.

## Resources
[Drive](https://drive.google.com/drive/folders/1U0HxleN9pIbQaf0dj1RrxdRSQZVLE7zh?usp=sharing)

---

# Development process

* The name of the game: Sweet Mayhem 
* The team working on it: Udo Games NextGen Devs 2024 – Team 2
* Project duration: 1 week



## Theme
* While discussing it, one of our teammates came up with an idea regarding the theme of the game. This idea became the "Adventure Time" concept. All our teammates accepted this idea.
  
<p align="center">
<img  width="500" height="300" src= "Readme images/teama.png">
</p>



## Story
* In the story stage, we discussed the following ideas:
    * A scientist who creates candy creatures
    * Battling candy monsters coming out of his factory, a hunter who hunts candy creatures to feed his people.

* Finally, this idea resonated with the entire team, and we decided on this storyline:
    * A father who battles candy monsters to reach the witch who kidnapped his children.

# Designs

## Character Design
- Player

    * karakter tasarımı kısmında art ve designer ekibi olarak elinde yay bulunması kararı alındı. Bü yüzden karakterin robin hood vari bir karakter olması fikrini aldık.

    <img width="100" height="130" src="Readme images/Player.png">


- Enemies

    * Düşman tasarımlarında ise gene art ve design ekibindeki arkadaşlarımız Advanture time temasından esinledikleri için 1. seviye düşman için şeker fikrini, 2.seviye düşman tipi için cupcake fikrini, 3. seviye düşman tipi son tip düşman olacağı için daha güçlü gözükecek bir düşman tipi olmasına karar verdiler.

    * Type 1 Enemy

    <img width="100" height="130" src="Readme images/enemy1.png">

    * Type 2 Enemy

    <img width="100" height="130" src="Readme images/enemy2.png">

    * Type 3 Enemy

    <img width="100" height="130" src="Readme images/enemy3.png">

## Upgrades
<img width="400" height="250" src="Readme images/upgrades.png"><img  width="400" height="250" src="Readme images/upgrades-2.png">

## Environmental Designs
<p align="center">
<img  width="500" height="300" src= "Readme images/1.png">
</p>




## Mechanics
#### Core Game Loop:

* Describes the repetitive actions and processes that players engage in while playing, which are central to the game experience: 
You fight against procedurally spawning enemies. As you kill more enemies you will get more upgrade choices and you will try to get a higher score each time you try again.

#### Basic Definition of Main Mechanic: 

* Short description of main gameplay element: 
You move your character with a joystick and your character automatically shoots bullets/arrows the way it faces (there may be another joystick to control where you are firing at). 
Few enemy types will directly move towards the player to deal contact damage trying to kill it with every enemy type having different stats.

#### Game Object and Attributes: 

* Description of interactable game objects and their Attributes and States.
Walls/Obstacles: Blocks certain paths to create some depth.
Enemies: Will have different health, speed, damage modifiers. Will move towards the player and try to hit it.
Upgrades: The buffs player can choose upon levelling up. Will have different variations.


#### Character Upgrades
* COMMON TIER (%65 Chance to occur in upgrades section)
   * Strawberry Jam => +2.5 HP
   * Greater Strawberry Jam => +2.5 HP (previous tiers must be acquired first)
   * Delicious Strawberry Jam => +2.5 HP (previous tiers must be acquired first)
   * Epic Strawberry Jam => +2.5 HP (previous tiers must be acquired first)

   * Sharp Candy => +1 DMG
   * Sharper Candy => +1 DMG (previous tiers must be acquired first)
   
   * Tiny Switf Chocolate => +0.5 SPD
   * Medium Switf Chocolate => +0.5 SPD (previous tiers must be acquired first)
   * Tasty Switf Chocolate => +0.5 SPD (previous tiers must be acquired first)
   * Delightful Switf Chocolate => +0.5 SPD (previous tiers must be acquired first)

* MIDDLE TIER (%30 Chance to occur in upgrades section, if all common tier is unlocked these are guaranteed to show up)

   * Refined Jelly Strings => Arrow Velocity +%25
   * Juicy Jelly Strings => Arrow Speed +%25
   * Piercing Candies => Arrows will pierce through enemies However they will only deal the leftover damage. For example if an arrow dealt 3 damage to 1 health enemy the arrow will pierce through and can deal max 2 damage to next enemy.
   * Eyes Behind My Back => Character now shoots arrows both ways
   * Split Bow => Character will shoot arrows to left and right as well, however -0.25 Damage for each arrow (If this upgrade is chosen you can’t choose Concentrate Fire)
   * Concentrate Fire => Character now shoots three arrows to front with 30° degrees between each arrow, however -%25 attack speed (If this upgrade is chosen you can’t choose Split Bow)


* RARE TIER (%5 Chance to occur in upgrades section)
   * Additional Candies => Arrow Count + 1 to every direction that you are able to shoot (2 arrows fired at the same time)

* COMBINED TIER (%30 Chance to occur in upgrades section, if all the requirements are met)
   * Legendary Split Candy Bow => Player now shoots in 4 directions with +%25 attack speed (Eyes Behind My Back + Split Bow, must be acquired to get this upgrade or player will not see this upgrade)
   * Legendary Candy Arrows => Piercing arrows now deals full damage to next enemy. (Sharper Candy + Piercing Candies, must be acquired to get this upgrade or player will not see this upgrade)
   * Legendary Focus Candy Bow => Player now shoots three arrows to front and back with 30° degrees between each arrow +0.25 Damage
* REPEATING TIER (%65 Chance to occur in upgrades section)
   * Healing Jelly => Heals the player by 4 HP
   * Restoration Jelly => Heals the player by 8 HP
   * Holy Jelly => Heals the player to full HP

#### Summary
- Enemy Movement
    * Follow Algorithm

- Player Movement
    * Joystic

- Enemy Shoot
    * Collusion damage

- Player Shoot
    * Linked with joy

- Enemy Spawn
    * Out of camera

- XP
    * drop from enemies

- Buff
    * Linked with joy

- Score
    * Player earns points for each second passed, however, the score is multiplied by the Player's level coefficient for each second as the Player's level increases.

