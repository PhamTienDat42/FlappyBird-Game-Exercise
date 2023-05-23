using UnityEngine;

public class BackGroundMoverment : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
   
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
