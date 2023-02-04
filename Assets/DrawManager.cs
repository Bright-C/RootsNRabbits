using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;
    public LayerMask growableLayers;

    public const float RESOLUTION = .1f;
    public const float MAXLENGTH = 6;

    private Line _currentLine;
    void Start()
    {
        _cam = Camera.main;
    }


    void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        bool isGrowableLayer = Physics2D.OverlapPoint(mousePos, growableLayers);

        if (Input.GetMouseButtonDown(0) && LevelManager.Instance.HasSeeds() && isGrowableLayer)
        {
            LevelManager.Instance.ConsumeSeed();
            _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
        }
        if (_currentLine != null)
        {
            if (Input.GetMouseButton(0))
            {
                if (_currentLine.TotalLength < MAXLENGTH)
                {
                    _currentLine.SetPosition(mousePos);
                }
            }
        }
    }
}