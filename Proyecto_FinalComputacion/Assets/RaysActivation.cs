using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysActivation : MonoBehaviour
{
    public bool activate=false; 
    public bool activateEnergy=false;
    public GameObject rays;
    public GameObject energy;
    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            rays.transform.localScale = Vector3.Lerp(rays.transform.localScale, new Vector3(4,4,4), 0.05f);
        }
        else
        {
            rays.transform.localScale = Vector3.Lerp(rays.transform.localScale, Vector3.zero, 0.05f);
        }

        if (activateEnergy)
        {
            energy.transform.localScale = Vector3.Lerp(energy.transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), 0.031f);

        }

    }


    public void ActivateEffect()
    {
        activate = true;
    }    
    public void DeactivateEffect()
    {
        activate = false;
    }public void ActivateEnergy()
    {
        activateEnergy = true;
    }
}
