using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPathing : MonoBehaviour
{
    // block pathing variables
    BlockInstantiater blockInstantiaterHandle;
    List<Transform> listOfWayPoints;
    int wayPointTraverserIndex;
    float blockTravellingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        blockInstantiaterHandle = FindObjectOfType<BlockInstantiater>();
        listOfWayPoints = blockInstantiaterHandle.getListOfWayPoints();
        wayPointTraverserIndex = 1;
        blockTravellingSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        getBlockMoving();
    }


    //methods
    private void getBlockMoving()
    {
        if (this.transform.position.x != listOfWayPoints[listOfWayPoints.Count - 1].transform.position.x)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, listOfWayPoints[wayPointTraverserIndex].transform.position, blockTravellingSpeed * Time.deltaTime);
            if(this.transform.position.x == listOfWayPoints[wayPointTraverserIndex].transform.position.x)
            {
                wayPointTraverserIndex++;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}// this code is going to be attached to the block prefab. 
