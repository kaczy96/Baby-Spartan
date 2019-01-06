using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMG : MonoBehaviour
{
    public float DMGValue;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
            HP_Bar.health =- 10f;
        
    }
}
