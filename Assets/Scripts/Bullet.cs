using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0;

    private Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == this.transform.position) {
            DestroyGameObject();
        } else {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player")) {
            Debug.Log("Player Damage!!");
            DestroyGameObject();
        }
    }

    void DestroyGameObject() {
        Destroy(this.gameObject);
    }
}
