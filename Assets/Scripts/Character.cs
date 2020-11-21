using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    TriggerDetector triggerDetector;
    Animator animator;
    float visualDirection;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private bool isVisible = false;

    public Transform visual;
    public float moveForce;
    public float jumpForce;
    private static readonly int Speed = Animator.StringToHash("speed");
    private static readonly int Jump1 = Animator.StringToHash("jump");

    public delegate void OnDeadAreaHandler();

    public static event OnDeadAreaHandler InDeadArea;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        triggerDetector = GetComponentInChildren<TriggerDetector>();
        animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        visualDirection = 1.0f;
        isVisible = false;
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

    public void Jump() {
        if (triggerDetector.inTrigger)
            rigidBody2D.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
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

        animator.SetFloat(Speed, Mathf.Abs(velocity));
        animator.SetBool(Jump1, !triggerDetector.inTrigger);

        if (triggerDetector.inTrigger && triggerDetector.isDeadArea) {
            InDeadArea?.Invoke();
        }
        
        // if(!_spriteRenderer.isVisible && isVisible) {
        //     ExitedScreen?.Invoke();
        // } else if (_spriteRenderer.isVisible) {
        //     isVisible = true;
        // }
    }
}
