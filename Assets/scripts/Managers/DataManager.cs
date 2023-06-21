using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public int playerLevel = 1;
    public int maxHp=60;
    public int curHp=60;
    public int playerDamege;
    public int defence;
    public int basegold=5000;

    public UnityEvent OnChangeHp;


}
