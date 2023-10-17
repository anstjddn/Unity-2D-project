using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Bosshp : MonoBehaviour,IHitable
{
    public int bosshp = 500;
    public SpriteRenderer bosshit;

    public UnityAction Ondeaded;
    private void Awake()
    {
        bosshit = GetComponent<SpriteRenderer>();
    }
    public void TakeHit(int dagame)
    {
        bosshp -= dagame;
        bosshit.color = new Color(255, 0, 0, 255);
        Invoke("prihit", 0.1f);
     
    }

    void Update()
    {
        if (bosshp > 0)
        {
            Debug.Log(bosshp);
        }
        else if(bosshp < 0)
        {
            Ondeaded?.Invoke();
            Destroy(gameObject);
        }
    }
    private void prihit()
    {
        bosshit.color = new Color(255, 255, 255, 255);
    }
}
