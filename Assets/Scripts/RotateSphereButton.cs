using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphereButton : MonoBehaviour
{
    private AcidWandController acidWand;

    public GameObject acid;

    // Start is called before the first frame update
    void Start()
    {
        acidWand = acid.GetComponent<AcidWandController>();
    }

    // Update is called once per frame
    public void RotateSphere()
    {
        acidWand.isRotating = true;
        Invoke("Reset", 10f);
    }

    private void Reset()
    {
        acidWand.isRotating = false;
    }
}
