using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetController : MonoBehaviour
{
    private GameObject parent;
    private Material m;
    private GameObject o;

    public Material collideMaterial;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Renderer rend = parent.GetComponent<Renderer>();
        transform.Rotate(0, 0.01f, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        o = other.gameObject;
        Debug.Log("Collided! Need to change color");
        if (o.tag == "MoonInstance" || o.tag == "PlanetInstance")
        {
            Debug.Log("Changing color");
            m = GetComponent<Renderer>().material;
            GetComponent<Renderer>().material = collideMaterial;
            Invoke("Reset", 5f);
        }
    }

    private void Reset()
    {
        GetComponent<Renderer>().material = m;
    }
}
