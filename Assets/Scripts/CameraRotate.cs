using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 100f;
    private float _yRotaye;
    private float _zRotaye;

    void Update()
    {
        //MouseLook();
    }

    void MouseLook()
    {
        _zRotaye = Input.GetAxis("Mouse Y");
        transform.Rotate(_zRotaye * _sensitivity * -1 * Time.deltaTime, 0, 0);
    }

}
