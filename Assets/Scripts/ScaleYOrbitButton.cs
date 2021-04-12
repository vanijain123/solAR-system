using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleYOrbitButton : MonoBehaviour
{
    private bool scaleOrbit;
    private AutumnWandController autumnWand;
    private float start;
    private Transform[] children;

    public GameObject autumn;

    // Start is called before the first frame update
    void Start()
    {
        scaleOrbit = false;
        autumnWand = autumn.GetComponent<AutumnWandController>();
        children = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleOrbit == true)
        {
            Vector3 currentScale = autumnWand.objectHit.transform.localScale;
            //start = acidWand.sun.transform.position.x;
            float dist = (start - autumn.transform.position.x);
            Debug.Log("dist: " + dist);
            if (dist != 0 && start + dist < 2 && start + dist < 0.5)
            {
                children = new Transform[autumnWand.objectHit.transform.childCount];
                int i = 0;
                foreach (Transform c in autumnWand.objectHit.transform)
                {

                    children[i] = c;
                    Debug.Log("moving object out of parent: " + c.name);
                    children[i].parent = null;
                    i++;
                }
                Debug.Log(children);
                autumnWand.objectHit.transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z + dist);
                if (children.Length > 0)
                {
                    for (int x = 0; x < i; x++)
                    {
                        Debug.Log(children[x].name);
                        children[x].SetParent(autumnWand.objectHit.transform);
                    }
                    //foreach (Transform c in children)
                    //{
                    //    //Debug.Log("moving object back to parent: " + c.name);
                    //    c.SetParent(autumnWand.objectHit.transform);
                    //}
                }

            }
        }
    }

    public void ScaleYOrbit()
    {
        scaleOrbit = true;
        start = autumn.transform.position.x;
        Invoke("Reset", 10f);
    }

    private void Reset()
    {
        scaleOrbit = false;
    }
}
