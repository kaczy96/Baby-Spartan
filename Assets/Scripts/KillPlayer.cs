using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    bool check;
    public Collider2D other;
    float wait = 1f;

    void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	void Update ()
    {

        if(HP_Bar.hp <= 0)
        Kill();
	}

    public void Kill()
    {
        wait -= Time.deltaTime;
        if (wait < 0)
        {
            Debug.Log("You die");
            levelManager.RespawnPlayer();
            HP_Bar.hp = 100f;
        }
            
        }
    }

   


