using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiater : MonoBehaviour
{
    // block instantiation variables
    [SerializeField] List<Transform> listOfWayPointsContainer; // this list will contain all of the waypoints that we will use. 
    [SerializeField] WaveConfiguration WaveConfigurationToUse;
    [SerializeField] bool isLooping = false;

    // block movement variables


    // Start is called before the first frame update
    IEnumerator Start() 
    {
        do
        {
            yield return StartCoroutine(instantiateBlocks());
        } while (isLooping);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // list of methods
    public int getNumbersOfBlocksToInstantiate()
    {
        int numberOfBlocksToInstantiate = WaveConfigurationToUse.getNumberOfBlocksToInstantiate();
        return numberOfBlocksToInstantiate;
    }
   
    public Block getBlock()
    {
        Block blockToInstantiate = WaveConfigurationToUse.getBlock();
        return blockToInstantiate;
    }

    public List<Transform> getListOfWayPoints()
    {
        return listOfWayPointsContainer;
    }

    // list of coroutines
    IEnumerator instantiateBlocks()
    {
        for(int numberOfBlocksInstantiated = 0; numberOfBlocksInstantiated <= getNumbersOfBlocksToInstantiate()-1; numberOfBlocksInstantiated++)
        {
            Instantiate(getBlock(), listOfWayPointsContainer[0].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f); // used to be 4.5f
        }
    }



   




}// will need to create a waveconfiguration asset file 
