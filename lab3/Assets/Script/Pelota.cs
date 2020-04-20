using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public float force = 0;
    Rigidbody rb;
    public float jumpForce = 0;
    int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Jump();
        
    }
    private void Jump() //Salte mientras la velocidad este cerca de 0
    {
        if (rb)
            if (Mathf.Abs(rb.velocity.y) < 0.05f)
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

    }
    private void FixedUpdate()
    {//Movimiento por fisica en x y  y por medio de WASD
        if (rb)
            rb.AddForce(Input.GetAxis("Horizontal")*force, 0, Input.GetAxis("Vertical")*force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moneda"))
        {
            Destroy(collision.gameObject);
             coins += 1;
        }
        else if (collision.gameObject.CompareTag("fuego") && coins <1)
            Destroy(gameObject);
    }
}
