using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    void Start()
    {
        var rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
    }
}
