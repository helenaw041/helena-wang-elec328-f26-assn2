using UnityEngine;

public class FlashlightContinuousInfo : MonoBehaviour
{
    public Transform lightTransform; 
    public float coneAngle = 45f;
    Material mat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetVector("_FlashlightPos", lightTransform.position);
        mat.SetVector("_FlashlightDir", lightTransform.forward);
        mat.SetFloat("_ConeAngle", coneAngle);
    }
}