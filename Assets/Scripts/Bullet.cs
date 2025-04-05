using UnityEngine;

namespace WarsOfShapes
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 4;
        [SerializeField] private int damage = 2;

        private Transform _transform;
        private Vector3 _target;

        private void Awake() 
        {
            _transform = this.transform;
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        }

        private void Update()
        {
            if (_target == _transform.position) {
                DestroyGameObject();
            } else {
                _transform.position = Vector3.MoveTowards(_transform.position, _target, speed * Time.deltaTime);
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

        private void DestroyGameObject() {
            Destroy(this.gameObject);
        }
    }
}
