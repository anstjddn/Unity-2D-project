using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IGetable
{
    public Transform cointrans;
    private Rigidbody2D rb;

    [SerializeField] float delay = 0;
    [SerializeField] float pasttime = 0;
    [SerializeField] float when = 0.5f;
    private Vector3 off;

    public void Get()
    {
        GameManager.data.basegold += 10;
        Destroy(gameObject);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        off = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 3.0f), 0);
       // off = new Vector3(off.z, Random.Range(-1.0f, 1.0f), off.z);
    }

    private void Start()
    {
        Vector2 dir = Random.insideUnitCircle;
        dir.y = Mathf.Abs(dir.y);
        rb.AddForce(dir * 1, ForceMode2D.Impulse);
    }
}

