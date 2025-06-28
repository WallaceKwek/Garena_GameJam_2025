using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 facing;
    private WeaponScript ws;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ws = GetComponent<WeaponScript>();
        facing = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();
        if (moveDirection.magnitude > 0)
        {
            facing = moveDirection;
        }
        if (Input.GetKeyDown("q"))
        {
            ws.Attack(facing);
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed; 
    }
}
