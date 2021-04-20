using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _playerRb;
    private float _playerSpeed = 5.0f;
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
        //_playerRb.AddForce(new Vector3(horizontalInput, 0, verticalInput), ForceMode.Impulse);
    }
}
