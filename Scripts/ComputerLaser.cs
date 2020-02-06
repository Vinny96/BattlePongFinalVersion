using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerLaser : MonoBehaviour
{
    // computer laser instantiater variables
    ComputerLaserInstantiater computerLIReference;


    // Start is called before the first frame update
    void Start()
    {
        computerLIReference = FindObjectOfType<ComputerLaserInstantiater>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    // methods


}
