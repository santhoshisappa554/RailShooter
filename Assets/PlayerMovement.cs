using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [Header("General")]

    [SerializeField] float speed;
    [SerializeField] float xRange = 250.0f;
    [SerializeField] float yRange = 60.0f;

    [Header("Position")]
    [SerializeField] float positionrotationFactor = 5.0f;
    [SerializeField] float controlRotationFactor = 5.0f;
    [SerializeField] float positionyawFactor = 5.0f;
    [SerializeField] float controlRollFactor = 5.0f;

    float xOffset, yOffset;
    bool isPlayerAlive = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAlive)
        {
            PlayerPosition();
            PlayerRotation();
        }
        
    }
    void OnPlayerDeath()
    {
        isPlayerAlive = false;
        print("Recieved Msg");
    }

    private void PlayerRotation()
    {
        //
        //float xRotation = transform.localRotation.x * rotationFactor;
        float yRotation = transform.localRotation.y * positionrotationFactor;
        float pitchControlValue = yOffset * controlRotationFactor;
        float pitch = yRotation + pitchControlValue;

        float yaw = transform.localPosition.x + positionyawFactor;
        // float zRotation = transform.localRotation.z * rotationFactor ;

        float roll = xOffset + controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void PlayerPosition()
    {
        float horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal");
        xOffset = horizontalMove * speed * Time.deltaTime;

        float verticalMove = CrossPlatformInputManager.GetAxis("Vertical");
        yOffset = verticalMove * speed * Time.deltaTime;


        float xRawPos = transform.localPosition.x + xOffset;
        float yRawPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(xRawPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(yRawPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Happened");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Happened");
    }
    private void PlayerDeath()
    {
        Debug.Log("Player is Dead");
        SendMessage("OnPlayerDeath");
    }

}
