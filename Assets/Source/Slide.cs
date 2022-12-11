using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Slide : MonoBehaviour
{
    SnowCat snowCat;
    private void Start()
    {
        snowCat = new SnowCat(gameObject);
    }
    private void Update()
    {
        snowCat.Slide();
    }
}
