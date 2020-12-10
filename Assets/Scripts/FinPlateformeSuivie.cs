using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinPlateformeSuivie : MonoBehaviour
{
    public PlateformeSuivie p;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            p.EstDessus = false;
            GameVariables.lockBouge = false;
        }
    }
}
