extends RigidBody2D

@export var speed: int = 100

var direction: Vector2

#region Don;t belong here!!!
const bullet_prefab = preload("uid://b3kbtukxyl3xh")
@export var shoot_point: Marker2D
#endregion

func _process(delta: float) -> void:
    direction = Input.get_vector("move_left", "move_right", "move_up", "move_down")
    
    # TASK: follow code don't belong in movement script. It need a refacting later.. It just for fast prototyping
    #region Don;t belong here!!!
    
    if Input.is_action_just_pressed("ui_accept"):
        var new_bullet = bullet_prefab.instantiate()
        get_parent().add_child(new_bullet)
        new_bullet.global_position = shoot_point.global_position
    #endregion


func _physics_process(delta: float) -> void:
    self.apply_impulse(direction * speed * delta)
