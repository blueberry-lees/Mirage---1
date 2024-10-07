using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformManager : MonoBehaviour
{
    public GameObject newPlateform1;
    public GameObject newPlateform2;

    public GameObject pathblock1;
    public GameObject pathblock2;

    public bool plateform1free;
    public bool plateform2free;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plateform1free)
        {
            newPlateform1.SetActive(true);
            pathblock1.SetActive(false);
        }
        if (plateform2free)
        {
            newPlateform2.SetActive(true);

            pathblock2.SetActive(false);
        }

    }
}
