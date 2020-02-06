using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerLaserInstantiater : MonoBehaviour
{
    // computer laser instantiater variables
    ComputerPaddle computerPaddleReference = null;
    Vector2 computerLaserInstantiatorVector;
    Vector2 differenceVector;

    // Start is called before the first frame update
    void Start()
    {
        computerPaddleReference = FindObjectOfType<ComputerPaddle>();
        computerLaserInstantiatorVector = new Vector2(this.transform.position.x, this.transform.position.y);
        differenceVector = new Vector2(computerPaddleReference.transform.position.x - this.transform.position.x, computerPaddleReference.transform.position.y - this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        lockInstantiaterToPaddle();
    }

    // methods
    private void lockInstantiaterToPaddle()
    {
        computerLaserInstantiatorVector = new Vector2(computerPaddleReference.transform.position.x - differenceVector.x, computerPaddleReference.transform.position.y - differenceVector.y);
        this.transform.position = computerLaserInstantiatorVector;
    }

    

}
