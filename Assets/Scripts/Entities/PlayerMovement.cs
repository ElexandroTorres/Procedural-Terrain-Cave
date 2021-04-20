using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _playerRb;
    private float _playerSpeed = 5.0f;
    private float _mouseSensitivy = 100.0f;
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * _playerSpeed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * _playerSpeed * Time.deltaTime;

        transform.Translate(horizontalInput, 0, verticalInput);

        float horizontalMouse = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSensitivy;
        float verticalMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSensitivy * -1;

        //transform.Translate(horizontalMouse, 0, verticalMouse);
        transform.Rotate(0, horizontalMouse, 0, Space.Self);
        Camera.main.transform.Rotate(verticalMouse, 0, 0);
        //_playerRb.AddForce(new Vector3(horizontalInput, 0, verticalInput), ForceMode.Impulse);
    }
}
