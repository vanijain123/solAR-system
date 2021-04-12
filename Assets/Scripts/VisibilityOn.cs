using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityOn : MonoBehaviour
{

    private GameObject[] orbits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void VisiblityOn()
    {
        Debug.Log("Visibility On");
        orbits = GameObject.FindGameObjectsWithTag("orbit");
        foreach (GameObject orbit in orbits)
        {
            Debug.Log("Making orbits visible");
            orbit.GetComponent<MeshRenderer>().enabled = true;
        }

        orbits = GameObject.FindGameObjectsWithTag("OrbitPlanet");
        foreach (GameObject orbit in orbits)
        {
            Debug.Log("Making orbits visible");
            orbit.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
