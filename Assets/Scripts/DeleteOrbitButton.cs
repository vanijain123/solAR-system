using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOrbitButton : MonoBehaviour
{
    private bool isSelected;
    private AutumnWandController autumnWand;
    private GameObject toBeDeleted;


    public GameObject autumn;


    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<GameObject>().SetActive(false);
        autumnWand = autumn.GetComponent<AutumnWandController>();
        
    }

    // Update is called once per frame
    public void DeleteObject()
    {
        Debug.Log("Button pressed");

        if (autumnWand.objectHit && autumnWand.isSelected)
        {
            Debug.Log("Autumn wans object hit " + autumnWand.objectHit.name);
            toBeDeleted = autumnWand.objectHit;
            Destroy(toBeDeleted);
        }
        
    }
}
