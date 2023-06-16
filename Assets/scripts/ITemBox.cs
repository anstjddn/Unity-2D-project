using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ITemBox : MonoBehaviour
{
    private Animator anim;
   [SerializeField] GameObject interact;
    private void Awake()
    {
        anim = GetComponent<Animator>();
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interact.SetActive(true);
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        interact.SetActive(false);
    }

    public void Interact()
    {
        anim.SetBool("Hit", true);

        Destroy(this.gameObject, 3f) ;
    } 

}
