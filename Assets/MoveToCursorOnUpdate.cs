using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursorOnUpdate : MonoBehaviour
{
    public LayerMask growableLayers;
    [SerializeField] Sprite _cursor;
    [SerializeField] SpriteRenderer _spriteRenderer;
    private bool isGrowing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        bool isGrowableLayer = Physics2D.OverlapPoint(mousePos, growableLayers);
        _spriteRenderer.sprite = _cursor;
        transform.position = mousePos;

        if(isGrowableLayer)
        {
            isGrowing = Input.GetMouseButton(0);
        }
        if(Input.GetMouseButtonUp(0))
        {
            isGrowing = false;
        }

        _spriteRenderer.enabled = isGrowableLayer || isGrowing;
    }
}
