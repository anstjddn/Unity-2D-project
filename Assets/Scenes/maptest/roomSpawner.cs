using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    public int openingDir;
    // 1 botoom 위쪽에 배치           위에 sp
    // 2. top  아래쪽에배치            아래 sp
    // 3. left 로른쪽에 배치           오른쪽sp
    // 4. right 왼ㅇ쪽에 배치            왼쪽 sp

    private roomTemplates templates;
    private int rand;
    public bool spawned = false;

    private void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();

        Invoke("Spawn", 0.05f);
    }
    public void Spawn()
    {
        if (spawned==false)
        {
            if (openingDir == 1)
            {
                rand = Random.Range(0, templates.bottom.Count);
                Instantiate(templates.bottom[rand], transform.position, templates.bottom[rand].transform.rotation);
                if(rand == 3)
                {
                    templates.va++;
                    templates.bottom.Remove(templates.bottom[rand]);
                }
              
            }
            else if (openingDir == 2)
            {
                rand = Random.Range(0, templates.top.Count);
                Instantiate(templates.top[rand], transform.position, templates.top[rand].transform.rotation);
            }
            else if (openingDir == 3)
            {
                rand = Random.Range(0, templates.left.Count);
               
                Instantiate(templates.left[rand], transform.position, templates.left[rand].transform.rotation);
                if (rand == 2|| rand==3)
                {
                    templates.va++;
                    templates.left.Remove(templates.left[rand]);
                }

            }
            else if (openingDir == 4)
            {
                rand = Random.Range(0, templates.right.Count);
             
                Instantiate(templates.right[rand], transform.position, templates.right[rand].transform.rotation);
                if (rand == 2)
                {
                    templates.va++;
                    templates.right.Remove(templates.right[rand]);
                }
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("sppoint"))
        {
            if (collision.GetComponent<Dest>()==null &&collision.GetComponent<roomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closeroom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
