using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerState : MonoBehaviour, IHitable
{
    public UnityAction Ondeaded;
    private Animator playeranim;
    private SpriteRenderer playerrender;

    private void Awake()
    {
        playeranim = GetComponent<Animator>();
        playerrender = GetComponent<SpriteRenderer>();
        GameManager.data.Set();
        Ondeaded += die;
    }
    public void OffDamage()
    {
        gameObject.layer = 6;
        playerrender.color = new Color(1, 1, 1, 1);
    }

    public void TakeHit(int dagame)
    {
        GameManager.data.curHp -= dagame;
        SoundManager.Instance.PlaySFX("playerhit");
  
        if (GameManager.data.curHp <= 0)
        {
            GameManager.data.curHp = 0;
            Ondeaded?.Invoke();
            //  GameManager.data.Set();
        }
        Debug.Log("»öº¯ÇÔ");
        gameObject.layer = 8;
        playerrender.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamage", 0.5f);

    }
    public void die()
    {
        StartCoroutine(dieRountine());
    }

    IEnumerator dieRountine()
    {
        SoundManager.Instance.StopBgm();
        SoundManager.Instance.PlaySFX("dead");
        playeranim.SetTrigger("die");
        transform.GetComponent<PlayerInput>().enabled = false;
        GameManager.Resource.Instantiate<Canvas>("UI/DieUI");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
