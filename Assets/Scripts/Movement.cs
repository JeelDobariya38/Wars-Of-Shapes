using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        this.transform.position += movement.normalized * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Application.Quit();
        Debug.Log("Application Quit!!");
    }
}
