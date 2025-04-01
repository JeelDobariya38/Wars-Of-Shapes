using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed = 2;
    [SerializeField] public int _damage = 2;

    private Vector3 target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    }

    private void Update()
    {
        if (target == this.transform.position) {
            DestroyGameObject();
        } else {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }


    private void DestroyGameObject() {
        Destroy(this.gameObject);
    }
}
