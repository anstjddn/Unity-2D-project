using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour
{
    public gundata data;
    [SerializeField] Scrollbar reloadingTiem;
    [SerializeField] Canvas reloadingTiemground;
    [SerializeField] public float curTime;
    [SerializeField] GameObject reloadeffet;

    public void Awake()
    {
        reloadingTiem.value = curTime / data.realoadtime;
        reloadingTiemground.gameObject.SetActive(false);
        reloadeffet.SetActive(false);
    }
   /* public void Reloading()
    {
       
         reloadingTiem.value += Time.deltaTime;
          reloadingTiemground.gameObject.SetActive(true);
          if (curTime/data.realoadtime >=1)
          {
              reloadingTiemground.gameObject.SetActive(false);
              reloadeffet.SetActive(true);
          }
    }*/

}

