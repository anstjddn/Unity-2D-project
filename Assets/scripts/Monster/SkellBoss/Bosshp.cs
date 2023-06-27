using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshp : MonoBehaviour,IHitable
{
    public int bosshp = 500;
    public SpriteRenderer bosshit;
    public void TakeHit(int dagame)
    {
        bosshp -= dagame;
    }

    // Update is called once per frame
    void Update()
    {
        if (bosshp > 0)
        {
            Debug.Log(bosshp);
        }
        else if(bosshp < 0)
        {
            Destroy(gameObject);
        }
    }
}
