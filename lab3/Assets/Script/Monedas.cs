using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public float veloAngular = 0;
    public GameObject prefab;
    private GameObject nuevo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(veloAngular, 0, 0) * Time.deltaTime);
        if (Input.GetButtonDown("Submit") && prefab && !nuevo)
        {
            nuevo = Instantiate<GameObject>(prefab, new Vector3(-3.3f, 1.17f, -2.57f), Quaternion.identity);
        }
    }
}
