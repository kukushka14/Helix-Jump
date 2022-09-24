using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;


    private void Awake()
    {
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        Renderer SectorRenderer = GetComponent<Renderer>();
        SectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player))
        {
            return;
        }
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5)
        {
            return;
        }
        
        if (IsGood)
        {
            player.Bounce();
            Invoke("Destroy", 0.65f);
            player.breakAudio.PlayDelayed(0.6f);
        }
        else
            player.Die();
        
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }
}
