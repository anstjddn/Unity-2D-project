using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static item;
using static UnityEditor.Progress;

public class player2euipment : MonoBehaviour
{
        
    [SerializeField] public GameObject[] weapons;
    //  public List<GameObject> weapons = new List<GameObject>();
    public GameObject curweapons;
    [SerializeField] public Inventoryeqip inventoryeqip;
    [SerializeField] public item weaponmanager;
    public bool setweapons1;
    public bool setweapons2;
    public Sprite curimage { get { return curweapons.GetComponent<Image>().sprite; } }
    public void Awake()
    {
       
       curweapons = weapons[0];
        weaponmanager = GameObject.FindWithTag("weapondata").GetComponent<WeaponDataManager>().item;
    }

    public void Update()
    {
        curweapons.SetActive(true);

        //스왑
        if (Input.GetKeyDown(KeyCode.Q))
        {
            curweapons.SetActive(false);
            curweapons = weapons[0];
        }
        //이동하면삭제
         if (!inventoryeqip.isequip1 && setweapons1)
        {
            Destroy(weapons[0].transform.GetChild(0).gameObject);
            setweapons1 = false;
        }

         // 데이터에서 뒤져서 같은 프리팹생성
       if (inventoryeqip.isequip1 && !setweapons1)
        {
            foreach (var item1 in weaponmanager.iteminfos)
            {
                if (inventoryeqip.equip1.transform.GetChild(0).name == item1.name)
                {
                    if (item1.sworddata != null)
                    {
                      //  Vector3 wapospos = new Vector3(weapons[0].transform.position.x, weapons[0].transform.position.y + 0.15f, weapons[0].transform.position.z);
                        GameObject obj = Instantiate(item1.sworddata.swodrobj, new Vector2(transform.position.x,transform.position.y+0.4f), transform.rotation);
                      obj.transform.position += new Vector3(0, 0.15f,0);
                        obj.transform.parent = weapons[0].transform;
                        setweapons1 = true;
                    }
                    else
                    {
                        GameObject obj = Instantiate(item1.gundata.gunprefabs, transform.position, transform.rotation);
                        obj.transform.localScale = new Vector2(1,1);
                        //  obj.transform.position += new Vector3(0, 0.15f,0);
                        obj.transform.parent = weapons[0].transform;
                        setweapons1 = true;
                    }
                    
                   
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            curweapons.SetActive(false);
            curweapons = weapons[1];
           
        }
        if (!inventoryeqip.isequip2 && setweapons2)
        {
            Destroy(weapons[1].transform.GetChild(0).gameObject);
            setweapons2 = false;
          //  curweapons = null;
        }

        // 데이터에서 뒤져서 같은 프리팹생성
        if (inventoryeqip.isequip2 && !setweapons2)
        {
            foreach (var item1 in weaponmanager.iteminfos)
            {
                if (inventoryeqip.equip2.transform.GetChild(0).name == item1.name)
                {
                    if (item1.sworddata != null)
                    {
                        //  Vector3 wapospos = new Vector3(weapons[0].transform.position.x, weapons[0].transform.position.y + 0.15f, weapons[0].transform.position.z);
                        GameObject obj2 = Instantiate(item1.sworddata.swodrobj, transform.position, transform.rotation);
                        //  obj.transform.position += new Vector3(0, 0.15f,0);
                        obj2.transform.parent = weapons[1].transform;
                     //   obj2.transform.position = new Vector3(0,0.15f,0); 
                        setweapons2 = true;
                    }
                    else
                    {
                        GameObject obj2 = Instantiate(item1.gundata.gunprefabs, transform.position, transform.rotation);
                        //  obj.transform.position += new Vector3(0, 0.15f,0);
                        obj2.transform.localScale = new Vector2(1, 1);
                        obj2.transform.parent = weapons[1].transform;
                        setweapons2 = true;
                    }


                }
            }
        }

    }
}
