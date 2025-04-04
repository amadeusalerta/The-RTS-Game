using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [InfoBox("Kameray� Camera.main ile �ekiyorum, ilerde kamera de�i�irse o kameray� �ekmek gerekebilir")]

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

