using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPdownpotal : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            MoveRountin();
            collision.transform.position += transform.up * 30f;
        }
    }

    IEnumerator MoveRountin()
    {
        Time.timeScale = 0f;
        GameManager.Scene.LoadingUI.FadeOut();
        yield return new WaitForSeconds(2f);
        GameManager.Scene.LoadingUI.FadeIn();
        Time.timeScale = 1f;
    }
}
