using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] public GameObject inventory;
    [SerializeField] Transform trans;
    [SerializeField] float range;

    private void OnInteract(InputValue value)
    {
        Interactor();
    }
    private void OnInventory(InputValue value)
    {
        InventoryOn();
    }
    public void InventoryOn()
    {
        Debug.Log("인벤토리 열음");
        if (!inventory.activeSelf)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
    private void Interactor()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(trans.position.x, trans.position.y), range);
        foreach (Collider2D collider in colliders)
        {
            Iinteractable interactable = collider.GetComponent<Iinteractable>();
            interactable?.interact();
    
        }

    }



    private void OnState(InputValue value)
    {
        PopUpUI ui = GameManager.Resource.Load<PopUpUI>("UI/StateUI");
        GameManager.UI.ShowPopUpUI(ui);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector2(trans.position.x, trans.position.y), range);
    }

}
