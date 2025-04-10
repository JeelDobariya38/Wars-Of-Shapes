using UnityEngine;

namespace WarsOfShapes
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        public Bullet bulletPrefab;

        [SerializeField] private int speed;
        [SerializeField] private float stoppingDistance;
        [SerializeField] private float retreatDistance;
        [SerializeField] private float shootingRange;
        [SerializeField] private float timeBtwShoot;

        private Transform _target;
        private float _timeBtwShootCount;
        private Rigidbody2D _rb;

        private float _stoppingDistanceSqr;
        private float _retreatDistanceSqr;
        private float _shootingRangeSqr;

        public void Init(int speed, float stoppingDistance, float retreatDistance, float shootingRange, float timeBtwShoot)
        {
            this.speed = speed;
            this.stoppingDistance = stoppingDistance;
            this.retreatDistance = retreatDistance;
            this.shootingRange = shootingRange;
            this.timeBtwShoot = timeBtwShoot;

            CacheSqrDistances();
        }

        private void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("Player")?.transform;
            _rb = GetComponent<Rigidbody2D>();
            _timeBtwShootCount = 0;

            CacheSqrDistances();
        }

        private void CacheSqrDistances()
        {
            _stoppingDistanceSqr = stoppingDistance * stoppingDistance;
            _retreatDistanceSqr = retreatDistance * retreatDistance;
            _shootingRangeSqr = shootingRange * shootingRange;
        }

        private void Update()
        {
            HandleShooting();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleShooting()
        {
            if (_target == null) return;

            Vector2 toPlayer = _target.position - transform.position;
            float distanceSqr = toPlayer.sqrMagnitude;

            _timeBtwShootCount += Time.deltaTime;

            if (_timeBtwShootCount >= timeBtwShoot && distanceSqr <= _shootingRangeSqr)
            {
                _timeBtwShootCount = 0f;
                ShootAtPlayer(toPlayer.normalized);
            }
        }

        private void HandleMovement()
        {
            if (_target == null) return;

            Vector2 toPlayer = _target.position - transform.position;
            float distanceSqr = toPlayer.sqrMagnitude;

            Vector2 direction = Vector2.zero;

            if (distanceSqr < _retreatDistanceSqr)
            {
                direction = (-toPlayer).normalized;
            }
            else if (distanceSqr > _stoppingDistanceSqr)
            {
                direction = toPlayer.normalized;
            }

            _rb.MovePosition(_rb.position + direction * speed * Time.fixedDeltaTime);
        }

        private void ShootAtPlayer(Vector2 direction)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetDirection(direction);
        }
    }
}
