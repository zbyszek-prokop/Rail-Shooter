using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves left and right upon player input")]
    [SerializeField] float ShipHorizontalSpeed =25f;
    [Tooltip("How fast ship moves up and down upon player input")]
    [SerializeField] float ShipVerticalSpeed =25f;
    [Tooltip("Range of ship - left and right")]
    [SerializeField] float Range =10f;
    [Tooltip("Range of ship - Up")]
    [SerializeField] float Up=12f;
    [Tooltip("Range of ship - Down")]
    [SerializeField] float Down= -4.5f;
    [Header("Screen position based tuning")]
    [SerializeField] float pitchPositionFactor =-2f;
    [SerializeField] float yawPositionFactor =2f;
    [Header("Player position based tuning")]
    [SerializeField] float controlPitchFactor =-15f;
    [SerializeField] float rollControlFactor =-20f;
    [SerializeField] GameObject[] lasers;
    

    float horizontalThrow;
    float verticalThrow;

    void Update()
    {
        ProcessPosition();
        ProcessRotation();
        ProcessFire();
    }

 
    void ProcessRotation()
    {
        float pitchPosition = transform.localPosition.y * pitchPositionFactor;
        float pitchControl = verticalThrow * controlPitchFactor;
        float pitch= pitchPosition + pitchControl;

        float yaw= transform.localPosition.x * yawPositionFactor;

        float roll=horizontalThrow * rollControlFactor;
        

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

     void ProcessPosition()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        float offset = ShipHorizontalSpeed * horizontalThrow * Time.deltaTime;
        float moveHorizontal = offset + transform.localPosition.x;
        float clampedHorizontal = Mathf.Clamp(moveHorizontal, -Range, Range);

        float offsetVertical = ShipVerticalSpeed * verticalThrow * Time.deltaTime;
        float moveVertical = offsetVertical + transform.localPosition.y;
        float clampedVertical = Mathf.Clamp(moveVertical, Down, Up);

        transform.localPosition = new Vector3
         (clampedHorizontal,
          clampedVertical,
          transform.localPosition.z);
    }

   void ProcessFire()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }

    }

    void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var em = laser.GetComponent<ParticleSystem>().emission;
            em.enabled = isActive;
        }
    }


}
