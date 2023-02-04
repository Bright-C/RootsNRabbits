using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSeedNumber : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI targetTextMesh;

    // Update is called once per frame
    void Update()
    {
        targetTextMesh.text = LevelManager.Instance.availableSeeds.ToString();
    }
}
