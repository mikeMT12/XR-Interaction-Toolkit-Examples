using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {

    void Interact(Transform interactorTransform);
    void UnInteract();
    string GetInteractText();
    Transform GetTransform();

}