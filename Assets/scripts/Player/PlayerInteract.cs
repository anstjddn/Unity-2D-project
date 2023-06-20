using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] UnityEvent OnInteracted;


    private void Interact()
    {
        OnInteracted?.Invoke();
    }
 
}
