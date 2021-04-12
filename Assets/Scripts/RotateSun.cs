using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSun : MonoBehaviour
{
    private bool rotate;
    private AcidWandController acidWand;

    public GameObject acid;
    // Start is called before the first frame update
    void Start()
    {
        rotate = false;
        acidWand = acid.GetComponent<AcidWandController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (rotate == true)
        {
            Vector3 rot = acid.transform.eulerAngles;
            acidWand.sun.transform.Rotate(rot);
        }
    }

    public void Rotate()
    {
        rotate = true;
        Invoke("Reset", 10f);
    }

    private void Reset()
    {
        rotate = false;
    }
}
