using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {
    //config params
    [SerializeField] float xSpeed = 15f;
    [SerializeField] float ySpeed = 12f;
    [SerializeField] float xOuterRange = 5f;
    [SerializeField] float yOuterRange = 3f;

    [Header("Rotation")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    //cache
    float horizontalThrow, verticalThrow;
    bool isControlEnabled = true;
	
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessTranslation()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = horizontalThrow * xSpeed * Time.deltaTime; //x distance this frame
        float yOffset = verticalThrow * ySpeed * Time.deltaTime;
        //Debug.Log(xOffset);
        //transform.Translate(xOffset, 0f, 0f);
        float newX = Mathf.Clamp(transform.localPosition.x + xOffset, -xOuterRange, xOuterRange);
        float newY = Mathf.Clamp(transform.localPosition.y + yOffset, -yOuterRange, yOuterRange);
        transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void Freeze()
    {
        isControlEnabled = false;
    }
}
