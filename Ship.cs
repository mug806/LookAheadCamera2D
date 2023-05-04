using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ship : MonoBehaviour {
    public float Thrust { get; private set; }
    public float Steering { get; private set; }

    [Header("Settings")]
    public float thrustForce = 10;
    public float steeringTorque = 40;

    Rigidbody2D rigid;

    private void Start() {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Thrust = Input.GetAxisRaw("Throttle");  //you can either set up the "Throttle" in the input manager or use "Vertical" instead
        Steering = -Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() {
        rigid.AddRelativeForce(Vector2.up * thrustForce * Thrust);
        rigid.AddTorque(steeringTorque * Steering);
    }
}
