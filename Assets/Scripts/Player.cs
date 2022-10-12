using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _startMousePosition;
    private Vector3 startRotatorPosition;
    public GameObject rotatorPref;
    private GameObject rotator;
    private Rigidbody _rb;
    void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
        rotator = Instantiate(rotatorPref);
        rotator.transform.SetParent(gameObject.transform.parent);
        rotator.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        rotator.transform.localEulerAngles = new Vector3(0, 0, 0);
        rotator.transform.position = transform.position;
    }

    void Update()
    {
        rotator.transform.position = transform.position;
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startMousePosition = Input.mousePosition;
                startRotatorPosition = rotator.transform.localEulerAngles;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 newPosition = Input.mousePosition - _startMousePosition;
                rotator.transform.localEulerAngles = startRotatorPosition + new Vector3(0, 0, newPosition.x / 10);
            }
        }
        else if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                _startMousePosition = Input.mousePosition;
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Vector3 newPosition = Input.mousePosition - _startMousePosition;
                rotator.transform.localEulerAngles = new Vector3(0, 0, newPosition.x / 10);
            }
        }
    }

    public void MovementLogic(float Speed)
    {
        Vector3 movement = rotator.transform.GetChild(0).transform.right;
        _rb.AddForce(movement * Speed);
    }

    public void DestroyRotator()
    {
        Destroy(rotator);
    }
}
