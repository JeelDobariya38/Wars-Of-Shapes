extends RigidBody2D

@export var speed: int = 100

var direction: Vector2

func _process(delta: float) -> void:
    direction = Input.get_vector("move_left", "move_right", "move_up", "move_down")

func _physics_process(delta: float) -> void:
    self.apply_impulse(direction * speed * delta)
