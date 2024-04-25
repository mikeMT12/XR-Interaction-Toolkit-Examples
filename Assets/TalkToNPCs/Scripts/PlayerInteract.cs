using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    [SerializeField] private float interactRange = 10f;
    [SerializeField] private List<NPCInteractable> listNpc;
    public IInteractable closestInteractable;
    //private 
    private void Update() {
        if (closestInteractable != null)
        {
            EnetrTrigger();
        }
        else
        {
            foreach(NPCInteractable npc in listNpc)
            {
                ExitfromTrigger(npc);
            }
           
        }
        /* if (Input.GetKeyDown(KeyCode.E)) {
             IInteractable interactable = GetInteractableObject();
             Debug.Log(interactable);
             if (interactable != null) {
                 interactable.Interact(transform);
             }
         }*/
        /*        if (closestInteractable != null)
                {

                }*/
    }

    public IInteractable GetInteractableObject() {
        List<IInteractable> interactableList = new List<IInteractable>();
        
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            Debug.Log(collider.gameObject.name);
            if (collider.TryGetComponent(out IInteractable interactable)) {
                Debug.Log(collider.gameObject.name);
                interactableList.Add(interactable);
            }
        }

        closestInteractable = null;
        foreach (IInteractable interactable in interactableList) {
            if (closestInteractable == null) {
                closestInteractable = interactable;
            } else {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < 
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position)) {
                    // Closer
                    closestInteractable = interactable;
                }
            }



        }

 

        return closestInteractable;
    }


    public void EnetrTrigger()
    {
        IInteractable interactable = GetInteractableObject();
        Debug.Log(interactable);
        if (interactable != null)
        {
            interactable.Interact(transform);
        }
    }

    public void ExitfromTrigger(IInteractable interactable)
    {
        
        Debug.Log(interactable);
        if (interactable != null)
        {
            interactable.UnInteract();
        }
    }

}