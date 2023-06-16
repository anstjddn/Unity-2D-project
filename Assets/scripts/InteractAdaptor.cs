using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAdaptor : MonoBehaviour, Iinteractable
{
    public UnityEvent OnIntweracted;
    public void interact()
    {
        OnIntweracted?.Invoke();
    }
}
