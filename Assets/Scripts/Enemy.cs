using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

[SerializeField]GameObject deathFX;
[SerializeField]GameObject hitVFX;
[SerializeField]int ScoreToIncrease;
[SerializeField]int Health = 100;

Scoreboard scoreboard;
GameObject parentGameObject;


    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        AddRigidbody();
        parentGameObject = GameObject.FindWithTag("Spawn");
        
    }
    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        KillEnemy();
    }

    void KillEnemy()
    {
        
        if(Health > 1)
        {
            GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parentGameObject.transform;
            Health -= 1;
            
        }else{
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
            ProcessScore();
        }
    }

    void ProcessScore()
    {
        scoreboard.UpdateScore(ScoreToIncrease);
    }
}
