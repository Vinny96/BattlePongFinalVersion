using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // VFX Variables
    [SerializeField] GameObject blockVfxEffect = null;

    // Block Audio Source
    [SerializeField] AudioClip blockAudioClip = null;

    // Other Block Variables
    [SerializeField] List<Sprite> listOfDamagedSprites = null;
    int hitsObtained;

    // debugging block variables
    [SerializeField] int numberOfHitsTaken;

    // Start is called before the first frame update
    void Start()
    {
        hitsObtained = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // use switch statement once everything else is fixed. 
        if ( hitsObtained == 0 && collision.gameObject.tag == "Ball")
        {
            hitsObtained++;
            numberOfHitsTaken = hitsObtained; // for debugging purposes.
            loadDamagedBlockSprites();
        }
        else if(hitsObtained == 1 && collision.gameObject.tag == "Ball")
        {
            hitsObtained++;
            numberOfHitsTaken = hitsObtained; // for debugging purposes.
            loadDamagedBlockSprites();
        }
        else if(collision.gameObject.tag == "Playerlaser")
        {
            Destroy(collision.gameObject);
            destroyBlock();
        }
        else if(collision.gameObject.tag == "EnemyLaserBreakable")
        {
            Destroy(collision.gameObject);
            destroyBlock();
        }
        else if(hitsObtained == 2 && collision.gameObject.tag == "Ball")
        {
            destroyBlock();
        }
    }

    // list of methods 
    private void loadDamagedBlockSprites()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = listOfDamagedSprites[hitsObtained-1]; // used to be -1
    }

    public void destroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockAudioClip, this.transform.position, 1.0f);
        Destroy(gameObject);
        GameObject blockVfxHandle = Instantiate(blockVfxEffect, this.transform.position, Quaternion.identity);
        Destroy(blockVfxHandle, 0.5f);
    }

    

}
