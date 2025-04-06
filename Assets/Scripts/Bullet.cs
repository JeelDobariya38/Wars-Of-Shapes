using UnityEngine;

namespace WarsOfShapes
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float range = 5f;
        [SerializeField] private float speed = 4f;
        [SerializeField] private int damage = 2;
        
        private Vector3 _direction;
        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = transform.position;
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction.normalized;
        }

        private void Update()
        {
            transform.position += _direction * speed * Time.deltaTime;

            if (Vector3.Distance(_startPosition, transform.position) >= range)
            {
                DestroyGameObject();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        private void DestroyGameObject()
        {
            Destroy(this.gameObject);
        }
    }
}
