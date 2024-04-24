using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    [SerializeField] private float interactRange = 10f;

    //private 
    private void Update() {
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

        IInteractable closestInteractable = null;
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

        if (closestInteractable != null)
        {
            IInteractable interactable = GetInteractableObject();
            Debug.Log(interactable);
            if (interactable != null)
            {
                interactable.Interact(transform);
            }
        }

        return closestInteractable;
    }

}