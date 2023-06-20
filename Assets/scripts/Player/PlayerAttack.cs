using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
  
    //[SerializeField] UnityEvent hited;
    [SerializeField] GameObject effect;
    private void OnAttack(InputValue value)
    {
        Attack();
 
    }
    private void Attack()
    {
      //  hited?.Invoke();
        StartCoroutine(hiteffctroutin());
    }
    
  IEnumerator hiteffctroutin()
    {

        Instantiate(effect, transform.position, transform.rotation);

        yield return null;
    }
}
