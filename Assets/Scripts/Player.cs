using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //[SerializeField] private float forceAmount = 1000.0f;
    [SerializeField] private float speed = 10.0f;
    private Rigidbody rb;
    private InputAction moveAction;
    private Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move", true);
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(0, 0, moveValue.x * forceAmount), ForceMode.VelocityChange);
        rb.position += new Vector3(0, 0, direction.x * speed * Time.deltaTime);
    }
}
