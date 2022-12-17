using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMessage : MonoBehaviour
{

    public GameObject InvMessage;

    void Update()
    {
        if (InventoryManager.showMessage)
        {
            InvMessage.gameObject.SetActive(true);
          //  wait(); 
            //InventoryManager.showMessage = false; 

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3); 
    }

    
}
