using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private Vector2 touchStart;
    private float rotationSpeed = 2.0f;
    private float zoomSpeed = 0.1f;
    private float minZoomPercentage = 50f;
    private float maxZoomPercentage = 200f;
    private float lastTapTime;
    private float doubleTapTimeThreshold = 0.2f;

    
    private Vector3 initialScale;
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

            float prevMagnitude = (touch1PrevPos - touch2PrevPos).magnitude;
            float currentMagnitude = (touch1.position - touch2.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * zoomSpeed);
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Rotate(touch.deltaPosition.x * rotationSpeed);
            }
        }
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float currentTime = Time.time;

            if (currentTime - lastTapTime <= doubleTapTimeThreshold)
            {
                // Double-tap detected, reset rotation and scale
                ResetModel();
            }

            lastTapTime = currentTime;
        }
    }
    void Rotate(float deltaRotationX)
    {
        Debug.Log("Rotating " + gameObject.name);
        transform.Rotate(Vector3.up, -deltaRotationX);
    }
    void Zoom(float deltaMagnitudeDiff)
    {
        float percentageChange = deltaMagnitudeDiff / initialScale.x * 100f;
        float newScale = Mathf.Clamp(transform.localScale.x + percentageChange, initialScale.x * minZoomPercentage / 100f, initialScale.x * maxZoomPercentage / 100f);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
    void ResetModel()
    {
        // Reset rotation and scale to their initial values
        transform.rotation = Quaternion.identity;
        transform.localScale = initialScale;
    }
}
