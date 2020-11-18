using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    TriggerDetector triggerDetector;
    Animator animator;
    float visualDirection;

    public Transform visual;
    public float moveForce;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        triggerDetector = GetComponentInChildren<TriggerDetector>();
        animator = GetComponentInChildren<Animator>();
        visualDirection = 1.0f;
    }

    public void MoveLeft()
    {
        if (triggerDetector.inTrigger)
            rigidBody2D.AddForce(new Vector2(-moveForce, 0.0f), ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        if (triggerDetector.inTrigger)
            rigidBody2D.AddForce(new Vector2(moveForce, 0.0f), ForceMode2D.Impulse);
    }

    void Update()
    {
        float velocity = rigidBody2D.velocity.x;

        if (velocity < -0.01f)
            visualDirection = -1.0f;
        else if (velocity > 0.01f)
            visualDirection = 1.0f;

        Vector3 scale = visual.localScale;
        scale.x = visualDirection;
        visual.localScale = scale;

        animator.SetFloat("speed", Mathf.Abs(velocity));
    }
}
