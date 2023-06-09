using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneKontrolScript : MonoBehaviour
{
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float forceUp = 15f;
    [SerializeField]
    float forceForward = 7f;
    [SerializeField]
    float forceRight = 7f; 
    [SerializeField]
    float torque = 2f;

    private const float _gravity = 9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Keypad8)) MoveUp();
        else if (Input.GetKey(KeyCode.Keypad5)) MoveDown();
        else this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _gravity);

        if (Input.GetKey(KeyCode.W)) MoveForward();
        if (Input.GetKey(KeyCode.S)) MoveBackward();

        if (Input.GetKey(KeyCode.D)) MoveRight();
        if (Input.GetKey(KeyCode.A  )) MoveLeft();

        if (Input.GetKey(KeyCode.E)) YawClockwise();
        if (Input.GetKey(KeyCode.Q)) YawCounterClockwise();
        
        if (Input.GetKey(KeyCode.Keypad9)) RollClockwise();
        if (Input.GetKey(KeyCode.Keypad7)) RollCounterClockwise();

        if (Input.GetKey(KeyCode.Keypad6)) PitchClockwise();
        if (Input.GetKey(KeyCode.Keypad4)) PitchCounterClockwise();
    }

    private void MoveUp()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * forceUp);
    }
    private void MoveDown()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * (forceUp - _gravity));
    }

    private void MoveForward()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * forceForward);
    }
    private void MoveBackward()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * forceForward);
    }

    private void MoveRight()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * forceRight);
    }
    private void MoveLeft()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * forceRight );
    }

    private void YawClockwise()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.up * torque);
    }
    private void YawCounterClockwise()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.down * torque);
    }

    private void RollClockwise()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.right * torque);
    }
    private void RollCounterClockwise()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.left * torque);
    }

    private void PitchClockwise()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.back * torque);
    }
    private void PitchCounterClockwise()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.forward * torque);
    }
}
