using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSun : MonoBehaviour
{
    private AcidWandController acidWand;

    public GameObject acid;
    // Start is called before the first frame update
    void Start()
    {
        acidWand = acid.GetComponent<AcidWandController>();
    }

    // Update is called once per frame
    public void Move()
    {
        acidWand.sun.transform.position = acid.transform.position;
    }
}
