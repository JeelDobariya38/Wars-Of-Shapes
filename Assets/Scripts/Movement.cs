using UnityEngine;

namespace WarsOfShapes
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private int speed;
        [SerializeField] private PlayerControls controls;

        private Rigidbody2D _rb;
        private Vector2 _moveVelocity;

        public void Init(int speed)
        {
            this.speed = speed;
        }

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            controls = new PlayerControls();
            controls.Enable();
        }

        private void Update()
        {
            Vector2 movementInput = controls.Player.Move.ReadValue<Vector2>();
            _moveVelocity = movementInput.normalized * speed;
        }

        private void FixedUpdate() {
            _rb.MovePosition(_rb.position + _moveVelocity * Time.deltaTime);
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable() {
            controls.Disable();
        }

        private void OnDestroy() {
            controls.Disable();
        }
    }
}
