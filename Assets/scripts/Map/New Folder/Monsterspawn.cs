using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Monsterspawn : MonoBehaviour
{
    public RoomState roomState;
   // public List<GameObject> monsterList;
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
        if(!roomState.isinplayer&& collision.gameObject.layer == 6   && !roomState.isclear)
        {
            roomState.isinplayer = true;
            doorobj.SetActive(true);
            Debug.Log("몬스터생성");
            StartCoroutine(MonsterSpawn(rand));
            StartCoroutine(DoorClose());
        }
        if(collision.gameObject.layer == 6 && isplayer)
        {
            Debug.Log("이미만듬");
        }
    }

    public void Update()
    {
        foreach (var monsterobj in roomState.monsterList)
        {
            if(monsterobj.gameObject == null)
            {
                roomState.monsterList.Remove(monsterobj);
            }
            else
            {
                Debug.Log("없다");
            }
        }
        //몬스터 다잡으면 오픈
        if (!roomState.monsterList.Any() && !isopen)
        {
            StartCoroutine(DoorOpen());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (var monsterobj in roomState.monsterList)
            {
                Destroy(monsterobj);
                roomState.monsterList.Remove(monsterobj);
            }
        }

    }
    IEnumerator MonsterSpawn(int montserNum)
    {
        int monstercount=0;
        while (monstercount < rand)
        {
            int randomMonster = Random.Range(0, 2);

            if (randomMonster == 0)
            {
                float x = transform.root.position.x+ Random.Range(-5, 5);
                float y = transform.root.position.y+Random.Range(-2, 3);
                GameObject monster = GameManager.Resource.Instantiate<GameObject>("Monster/Bansheel", new Vector2(x,y), Quaternion.identity);
                roomState.monsterList.Add(monster);
                monstercount++;
            }
            if(randomMonster == 1)
            {
                float x = transform.root.position.x + Random.Range(-5, 5);
                GameObject monster2 = GameManager.Resource.Instantiate<GameObject>("Monster/Minotaurs", new Vector2(x, transform.root.position.y-2), Quaternion.identity);
                roomState.monsterList.Add(monster2);
                monstercount++;
            }
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
        Mapdoor[] door =  doorobj.GetComponentsInChildren<Mapdoor>();
        yield return new WaitForSeconds(0.1f);
        foreach (var mapdoor in door)
        {
            mapdoor.Open();
        }
        doorobj.SetActive(false);
        minimap.SetActive(true);
    }
}
