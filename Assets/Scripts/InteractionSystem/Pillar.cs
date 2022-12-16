using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{   
    public GameObject pillarObj;
    public Material RunePillar;
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;
    MeshRenderer meshPillar;  
    
       
    void Start()
    {
        //meshPillar = pillarObj.GetComponent<MeshRenderer>();
       // runeMaterials = meshPillar.materials;
        //Material oldMaterial = meshPillar.material[0];
       // meshPillar.material = runeMaterials[1];
       // Debug.Log(runeMaterials[0]);
        //meshPillar.material = meshPillar.sharedMaterial[1];
        meshPillar = pillarObj.GetComponent<MeshRenderer>();
        
    }

    public bool Interact(Interactor interactor)
    {
        
        meshPillar.material = RunePillar;
        Debug.Log(RunePillar);
        Debug.Log(message:"Interacted with pillar!");
        return true;
    }
    

}
