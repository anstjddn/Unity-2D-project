using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roomTemplates : MonoBehaviour
{
    public List<GameObject> bottom;
    public List<GameObject> top;
    public List<GameObject> left;
    public List<GameObject> right;

    public GameObject closeroom;

    public List<GameObject> rooms;
    public int va;
    public bool alladd;
    public GameObject startroom;

    public void Start()
    {
        StartCoroutine(roomroutin());
    }
    public void Reset()
    {
        foreach(var roomslist in rooms)
        {
            Destroy(roomslist.gameObject);
        }
        rooms.Clear();
    }
    IEnumerator roomroutin()
    {
        yield return new WaitForSeconds(1f);

        while (va<4)
        {
            SceneManager.LoadScene("testest");
            yield return null;
        }
        if (va == 4)
        {
            foreach (var item1 in rooms)
            {
                if(item1.gameObject == closeroom)
                {
                    SceneManager.LoadScene("testest");
                }
            }
            alladd = true;
        }
        if (va >= 5)
        {
            SceneManager.LoadScene("testest");
        }
        if (rooms.Count > 15)
        {
            SceneManager.LoadScene("testest");
        }
            yield return null;
    }

}
