using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [InfoBox("Kamerayý Camera.main ile çekiyorum, ilerde kamera deðiþirse o kamerayý çekmek gerekebilir")]

    [ReadOnly] public new Camera camera;
    
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(camera.transform);
    }
}

