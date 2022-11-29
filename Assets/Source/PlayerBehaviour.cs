using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Player player;
    private void Start()
    {
        player.Initialize(gameObject);   
    }
    private void Update()
    {
        player.Update();
    }
}
