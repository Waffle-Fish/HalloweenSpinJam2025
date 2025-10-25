using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField][Min(0f)] float moveSpeed = 1f;

    InputSystem_Actions inputSystem;

    private void Awake()
    {
        inputSystem = new();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
    }

    void OnDisable()
    {
        inputSystem.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = inputSystem.Player.Move.ReadValue<Vector2>().normalized;
        transform.Translate(moveSpeed * Time.deltaTime * moveDir);
    }
}
