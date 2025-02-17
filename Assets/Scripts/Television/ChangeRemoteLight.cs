using UnityEngine;

public class ChangeRemoteLight : MonoBehaviour
{
    public Material otherMaterial;
    private Material defaultMaterial;
    private MeshRenderer rendererComponent;
    private bool isUsingOther;

    private void Awake()
    {
        rendererComponent = GetComponent<MeshRenderer>();
        defaultMaterial = rendererComponent.material;
    }

    public void SetActiveLight()
    {
        isUsingOther = true;
        rendererComponent.material = otherMaterial;
    }

    public void SetDeactiveLight()
    {
        isUsingOther = false;
        rendererComponent.material = defaultMaterial;
    }

    public void ToggleMaterial()
    {
        isUsingOther = !isUsingOther;
        rendererComponent.material = isUsingOther ? otherMaterial : defaultMaterial;
    }
}
