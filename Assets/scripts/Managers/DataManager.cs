using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public int playerLevel = 1;
    public int maxHp=60;
    public int curHp=60;
    public int playerDamege=0;
    public int defence=0;
    public int basegold=5000;
    public int curfood = 0;
    public int maxfood = 125;
    public int block = 0;
    public int tough = 0;
    public float playerattackspeed =0;
    public UnityEvent OnChangeHp;
    public float playerTime;

    private void Update()
    {
        playerTime += Time.deltaTime;
    }

}
