using UnityEngine;

namespace WarsOfShapes
{
    public class Enemy : MonoBehaviour
    {
        public GameObject bulletprefab;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _stoppingDistance;
        [SerializeField] private float _retreatDistance;
        [SerializeField] private  float _timeBtwShoot;
        
        private Transform _target;
        private float _timeBtwShootCount;
        private Rigidbody2D _rb;
        
        void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            _rb = GetComponent<Rigidbody2D>();
            _timeBtwShootCount = 0;
        }

        void Update()
        {
            if (_timeBtwShootCount > _timeBtwShoot) {
                _timeBtwShootCount = 0;
                Shoot();
            } else {
                _timeBtwShootCount += Time.deltaTime;
            }
        }

        void FixedUpdate()
        {
            Vector2 direction = Vector2.zero;
            float distance = Vector2.Distance(transform.position, _target.position);

            if (distance < _retreatDistance) {
                direction = (transform.position - _target.position).normalized;
            }
            else if (distance > _stoppingDistance) {
                direction = (_target.position - transform.position).normalized;
            }

            _rb.MovePosition(rb.position + direction * _speed * Time.fixedDeltaTime);
        }

        void Shoot() {
            Instantiate(bulletprefab, transform.position, Quaternion.identity);
        }
    }
}
