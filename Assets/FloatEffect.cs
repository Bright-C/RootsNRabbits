using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float endValue = 0.5f;
    public float duration = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(endValue, duration).SetRelative().SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
