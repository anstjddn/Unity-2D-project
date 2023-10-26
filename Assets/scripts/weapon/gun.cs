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
    public bool reloading;

    public void Awake()
    {
        reloadingTiem.value = 1;
        reloadingTiemground.gameObject.SetActive(false);
        reloadeffet.SetActive(false);
    }
   public void Reloading()
    {
        if(!reloading)
        StartCoroutine(ReloadingRoutine());
    }

    IEnumerator ReloadingRoutine()
    {
        reloading = true;
        SoundManager.Instance.PlaySFX("Reload");
        reloadingTiemground.gameObject.SetActive(true);
        while (reloadingTiem.value > 0)
        {
            reloadingTiemground.gameObject.SetActive(true);
            reloadingTiem.value -= Time.deltaTime / data.realoadtime;
            Debug.Log(reloadingTiem.value);
            yield return null;

        }
        if (reloadingTiem.value < 0)
        {
            reloadeffet.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            reloadingTiemground.gameObject.SetActive(false);
            reloadeffet.SetActive(false);
            reloadingTiem.value = 1;
            reloading = false;
        }
        yield return null;

    }
}

