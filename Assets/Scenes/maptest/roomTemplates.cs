using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public List<GameObject> bottom;
    public List<GameObject> top;
    public List<GameObject> left;
    public List<GameObject> right;

    public GameObject closeroom;

    public List<GameObject> rooms;
    public int va;
    public bool alladd;

    [SerializeField] GameObject player;




    public void Start()
    {
        StartCoroutine(roomroutin());
        player = GameObject.FindObjectOfType<Player>().gameObject.transform.GetChild(0).gameObject;
    }
    public void Reset()
    {
        foreach (var roomslist in rooms)
        {
            Destroy(roomslist.gameObject);
        }
        rooms.Clear();
    }

    IEnumerator roomroutin()
    {
        yield return new WaitForSeconds(1f);

   /*     while (va < 4)
        {
            GameManager.Scene.LoadSceneAsync("testest");
            yield return null;
        }
        if (va >4)
        {
            GameManager.Scene.LoadSceneAsync("testest");
        }
        if (rooms.Count > 15)
        {
            GameManager.Scene.LoadSceneAsync("testest");
        }*/


        if (va == 4)
        {
            foreach (var item1 in rooms)
            {
                if (item1.gameObject == closeroom)
                {
                    GameManager.Scene.LoadSceneAsync("testest");
                }
            }
            alladd = true;
            PlayerSet();
        }
        else
        {
            GameManager.Scene.LoadSceneAsync("testest");

        }
        yield return null;
    }

    public void PlayerSet()
    {
        SoundManager.Instance.PlayeBGM("Dungeon");
        player.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
    
    }

    public bool Check(bool alladd)
    {
        return alladd;
    }
}
