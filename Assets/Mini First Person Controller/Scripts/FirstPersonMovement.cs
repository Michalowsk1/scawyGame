using System;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 6;

    bool bag = false;
    bool glasses = false;
    bool pills = false;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 11;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        if (bag == true)
        { speed = 5.5f; runSpeed = 9; }

        else
        { speed = 6; runSpeed = 10; }

        if (glasses == true)
        { RenderSettings.fogDensity = 0.125f; speed -= 1; runSpeed -= 2; }

        else
        { RenderSettings.fogDensity = 0.075f;}
    }

        void OnCollisionEnter(Collision equip)
        {
            if (equip.gameObject.tag == ("bag"))
            {
                bag = true;
                Destroy(equip.gameObject);
            }

            if (equip.gameObject.tag == ("glasses"))
            {
                glasses = true;
                Destroy(equip.gameObject);
            }
    }
    }