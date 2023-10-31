using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Downpoatl : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            player = collision.gameObject;
            StartCoroutine(MoveRountin());

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
        player.GetComponent<PlayerInput>().enabled = false;
        GameManager.Scene.LoadingUI.FadeOut();
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerInput>().enabled = true;
        GameManager.Scene.LoadingUI.FadeIn();

    }
}
