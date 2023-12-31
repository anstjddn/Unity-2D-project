using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UPdownpotal : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            player = collision.gameObject;
            StartCoroutine(MoveRountin());
         //   collision.transform.position += transform.up * 30f;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            player = null;
        }
    }

    IEnumerator MoveRountin()
    {
        Time.timeScale = 0f;
        player.GetComponent<PlayerInput>().enabled = false;
        GameManager.Scene.LoadingUI.FadeOut();
        yield return new WaitForSecondsRealtime(1f);
        player.transform.position += transform.up * 30f;
        Time.timeScale = 1f;
        player.GetComponent<PlayerInput>().enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
        GameManager.Scene.LoadingUI.FadeIn();

       
    }
}
