using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float horizontal;
    
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) rb.linearVelocityY = jump;

        if (horizontal != 0) sprite.flipX = horizontal < 0;
        rb.linearVelocityX = horizontal * speed;
        anim.SetFloat("VelocityX", Mathf.Abs(rb.linearVelocityX));
    }
}
