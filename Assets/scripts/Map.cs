using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Map : MonoBehaviour
{
    Mapnode[,] maparray = new Mapnode[3, 3];
    /*
     * {0,0,0,0}
     * {0,0,0,0}
     * {0,0,0,0}
     * {0,0,0,0}
     * */
    private void Awake()
    {
        
        for (int i =0; i < maparray.GetLength(1); i++) //행 길이 리턴
        {
            maparray[0,i].num= Random.Range(0, 2);

            for(int j = 1; j< maparray.GetLength(1); j++)
            {
                maparray[j, i].num = Random.Range(0, 2);
            }
        }
    }
}

public class Mapnode
{
    public int num;
    public bool leftnode;
    public bool rightnode;
    public bool upnode;
    public bool downnode;


}