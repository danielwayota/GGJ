using UnityEngine;

public class Moco : MonoBehaviour
{
    [Header("Velocidades")]
    public float speed = 1f;
    public float jumpPower = 10f;

    [Header("Ground checks")]
    public LayerMask mask;
    public float checkRadius;
    public Transform checkPoint;

    private Rigidbody2D body;

    // ====================================
    void Start()
    {
        this.body = this.GetComponent<Rigidbody2D>();
    }

    // ====================================
    void Update()
    {
        Vector2 movement = this.body.velocity;

        float horizontal = Input.GetAxis("Horizontal") * speed;
        if (this.IsGrounded())
        {
            movement.x = horizontal;
        }
        else
        {
            movement.x += horizontal * 0.1f;
        }

        if (Input.GetButton("Jump"))
        {
            if (this.IsGrounded())
            {
                movement.y += this.jumpPower * 0.25f;
            }
        }

        movement.x = Mathf.Clamp(movement.x, -this.speed, this.speed);
        movement.y = Mathf.Clamp(movement.y, -this.jumpPower, this.jumpPower);

        this.body.velocity = movement;
    }

    // ====================================
    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(this.checkPoint.position, Vector2.down, this.checkRadius, this.mask);

        return hit.collider != null;
    }

    // ====================================
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.checkPoint.position, this.checkRadius);
    }

    // ====================================
    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}
