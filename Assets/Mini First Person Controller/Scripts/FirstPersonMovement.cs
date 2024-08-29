using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 6;

    int count = 0;

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
        RenderSettings.fogDensity = 0.05f;
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
    }

        void OnCollisionEnter(Collision equip)
        {
            if (equip.gameObject.tag == ("collectable"))
            {
            count++;
            speed -= 0.5f; runSpeed -= 1;
            Destroy(equip.gameObject);
            }

            if (equip.gameObject.tag == ("fogCollectable"))
            {
            count++;
            RenderSettings.fogDensity += 0.05f;
            speed -= 0.5f; runSpeed -= 1;
            Destroy(equip.gameObject);
            }

            if (equip.gameObject.tag == ("energy"))
            {
             speed += 0.25f; runSpeed += 0.5f;
             Destroy(equip.gameObject);
            }

            if (equip.gameObject.tag == ("eyesight"))
            {
             RenderSettings.fogDensity -= 0.05f;
             speed += 0.25f; runSpeed += 0.5f;
             Destroy(equip.gameObject);
            }
    }
    }