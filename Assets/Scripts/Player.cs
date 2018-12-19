using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    //config params
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] float xOuterRange;
    [SerializeField] float yOuterRange;

    [Header("Rotation")]
    [SerializeField] float positionPitchFactor;
    [SerializeField] float controlPitchFactor;
    [SerializeField] float positionYawFactor;
    [SerializeField] float controlRollFactor;

    //cache
    float horizontalThrow, verticalThrow;

	void Start () {
		
	}
	
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
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
}
