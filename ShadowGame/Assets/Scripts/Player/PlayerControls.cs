using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField][Min(0f)] float moveSpeed = 1f;

    InputSystem_Actions inputSystem;
    Rigidbody2D rb2D;
    Collider2D col2D;
    Animator animator;
    Vector2 moveDir = Vector2.zero;

    private void Awake()
    {
        inputSystem = new();
        rb2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
        EventService.Instance.OnDeath.AddListener(DisableOnDeath);
    }

    void OnDisable()
    {
        inputSystem.Disable();
        EventService.Instance.OnDeath.RemoveListener(DisableOnDeath);
    }

    void Update()
    {
        moveDir = inputSystem.Player.Move.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("XDir", moveDir.x);
        animator.SetFloat("YDir", moveDir.y);
        Vector2 moveVel = moveSpeed * Time.fixedDeltaTime * moveDir;
        Vector2 newPos = (Vector2)transform.position + moveVel;
        rb2D.MovePosition(newPos);
    }
    
    private void DisableOnDeath()
    {
        this.enabled = false;
    }
}
