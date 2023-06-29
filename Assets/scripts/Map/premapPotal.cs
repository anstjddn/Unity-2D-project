using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class premapPotal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("다음맵으로 이동");
            collision.transform.position -= new Vector3(20, 0, 0);
        }
    }
}
