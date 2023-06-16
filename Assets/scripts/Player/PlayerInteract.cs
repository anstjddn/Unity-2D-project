using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] UnityEvent OnInteracted;
    private void OnInteract(InputValue value)
    {
        OnInteracted?.Invoke();
    }
}
