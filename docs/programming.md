# Documentation

> [!IMPORTANT]
> We are depercating this docs.. As we are now, moving from unity to godot.. 
> But we still put this files just for furture reference for godot.. 
> As it a very general file and can work for godot too..
>
> We will soon provide a new docs or update infomation... Keep a eye here!!

Here, In this file you will documentaion of code. 

Also sometimes you maybe find unity terms like gameobjs in parentheses, 
Ignore them if don't come from unity background, It just for unity developer understanding..

## Movement Script

- **Summary**: Used for moving player in 4 direction. (2d space)
- **Intended Responsiblity**: Movement (Player).
- **Dependency**:
    - Godot InputMap (External Editor Assist Resolution)
    - Node2d (Inheritance)
- **Parameters**: Speed.
- **File**: [scripts/movement.gd](scripts/movement.gd)

It is decoupled from any node2d (gameobj).... Which mean you can apply it to gameobj to give it a movement behaviour.

To move node2d (player), It read four input action `move_left`, `move_right`, `move_up`, `move_down`. covert them into vector2 direction.
then, it increase magnitude of direction by speed. then it add the result in node2d position. make it move in that direction by speed.

---

<details>
  <summary>Unity Stuff, Yet Left To Migrate!!</summary>

## Health System Script (NoT MonoBehaviour)

- **Summary**: It create a health system that can use to manage health of gameobj.
- **Intended Responsiblity**: manage health stats gor any gameobj.
- **Parameters**: MaxHealth
- **External Interfaces**: OnHealthChanged, OnNoHealth
- Decoupled from any gameobj....

## IDamageable Script (Interface)

- **Summary**: Define a standarized way to give damage to a object.
- **Dependency**: relay on the implementing class to reslove HealthSystem dependency. In simpler word, the class implementing should expose its health system as property, most like as a readonly property.

## System Script

- **Summary**: It convert the gameobj its attached to as a don;t destory gameobj. and makes it a singleton.

## Score System Script

- **Summary**: It count the surival time of player, in update method and make a score system out of it. it also can be start or stop counting anytime.
- **Intended Responsiblity**: Manage Player Score System.
- **Dependency**: A text-mesh-pro-text gameobj for displaying score text. (Relay on External Resolution From Editor).
- Decoupled from any gameobj....

## Player Script

- **Summary**: It manage player stats, update the stats on ui & kind of control the game state.
- **Intended Responsiblity**: Manage Player Stats.
- **Dependency**: 
    - On Health System, for managing player health. (Internal Resolution)
    - On Score System, for getting player score. (External Editor Assist Resolution)
    - On two text-mesh-pro gui, for updateing ui. (External Editor Assist Resolution)
- **Parameters**: MaxHealth
- Decoupled from any gameobj.... which mean you can apply it to gameobj to give it a player behaviour.

## Enemy Script

- **Summary**: It make up the enemy's ai & give the attach gameobj ability to shoot and move towards player.
- **Intended Responsiblity**: Manage Enemy Stats & Responsible For Enemy Behaviour.
- **Dependency**: 
    - Bullet Prefab, for bullet gameobj. (External Editor Assist Resolution)
    - Rigidbody2d, for movement. (Internal Resolution)
    - Player Gameobj's Transform, for target to move towards. (Internal Resolution)
- **Parameters**: Speed, StoppingDistance, RetreatDistance, TimeBtwShoot
- Decoupled from any gameobj.... which mean you can apply it to gameobj to give it a enemy behaviour.


## Bullet Script

- **Summary**: It make up the bullet behaviour and provide a attach gameobj a behaviour to move towards target.
- **Intended Responsiblity**: For Bullet Behaviour & Damageing the collision obj.
- **Dependency**: 
    - Player Gameobj's Transform, for target to move towards. (Internal Resolution)
    - IDamageable, it kind of depend on it for damanging player. (...)
- **Parameters**: Speed, Damage.
- Coupled to player gameobj.... which mean you can't apply it anywhere and everywhere..... you can use only where you want bullet to move to player and behave like enemy bullet.

## Camera Follow Script

- **Summary**: Follow the player character around the game scene.
- **Intended Responsiblity**: For Focus Camera On GameObj.
- **Dependency**: 
    - Target Gameobj's Transform, for target to focus on during a game session. (External Editor Assist Resolution)
- **Parameters**: Offset & SmoothSpeed.

</details>
