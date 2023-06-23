using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleCurSor : MonoBehaviour
{
   
    [SerializeField] GameObject asdasd;

    Vector2 getaim;
    private void LateUpdate()
    {
        //aimcursor.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(aimpos.x, aimpos.y, 10));
        asdasd.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(getaim.x, getaim.y, 10));
    }
    private void OnPointer(InputValue value)
    {
        getaim.x = value.Get<Vector2>().x;
        getaim.y = value.Get<Vector2>().y;
    }
}
