# Documentation
## Movement Script

- **Summary**: It read the input from controls, and then use that value to move the rigidbody2d in to that direction, based on speed, on each fixedupdate.
- **Intended Responsiblity**: Player Movement.
- **Dependency**: Rigidbody2d, for movement. (Internal Resolution)
- **Parameters**: Speed & Control.
- Decoupled from any gameobj.... which mean you can apply it to gameobj to give it a movement behaviour.

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
