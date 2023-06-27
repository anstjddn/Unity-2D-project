using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    [SerializeField] public float textspeed;
    TextMeshPro text;
    [SerializeField] float alphaspeed;
    Color alpha;
    [SerializeField] float destoryTime;
    public int damage;

    private void Awake()
    {
        damage = GameManager.data.playerDamege;
    }
    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        text.text = damage.ToString();
        Invoke("DestroyObject", destoryTime);
    }
    private void Update()
    {
        transform.Translate(0, textspeed * Time.deltaTime, 0);
        alpha.a = Mathf.Lerp(alpha.a, 0,alphaspeed * Time.deltaTime) ;
        text.color = alpha;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
