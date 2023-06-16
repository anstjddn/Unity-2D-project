using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator WeaponAnim;

    private void Awake()
    {
        WeaponAnim = GetComponent<Animator>();
    }
    private void OnAttack(InputValue Value)
    {
        WeaponAnim.SetTrigger("Attack");
    }
}
