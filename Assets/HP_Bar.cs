using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour {

    Image hpBar;
    float maxHp = 100f;
    public static float hp;

	void Start ()
    {
        hpBar = GetComponent<Image>();
        hp = maxHp;
	}
	
	void Update ()
    {
        hpBar.fillAmount = hp / maxHp;
	}
}
