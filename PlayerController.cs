using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private Rigidbody2D rb;
    private bool groundcheckb;
    public GameObject groundcheckobj;
    public float groundcheckradius;
    public LayerMask groundmask;
    public GameObject climbobj;
    public float climbcheckradius;
    public LayerMask climbcheckmask;
    public float climbspeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics2D.OverlapCircle(groundcheckobj.transform.position, groundcheckradius, groundmask))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics2D.OverlapCircle(climbobj.transform.position, climbcheckradius, climbcheckmask))
            {
                rb.velocity = new Vector2(transform.position.x, climbspeed);
            }
        }
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (transform.localScale.x > 0 && rb.velocity.x < 0)
        {
            FlipVoid();
        }else if (transform.localScale.x < 0 && rb.velocity.x > 0){
            FlipVoid();
        }
    }

    private void FlipVoid()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
