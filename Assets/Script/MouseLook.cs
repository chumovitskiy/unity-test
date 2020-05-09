using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0, MouseX = 1, MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float _rotationX = 0.0f;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (null != body)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RotationAxes.MouseX == axes)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        if (RotationAxes.MouseY == axes)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            transform.localEulerAngles = new Vector3(_rotationX, 0, 0);

        }
        if (RotationAxes.MouseXAndY == axes)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
