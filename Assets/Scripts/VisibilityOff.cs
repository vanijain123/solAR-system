using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityOff : MonoBehaviour
{

    private GameObject[] orbits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void VisiblityOff()
    {
        Debug.Log("Visibility Off");
        orbits = GameObject.FindGameObjectsWithTag("orbit");
        foreach (GameObject orbit in orbits)
        {
            Debug.Log("Making orbits invisible");
            orbit.GetComponent<MeshRenderer>().enabled = false;
        }

        orbits = GameObject.FindGameObjectsWithTag("OrbitPlanet");
        foreach (GameObject orbit in orbits)
        {
            Debug.Log("Making orbits invisible");
            orbit.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
