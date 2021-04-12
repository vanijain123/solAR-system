using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOrbit : MonoBehaviour
{
    private AutumnWandController autumnWand;

    public GameObject autumn;

    // Start is called before the first frame update
    void Start()
    {
        autumnWand = autumn.GetComponent<AutumnWandController>();
    }

    // Update is called once per frame
    public void Rotate()
    {
        autumnWand.isRotating = true;
        Invoke("Reset", 10f);
    }

    private void Reset()
    {
        autumnWand.isRotating = false;
    }
}
