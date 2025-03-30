using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public GameObject bulletprefab;
    public float timeBtwShoot;

    private Transform target;
    private float timeBtwShootCount;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        timeBtwShootCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Shooting
        if (timeBtwShootCount > timeBtwShoot) {
            timeBtwShootCount = 0;
            Shoot();
        } else {
            timeBtwShootCount += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance < retreatDistance) {
            direction = (transform.position - target.position).normalized;
        }
        else if (distance > stoppingDistance) {
            direction = (target.position - transform.position).normalized;
        }

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void Shoot() {
        Instantiate(bulletprefab, transform.position, Quaternion.identity);
    }
}