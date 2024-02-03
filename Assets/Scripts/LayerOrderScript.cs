using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrderScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateLayerOrder();
    }

    void Update()
    {
        UpdateLayerOrder();
    }

    private void UpdateLayerOrder()
    {
        if (transform.parent)
        {
            SpriteRenderer parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = parentSpriteRenderer.sortingOrder + 1;
        }
        else
        {
            Bounds bounds = spriteRenderer.bounds;
            spriteRenderer.sortingOrder = Mathf.RoundToInt(bounds.min.y * -100f);
        }
        
    }
}
