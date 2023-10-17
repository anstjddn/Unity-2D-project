using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] public bool isready;
    [SerializeField] public RoomTemplates rooms;
    private void Awake()
    {
        Debug.Log("GameScene Init");
    }

    protected override IEnumerator LoadingRoutine()
    {
        while (!rooms.alladd)
        {

            rooms.Check(rooms.alladd);
            Debug.Log(rooms.alladd);
            yield return new WaitForSeconds(1f);
        }
        isclear = true;
        isready = true;
        yield return new WaitForSeconds(1f);
    }

}
