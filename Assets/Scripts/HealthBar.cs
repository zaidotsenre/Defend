using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform target;
    public  Vector3 offset;

    [SerializeField] Transform fillTransform;

    [SerializeField] MeshRenderer fillMeshRenderer;
    [SerializeField] Color fillColor;

    [SerializeField] MeshRenderer backgroundMeshRenderer;
    [SerializeField] Color backgroundColor;
    
    Camera mainCamera;

    private void Start()
    {
        fillMeshRenderer.material.color = fillColor;
        backgroundMeshRenderer.material.color = backgroundColor;
        transform.position = target.position + offset;
    }

    public void UpdateHealthBar (float health)
    {
        fillTransform.localScale = new Vector3 (Mathf.Clamp01(health), 1, 1);
        if (health <= 0)
            Destroy(gameObject);
    }

}
