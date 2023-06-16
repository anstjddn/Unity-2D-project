using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator WeaponAnim;
    [SerializeField]private UnityEvent Ondamaged;
    private Collider2D Weaponcollider;

    private void Awake()
    {
        WeaponAnim = GetComponent<Animator>();
        Weaponcollider = GetComponent<Collider2D>();
    }
    private void OnAttack(InputValue Value)
    {
        Attack();
    }
    private void Attack()
    {
        WeaponAnim.SetTrigger("Attack");
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ondamaged?.Invoke();
    }
}
