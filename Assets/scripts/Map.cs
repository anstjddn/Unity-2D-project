using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    int[,] maparray = new int[3, 3];
    /*
     * {0,0,0,0}
     * {0,0,0,0}
     * {0,0,0,0}
     * {0,0,0,0}
     * */
    private void Awake()
    {
        
        for (int i =0; i < maparray.GetLength(0); i++) //행 길이 리턴
        {
            maparray[i,0]= Random.Range(0, 2);
            for(int j = 0; j< maparray.GetLength(1); j++)
            {
                maparray[i, j] = Random.Range(0, 2);
            }
        }
    }
}
