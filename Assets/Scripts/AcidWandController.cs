using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AcidWandController : MonoBehaviour
{
    
    //private GameObject destroyObject;
    private Material m;
    private Renderer rend;
    private int frames;
    private GameObject collision;
    private Transform[] children = null;

    private Material mSun;
    //private GameObject object;

    public bool isSelected;
    public GameObject destroyObject;
    public Material destroyMaterial;
    public Button deleteSphereButton;
    public GameObject legoWand;
    public Button scaleButton;
    public bool scale;
    public Vector3 scaleStart;
    public Button rotateButton;
    public bool isRotating;

    public bool isSunSelected;
    public GameObject sun;
    public Button moveSunButton;
    public Button scaleSunButton;
    public Button rotateSunButton;



    // Start is called before the first frame update
    void Start()
    {
        scale = false;
        isSelected = false;
        isRotating = false;

        deleteSphereButton.gameObject.SetActive(false);
        scaleButton.gameObject.SetActive(false);
        rotateButton.gameObject.SetActive(false);

        moveSunButton.gameObject.SetActive(false);
        scaleSunButton.gameObject.SetActive(false);
        rotateSunButton.gameObject.SetActive(false);
        isSunSelected = false;
    }

    // Update is called once per frame

    private void Update()
    {
        frames++;
        if (frames%5 == 0 && isRotating == true && destroyObject)
        {
            //Vector3 rot = legoWand.transform.eulerAngles;
            Vector3 rot = transform.eulerAngles;
            destroyObject.transform.Rotate(rot);
        }

        if (scale == true  && isSelected == true && destroyObject && scale)
        {
            Debug.Log("Scale planet inside acid want");
            
            Debug.Log("scaleStart received from scale button: " + scaleStart + ". Transform.position: " + transform.position);
            
            
            if (destroyObject.tag == "PlanetInstance")
            {
                Vector3 currentScale = destroyObject.transform.localScale;
                float dist = (scaleStart.x - transform.position.x) / 100;
                Debug.Log("dist: " + dist);
                if (dist!=0 && Mathf.Abs(currentScale.x+dist) < 0.5 && Mathf.Abs(currentScale.x+dist) > 0.02)
                {
                    children = new Transform[destroyObject.transform.childCount];
                    int i = 0;
                    foreach (Transform c in destroyObject.transform)
                    {

                        children[i] = c;
                        Debug.Log("moving object out of parent: " + c.name);
                        children[i].parent = null;
                        i++;
                    }
                    destroyObject.transform.localScale = new Vector3(currentScale.x + dist, currentScale.y + dist, currentScale.z + dist);
                    foreach(Transform c in children)
                    {
                        Debug.Log("moving object back to parent: " + c.name);
                        c.SetParent(destroyObject.transform);
                    }
                }
            }
            if (destroyObject.tag == "MoonInstance")
            {
                Debug.Log("scaling moon");
                Vector3 currentScale = destroyObject.transform.localScale;
                float dist = (scaleStart.x - transform.position.x);
                Debug.Log("dist: " + dist);
                //if (dist != 0 && currentScale.x+dist < 1 && currentScale.x+dist > 0.05)
                if (dist != 0 && Mathf.Abs(currentScale.x + dist) < 0.5 && Mathf.Abs(currentScale.x + dist) > 0.02)
                {
                    //foreach (Transform c in destroyObject.transform)
                    //{
                    //    Debug.Log("moving object out of parent: " + c.name);
                    //    c.parent = null;
                    //}
                    destroyObject.transform.localScale = new Vector3(currentScale.x + dist, currentScale.y + dist, currentScale.z + dist);
                    //foreach (Transform c in destroyObject.transform)
                    //{
                    //    Debug.Log("moving object back to parent: " + c.name);
                    //    c.SetParent(destroyObject.transform);
                    //}
                }
            }
            Debug.Log("destroyObject.transform.localScale: " + destroyObject.transform.localScale); 
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isSelected && collision.gameObject.tag == "orbit" && destroyObject.tag == "PlanetInstance")
        {
            Debug.Log("Changing orbit");
            //Transform spawnPoint = collision.transform.GetChild(0);
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;
            destroyObject.transform.SetParent(collision.transform, false);
            destroyObject.transform.position = pos;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (isSunSelected == false && !isSelected)
        {
            if (collision.gameObject.tag == "Sun")
            {
                //isSelected = true;
                Debug.Log("Sun collision. isSelected " + isSunSelected + ". " + collision.gameObject.tag);
                isSunSelected = true;
                mSun = sun.GetComponent<Renderer>().material;
                sun.GetComponent<Renderer>().material = destroyMaterial;
                
                moveSunButton.gameObject.SetActive(true);
                scaleSunButton.gameObject.SetActive(true);
                rotateSunButton.gameObject.SetActive(true);
                Invoke("ResetSun", 30.0f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collision = other.gameObject;   
        Debug.Log("Collision with acid wand. isSelected: " + isSelected + ". " + other.gameObject.tag);

        if (isSelected && collision.tag == "orbit" && destroyObject.tag == "PlanetInstance")
        {
            Debug.Log("Changing planet orbit");
            Transform spawnPoint = collision.transform.GetChild(0);
            destroyObject.transform.parent = collision.transform;
            destroyObject.transform.position = spawnPoint.position;
        }

        if (isSelected && collision.tag == "OrbitPlanet" && destroyObject.tag == "MoonInstance")
        {
            Debug.Log("Changing moon orbit");
            Transform spawnPoint = collision.transform.GetChild(0);
            destroyObject.transform.parent = collision.transform;
            destroyObject.transform.position = spawnPoint.position;
        }

        if (isSelected == false && !isSunSelected)
        {
            if (other.gameObject.tag == "PlanetInstance" || other.gameObject.tag == "MoonInstance")
            {
                Debug.Log("Planet collision. isSelected " + isSelected + ". " + other.gameObject.tag);
                destroyObject = other.gameObject;
                Debug.Log("Collision for destroy");
                isSelected = true;
                m = destroyObject.GetComponent<Renderer>().material;
                destroyObject.GetComponent<Renderer>().material = destroyMaterial;
                deleteSphereButton.gameObject.SetActive(true);
                scaleButton.gameObject.SetActive(true);
                rotateButton.gameObject.SetActive(true);
                Invoke("DestroyObject", 30.0f);
            }
        }
        

    }

    public void DestroyObject()
    {
        deleteSphereButton.gameObject.SetActive(false);
        scaleButton.gameObject.SetActive(false);
        rotateButton.gameObject.SetActive(false);
        scale = false;
        if (destroyObject)
        {
            destroyObject.GetComponent<Renderer>().material = m;
        }
        Debug.Log("Reset destroyObject");
        isSelected = false;
    }

    public void ResetSun()
    {
        moveSunButton.gameObject.SetActive(false);
        scaleSunButton.gameObject.SetActive(false);
        rotateSunButton.gameObject.SetActive(false);
        sun.GetComponent<Renderer>().material = mSun;
        isSunSelected = false;
        //isSelected = true;
    }
}
