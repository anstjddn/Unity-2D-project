using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class mapPotal : MonoBehaviour
{
  
    public UnityEvent cameramoved;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer== 6)
        {
            Debug.Log("���������� �̵�");
            collision.transform.position += new Vector3(15, 0, 0);
          

        } 
    }
}
