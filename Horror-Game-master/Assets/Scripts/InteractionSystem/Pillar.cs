using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{   
    public GameObject pillarObj;
    public Material RunePillar;
    Material [] runeMaterials;
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
        
    }

    public bool Interact(Interactor interactor)
    {
        meshPillar = pillarObj.GetComponent<MeshRenderer>();
        meshPillar.material = RunePillar;
        Debug.Log(RunePillar);
        Debug.Log(message:"Interacted with pillar!");
        return true;
    }
    

}
