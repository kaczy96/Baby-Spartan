using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMG : MonoBehaviour
{
    public float DMGValue;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Boom");
            HP_Bar.hp =- DMGValue;
        }
    }
}
