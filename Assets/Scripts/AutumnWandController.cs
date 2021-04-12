using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AutumnWandController : MonoBehaviour
{
    
    private Material m;
    
    private int frames;

    public bool isSelected;
    public GameObject objectHit;
    public bool orbit;
    public GameObject sphereSelected;
    public Material selectedMaterial;
    public GameObject legoWand;

    public Button deleteOrbitButton;
    public Button scaleXOrbitButton;
    public Button scaleYOrbitButton;
    public Button rotateOrbitButton;

    public bool isRotating;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        orbit = false;
        isSelected = false;
        frames = 0;
        deleteOrbitButton.gameObject.SetActive(false);
        scaleXOrbitButton.gameObject.SetActive(false);
        scaleYOrbitButton.gameObject.SetActive(false);
        rotateOrbitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //if (orbit)
        //{
        //    orbitHit.GetComponent<Renderer>().material = selectedMaterial;
        //}

        //Debug.Log("Draw ray");

        frames++;
        if (isSelected && (frames%5 ==0) && isRotating)
        {
            Vector3 rot = legoWand.transform.eulerAngles;
            if (objectHit)
            {
                objectHit.transform.Rotate(rot);
            }
            //objectHit.transform.Rotate(rot);
        }


        
        if (orbit == false)
        {

            Vector3 right = transform.TransformDirection(Vector3.right);
            Debug.DrawRay(transform.position, right, Color.green);
            Debug.Log("Orbit: " + orbit);

            var ray = new Ray(transform.position, right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            {
                objectHit = hit.transform.gameObject;
                Debug.DrawRay(transform.position, objectHit.transform.position * 0.1f, Color.red);
                Debug.Log(objectHit.name);

                if (objectHit.tag == "orbit" || objectHit.tag == "OrbitPlanet")
                {
                    Debug.Log("Autumn wand collided with sphere");
                    isSelected = true;
                    //orbitHit = objectHit;
                    //objectHit = objectHit.transform.parent.gameObject;
                    Debug.Log("Autumn wand collided with sphere " + objectHit.name);
                    m = objectHit.GetComponent<Renderer>().material;
                    objectHit.GetComponent<Renderer>().material = selectedMaterial;
                    orbit = true;

                    //Button b = Instantiate(xAxis, canvas.transform);
                    deleteOrbitButton.gameObject.SetActive(true);
                    scaleXOrbitButton.gameObject.SetActive(true);
                    rotateOrbitButton.gameObject.SetActive(true);
                    scaleYOrbitButton.gameObject.SetActive(true);
                    Invoke("ResetOrbit", 10f);

                }

            }
            
        }

    }

    void ResetOrbit()
    {
        Debug.Log("Inside Reset Orbit");
        if (objectHit)
        {
            objectHit.GetComponent<Renderer>().material = m;
        }
        orbit = false;
        isSelected = false;
        deleteOrbitButton.gameObject.SetActive(false);
        scaleXOrbitButton.gameObject.SetActive(false);
        rotateOrbitButton.gameObject.SetActive(false);
        scaleYOrbitButton.gameObject.SetActive(false);
    }
}
