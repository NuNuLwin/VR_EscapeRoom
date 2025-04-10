/*
 * ChangeRemoteLight.cs
 * 
 * Description:
 * This script manages the switching between two materials (red/white light) for a GameObject's 
 * MeshRenderer. It allows toggling between a default material and an alternative material, 
 * simulating turning a light on and off remotely. The script includes methods to set 
 * the material to either state and to toggle between them.
 */
using UnityEngine;

public class ChangeRemoteLight : MonoBehaviour
{
    public Material otherMaterial;
    private Material defaultMaterial;
    private MeshRenderer rendererComponent;
    private bool isUsingOther;

    private void Awake()
    {
        // Get the MeshRenderer component attached to this GameObject
        rendererComponent = GetComponent<MeshRenderer>();
        // Store the default material for later use
        defaultMaterial = rendererComponent.material;
    }
    
    // Method to activate the alternate material (e.g., turning the light on)
    public void SetActiveLight()
    {
        isUsingOther = true;                        // Set the flag indicating the alternative material is in use
        rendererComponent.material = otherMaterial; // Change to the alternative material
    }

    // Method to deactivate the alternate material (e.g., turning the light off)
    public void SetDeactiveLight()
    {
        isUsingOther = false;                       // Set the flag indicating the default material is in use
        rendererComponent.material = defaultMaterial;   // Revert to the default material
    }

    // Method to toggle between the default and alternate materials
    public void ToggleMaterial()
    {
        // Toggle the flag and update the material accordingly
        isUsingOther = !isUsingOther;
        rendererComponent.material = isUsingOther ? otherMaterial : defaultMaterial;
    }
}
