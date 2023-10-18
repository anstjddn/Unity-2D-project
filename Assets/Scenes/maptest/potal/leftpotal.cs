using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class leftpotal : MonoBehaviour
{

   [SerializeField] private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
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
       
        GameManager.Scene.LoadingUI.FadeOut();
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerInput>().enabled = false;
        player.transform.position += transform.right * 17f;
        player.GetComponent<PlayerInput>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        GameManager.Scene.LoadingUI.FadeIn();
       
    }
}
