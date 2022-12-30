using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Slide : MonoBehaviour
{
    [SerializeField] SnowCat snowCat;
    private void Start()
    {
        snowCat.Initialize(gameObject);
    }
    private void Update()
    {
       snowCat.Control();
    }
    private void FixedUpdate()
    {
        snowCat.SnowCatSlide();
    }
}
