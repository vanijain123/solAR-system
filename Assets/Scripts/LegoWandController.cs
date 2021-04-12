
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LegoWandController : MonoBehaviour
{
    private GameObject planet;
    private GameObject moon;
    private GameObject collider;
    private GameObject clone;
    private bool isColliding;
    private bool isCollidingOrbit;
    private Material m;
    private bool selected;
    private GameObject selectedGameObject;

    public GameObject sun;
    public GameObject orbit;

    public GameObject PlanetBlue;
    public GameObject PlanetGreen;
    public GameObject PlanetRed;

    public GameObject MoonPink;
    public GameObject MoonWhite;
    public GameObject MoonGrey;



    public Material selectedMaterial;

    public ContactPoint contact;
    public Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        //set isColliding to false
        isColliding = false;
        isCollidingOrbit = false;
        selected = false;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerExit(Collider other)
    {
        collider = other.gameObject;
        Debug.Log(collider.name);

        if (collider.tag == "PlanetInstance")
        {
            Debug.Log("Trigger with Planet Instance");
            createOrbit(collider.gameObject, collider.tag);
            Invoke("Reset", 2.0f);
            //isColliding = false;
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collision with lego wand");
        contact = collision.contacts[0];
        pos = contact.point;
        //collider = collision.gameObject;
        //Debug.Log("collider.name: " + collider.name + " Debug Pos: " + posDebug);
    }

    private void OnCollisionExit(Collision collision)
    {

        collider = collision.gameObject;
        Debug.Log(collider.name);


        //if (isColliding) return;
        //else
        //{
        isColliding = true;
            // Creating orbits
            if (collider.name == "Sun")
            {
                Debug.Log("Collision with Sun");
                createOrbit(collider, collider.tag);
                Invoke("Reset",2.0f);
                //isColliding = false;
            }
            if ((collider.CompareTag("Planet") || collider.CompareTag("Moon")) && selected == false )
            {
                selected = true;
                Debug.Log("Planet or Moon selected");
                //GameObject p;
                selectedGameObject = collider;
                Debug.Log(selectedGameObject.name);
                m = collider.GetComponent<Renderer>().material;
                collider.GetComponent<Renderer>().material = selectedMaterial;

                // Reset material after 10 seconds
                StartCoroutine(ResetMaterial(collider, m));
            }
            // If a planet is selected
            if (selected == true)
            {
                if (collider.tag == "orbit")
                {
                    Debug.Log("Inside orbit");
                        var name = selectedGameObject.name;
                        if (name == "PlanetRed")
                        {
                            Debug.Log("Instantiating red planet");
                            Renderer rend = collider.GetComponent<Renderer>();
                            Debug.Log(rend);
                            float radius = rend.bounds.extents.magnitude/2;
                            Debug.Log(radius);
                            planet = Instantiate(PlanetRed, collider.transform);
                            selected = false;
                            planet.transform.position = pos;    
                        }
                        if (name == "PlanetGreen")
                        {
                            Debug.Log("Instantiating red planet");
                            Renderer rend = collider.GetComponent<Renderer>();
                            Debug.Log(rend);
                            float radius = rend.bounds.extents.magnitude / 2;
                            Debug.Log(radius);
                            planet = Instantiate(PlanetGreen, collider.transform);
                            selected = false;
                            planet.transform.position = pos;
                        }
                        if (name == "PlanetBlue")
                        {
                            Debug.Log("Instantiating red planet");
                            Renderer rend = collider.GetComponent<Renderer>();
                            Debug.Log(rend);
                            float radius = rend.bounds.extents.magnitude / 2;
                            Debug.Log(radius);
                            planet = Instantiate(PlanetBlue, collider.transform);
                            selected = false;
                            planet.transform.position = pos;
                        }
            }
                if (collider.tag == "OrbitPlanet")
                {
                    Debug.Log("Inside orbit");
                    var name = selectedGameObject.name;
                    if (name == "MoonPink")
                    {
                        Debug.Log("Instantiating pink moon");
                        Renderer rend = collider.GetComponent<Renderer>();
                        Debug.Log(rend);
                        float radius = rend.bounds.extents.magnitude;
                        Debug.Log(radius);
                        planet = Instantiate(MoonPink, collider.transform);
                        selected = false;
                        planet.transform.position = pos;
                    }
                    if (name == "MoonGrey")
                    {
                        Debug.Log("Instantiating pink moon");
                        Renderer rend = collider.GetComponent<Renderer>();
                        Debug.Log(rend);
                        float radius = rend.bounds.extents.magnitude;
                        Debug.Log(radius);
                        planet = Instantiate(MoonGrey, collider.transform);
                        selected = false;
                        planet.transform.position = pos;
                    }
                    if (name == "MoonWhite")
                    {
                        Debug.Log("Instantiating pink moon");
                        Renderer rend = collider.GetComponent<Renderer>();
                        Debug.Log(rend);
                        float radius = rend.bounds.extents.magnitude;
                        Debug.Log(radius);
                        planet = Instantiate(MoonWhite, collider.transform);
                        selected = false;
                        planet.transform.position = pos;
                    }
            }
        }
    }


    public IEnumerator ResetMaterial(GameObject sphere, Material m)
    {
        Debug.Log("Inside ResetMaterial");
        yield return new WaitForSeconds(30.0f);
        sphere.GetComponent<Renderer>().material = m;
        selected = false;
    }

    public void Reset()
    {
        Debug.Log("Inside Reset coroutine");
        //yield return new WaitForSeconds(2.0f);
        Debug.Log("After Reset Coroutine wait");
        isColliding = false;
    }

    private void createOrbit(GameObject sphere, string tag)
    {
        //clone = Instantiate(orbit, sphere.transform);
        GameObject clone = Instantiate(orbit, sphere.transform);
        clone.transform.localPosition = new Vector3(0, 0, 0);
        //clone.transform.localScale = new Vector3(0, 0, 0);
        if (tag == "PlanetInstance")
        {
            //clone.GetComponent<MeshCollider>().convex = true;
            ////clone.GetComponent<Collider>().isTrigger = true;
            //clone.GetComponent<Rigidbody>().isKinematic = false;
            clone.tag = "OrbitPlanet";
            //clone.transform.Rotate(0, -10f, 0, Space.Self);
        }
    }
}
