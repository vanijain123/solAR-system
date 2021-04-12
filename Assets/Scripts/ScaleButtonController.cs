using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleButtonController : MonoBehaviour
{
    private AcidWandController acidWand;

    public GameObject acid;

    // Start is called before the first frame update
    void Start()
    {
        acidWand = acid.GetComponent<AcidWandController>();
    }

    public void ScalePlanet()
    {
        Debug.Log("Scale Planet button");
        acidWand.scale = true;
        acidWand.scaleStart = acid.transform.position;

        Debug.Log(acidWand.scaleStart);
    }
}
