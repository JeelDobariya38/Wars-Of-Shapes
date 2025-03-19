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
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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

        // Movement
        if (Vector2.Distance(transform.position, target.position) < retreatDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) > stoppingDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void Shoot() {
        Instantiate(bulletprefab, transform.position, Quaternion.identity);
    }
}
