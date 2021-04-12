using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoSelectionScript : MonoBehaviour
{
    
    private MeshCollider mesh;
    private GameObject sphere;
    private GameObject planet;
    private RaycastHit hit;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Hit something");
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    sphere = collision.gameObject.GetComponent<GameObject>();
    //    planet = new GameObject();
    //    planet = sphere;

    //}
}
