using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int numFound; 
    public int count = 0;
    

   private void Update()
   {
   
    numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, _colliders, interactableMask);


    if (numFound > 0)
    {
        var interactable = _colliders[0].GetComponent<Pillar>();

        if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            
            interactable.Interact(this);
            Destroy(interactable);
            count = count + 1;
            Debug.Log(count);
            if(count == 5){
            SceneManager.LoadScene("GameWon");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
         } 
        
        }
    }

   }

}
