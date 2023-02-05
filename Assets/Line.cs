using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private EdgeCollider2D _collider;

    [SerializeField] float _totalLength = 0;
    public float TotalLength
    {
        private set => _totalLength = value;
        get => _totalLength;
    }

    private readonly List<Vector2> _points = new List<Vector2>();
    void Start()
    { 
        _renderer.material.SetTextureScale("_MainTex", new Vector2(0.1f, 1f));
        _collider.transform.position -= transform.position;
    }


    void Update()
    {
       
        _renderer.material.SetFloat("_Fade", _totalLength/6f);
    }

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos)) return;

        if (_renderer.positionCount > 0)
        {
            TotalLength += Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos);
        }

        _points.Add(pos);

        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);

        _collider.points = _points.ToArray();
    }

    private bool CanAppend(Vector2 pos)
    {
        if (_renderer.positionCount == 0) return true;

        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }
}
