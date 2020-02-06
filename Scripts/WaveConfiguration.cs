using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Wave Configuration")]
public class WaveConfiguration : ScriptableObject
{
    // Wave Configuration Attributes
    [SerializeField] Block blockToUse;
    [SerializeField] int numberOfBlocksToInstantiate;


    // list of methods
    public Block getBlock()
    {
        return blockToUse;
    }

    public int getNumberOfBlocksToInstantiate()
    {
        return numberOfBlocksToInstantiate;
    }




}
