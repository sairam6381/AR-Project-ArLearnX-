using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{

    private float zoomSpeed = 0.1f;
    private float minZoomPercentage = 100f;
    private float maxZoomPercentage = 150f;
    private Vector3 initialScale;
 
    void Start()
    {
        initialScale = transform.localScale;
    }

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
       
        
    }
    void Zoom(float deltaMagnitudeDiff)
    {
        float percentageChange = deltaMagnitudeDiff / initialScale.x * 100f;
        float newScale = Mathf.Clamp(transform.localScale.x + percentageChange, initialScale.x * minZoomPercentage / 100f, initialScale.x * maxZoomPercentage / 100f);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
    
}
