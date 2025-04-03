using UnityEngine;

namespace WarsOfShapes
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private PlayerControls _controls;

        private Rigidbody2D _rb;
        private Vector2 _moveVelocity;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            _controls = new PlayerControls();
            _controls.Enable();
        }

        private void Update()
        {
            Vector2 movementInput = _controls.Player.Move.ReadValue<Vector2>();
            _moveVelocity = movementInput.normalized * _speed;
        }

        private void FixedUpdate() {
            _rb.MovePosition(_rb.position + _moveVelocity * Time.deltaTime);
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable() {
            _controls.Disable();
        }

        private void OnDestroy() {
            _controls.Disable();
        }
    }
}
