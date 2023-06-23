using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    protected Rigidbody2D monsterRb;
    protected Animator monsteranim;
    protected Collider2D monsterCollider;
    protected SpriteRenderer monsterRender;

    protected virtual void Awake()
    {
        monsterRb = GetComponent<Rigidbody2D>();
        monsteranim = GetComponent<Animator>();
        monsterCollider = GetComponent<Collider2D>();
        monsterRender = GetComponent<SpriteRenderer>();
    }
}
