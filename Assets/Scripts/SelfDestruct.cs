using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]float TimeTillDestroy =3f;
    void Start()
    {
        Destroy(gameObject, TimeTillDestroy);
    }
}
