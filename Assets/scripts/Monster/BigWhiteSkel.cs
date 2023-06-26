using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWhiteSkel : MonoBehaviour, IHitable
{
    [SerializeField] public int hp;
    private void Update()
    {

       if (hp > 0)
        {
            Debug.Log(hp);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TakeHit(int dagame)
    {
        hp -= dagame;
    }
}
