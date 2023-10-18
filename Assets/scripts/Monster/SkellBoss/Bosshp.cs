using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Bosshp : MonoBehaviour,IHitable
{
    public int maxbosshp = 500;
    public int bosshp = 500;
    public SpriteRenderer bosshit;

    public UnityAction Ondeaded;
    private void Awake()
    {
        bosshit = GetComponent<SpriteRenderer>();
    }
    public void TakeHit(int dagame)
    {
        SoundManager.Instance.PlaySFX("MonsterHit");
        bosshp -= dagame;
        if (bosshp > 0)
        {
            bosshit.color = new Color(255, 0, 0, 255);
            Invoke("prihit", 0.1f);
        }
        else if (bosshp < 0)
        {
            Ondeaded?.Invoke();
            Destroy(gameObject);
        }
     //   bosshit.color = new Color(255, 0, 0, 255);
     //   Invoke("prihit", 0.1f);
     
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

    public void die()
    {
        StartCoroutine(dieRountion());
    }

    IEnumerator dieRountion()
    {
        GameManager.Resource.Instantiate<Canvas>("UI/DieUI");
        yield return new WaitForSeconds(3f);
        GameObject player = GameObject.FindObjectOfType<Player>().gameObject.transform.GetChild(0).gameObject;
        Destroy(player);
    }
}
