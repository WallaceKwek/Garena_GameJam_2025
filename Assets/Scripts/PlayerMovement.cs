using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 facing;
    private WeaponScript ws;
    private SpriteRenderer sr;
    private Animator anim;
    private bool ismoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ws = GetComponent<WeaponScript>();
        facing = Vector2.right;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        ismoving = moveDirection.x != 0 || moveDirection.y != 0;    
        moveDirection.Normalize();

        anim.SetBool("iswalking", ismoving);

        if (moveDirection.magnitude > 0)
        {
            facing = moveDirection;
        }
        if (Input.GetKeyDown("q"))
        {
            ws.Attack(facing);
        }

        // update the sprite so that it is facing the right way
        if(Input.GetKeyDown("a"))
        {
            sr.flipX = true;

        }
        if(Input.GetKeyDown("d"))
        {
            sr.flipX = false;
        }

        


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed; 
    }
}
