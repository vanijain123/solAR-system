using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSphereButton : MonoBehaviour
{
    private AcidWandController acidWand;
    private GameObject toBeDeleted;

    public GameObject acid;

    // Start is called before the first frame update
    void Start()
    {
        acidWand = acid.GetComponent<AcidWandController>();
    }

    // Update is called once per frame
    public void DeleteObject()
    {
        Debug.Log("Button pressed");

        if (acidWand.destroyObject && acidWand.isSelected)
        {
            Debug.Log("Autumn wans object hit " + acidWand.destroyObject.name);
            toBeDeleted = acidWand.destroyObject;
            Destroy(toBeDeleted);
        }
        
    }
}
