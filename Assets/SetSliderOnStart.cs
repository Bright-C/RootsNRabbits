using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderOnStart : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float targetValue = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = targetValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
