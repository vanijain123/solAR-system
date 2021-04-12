using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSunButtonController : MonoBehaviour
{
    private bool scaleSun;
    private AcidWandController acidWand;
    private float start;
    private Transform[] children;

    public GameObject acid;
    // Start is called before the first frame update
    void Start()
    {
        scaleSun = false;
        acidWand = acid.GetComponent<AcidWandController>();
        children = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleSun == true)
        {
            Vector3 currentScale = acidWand.sun.transform.localScale;
            //start = acidWand.sun.transform.position.x;
            float dist = (start - acid.transform.position.x)/50;
            Debug.Log("dist: " + dist);
            if (dist != 0 && start+dist<2 && start+dist<0.5)
            {
                children = new Transform[acidWand.sun.transform.childCount];
                int i = 0;
                foreach (Transform c in acidWand.sun.transform)
                {
                    
                    children[i] = c;
                    Debug.Log("moving object out of parent: " + c.name);
                    children[i].parent = null;
                    i++;
                }
                Debug.Log(children);
                acidWand.sun.transform.localScale = new Vector3(currentScale.x + dist, currentScale.y + dist, currentScale.z + dist);
                for (int x = 0; x < i; x++)
                {
                    Debug.Log(children[x].name);
                    children[x].SetParent(acidWand.sun.transform);
                }
                //foreach (Transform c in children)
                //{

                //    //Debug.Log("moving object back to parent: " + c.name);
                //    c.SetParent(acidWand.sun.transform);
                //}
            }
        }
    }

    public void ScaleSun()
    {
        scaleSun = true;
        start = acid.transform.position.x;
        Invoke("Reset", 10f);
    }

    private void Reset()
    {
        scaleSun = false;
    }
}
