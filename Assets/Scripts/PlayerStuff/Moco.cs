using UnityEngine;

public class Moco : MonoBehaviour
{
    [Header("Velocidades")]
    public float speed = 1f;
    public float jumpPower = 10f;

    [Header("Ground checks")]
    public LayerMask mask;
    public float checkRadius;
    public Transform[] checkPoints;

    private Rigidbody2D body;

    private Animator animator;
    private bool facingRight;

    // ====================================
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();

        this.facingRight = true;
    }

    // ====================================
    void Update()
    {
        Vector2 movement = this.body.velocity;
        float horizontal = Input.GetAxis("Horizontal") * speed;

        bool grounded = this.IsGrounded();
        this.animator.SetBool("Ruuning", horizontal != 0);
        this.animator.SetBool("OnAir", !grounded);
        this.animator.SetFloat("FallSpeed", movement.y);

        if (!grounded)
        {
            movement.x = horizontal;
        }
        else
        {
            movement.x += horizontal * 0.1f;
        }

        if (Input.GetButton("Jump"))
        {
            if (grounded)
            {
                movement.y += this.jumpPower * 0.25f;
            }
        }

        this.DoTheFlip(movement.x);

        movement.x = Mathf.Clamp(movement.x, -this.speed, this.speed);
        movement.y = Mathf.Clamp(movement.y, -this.jumpPower, this.jumpPower);

        this.body.velocity = movement;
    }

    // ====================================
    private void DoTheFlip(float hVel)
    {
        if (hVel > 0 && !this.facingRight)
        {
            this.transform.localScale = Vector3.one;

            this.facingRight = true;
        }
        else if (hVel < 0 && this.facingRight)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);

            this.facingRight = false;
        }
    }

    // ====================================
    private bool IsGrounded()
    {
        bool grounded = false;

        foreach (var point in this.checkPoints) {
            var hit = Physics2D.Raycast(point.position, Vector2.down, this.checkRadius, this.mask);

            grounded |= hit.collider != null;
        }

        return grounded;
    }

    // ====================================
    private void OnDrawGizmos()
    {
        foreach (var point in this.checkPoints) {
            Gizmos.DrawWireSphere(point.position, this.checkRadius);
        }
    }

    // ====================================
    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}
