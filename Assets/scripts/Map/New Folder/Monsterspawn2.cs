using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Monsterspawn2 : MonoBehaviour
{
    public RoomState roomState;
    public List<GameObject> monsterList;
    public int rand;
    public int monsterNum;
    private bool isplayer;
    [SerializeField] public GameObject doorobj;
    public bool isopen;
    [SerializeField] public GameObject minimap;


    public void Awake()
    {
        roomState = GetComponentInParent<RoomState>();
        rand = Random.Range(3, 6);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !roomState.isclear && !isplayer)
        {
            doorobj.SetActive(true);
            isplayer = true;
            Debug.Log("몬스터생성");
            StartCoroutine(MonsterSpawn(rand));
            StartCoroutine(DoorClose());
        }
        if (collision.gameObject.layer == 6 && !roomState.isclear)
        {
            Debug.Log("이미만듬");
        }
        if(collision.gameObject.layer == 6 && roomState.isclear)
        {
            return;
        }

    }

    public void Update()
    {

        foreach (var monsterobj in monsterList)
        {
            if (monsterobj.gameObject == null)
            {
                monsterList.Remove(monsterobj);
            }
            else
            {
                Debug.Log("없다");
            }
        }

        if (!monsterList.Any() && isplayer && !isopen)
        {
            StartCoroutine(DoorOpen());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (var monsterobj in monsterList)
            {
                Destroy(monsterobj);
                monsterList.Remove(monsterobj);
            }
        }

    }
    IEnumerator MonsterSpawn(int montserNum)
    {
        int monstercount = 0;
        while (monstercount < rand)
        {
                float x = transform.root.position.x + Random.Range(-5, 5);
                float y = transform.root.position.y + Random.Range(-2, 3);
                GameObject monster = GameManager.Resource.Instantiate<GameObject>("Monster/Bansheel", new Vector2(x, y), Quaternion.identity);
                monsterList.Add(monster);
                monstercount++;
            yield return null;
        }
        yield return null;
    }

    IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(0.1f);
        Mapdoor[] door = doorobj.GetComponentsInChildren<Mapdoor>();
        foreach (var mapdoor in door)
        {
            mapdoor.Close();
        }
    }

    //클리어
    IEnumerator DoorOpen()
    {
        roomState.isclear = true;
        isopen = true;
        Mapdoor[] door = doorobj.GetComponentsInChildren<Mapdoor>();
        yield return new WaitForSeconds(0.1f);
        foreach (var mapdoor in door)
        {
            mapdoor.Open();
        }
        doorobj.SetActive(false);
        minimap.SetActive(true);
    }
}
