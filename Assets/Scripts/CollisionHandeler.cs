using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{   
    [SerializeField] ParticleSystem explosionParticle;

     void OnTriggerEnter(Collider other)
    {
        StartCollisionSequence(other);
    }

    void StartCollisionSequence(Collider other)
    {
        isControlOn(false);
        Explosion();
        ShipDissapear();
        Invoke("ReloadScene", 1f);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void isControlOn (bool isActive)
    {
       gameObject.GetComponent<PlayerControls>().enabled = isActive;
    }

    void Explosion()
    {
        explosionParticle.GetComponent<ParticleSystem>().Play();
    }
    void ShipDissapear()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

}
