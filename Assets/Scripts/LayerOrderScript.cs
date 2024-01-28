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
        Bounds bounds = spriteRenderer.bounds;
        Debug.Log(bounds.min.y);
        spriteRenderer.sortingOrder = Mathf.RoundToInt(bounds.min.y * -100f);
        if (transform.parent)
        {
            SpriteRenderer parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = parentSpriteRenderer.sortingOrder + 1;
        }
    }
}
