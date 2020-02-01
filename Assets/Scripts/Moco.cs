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
        float h = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButton("Jump");

        Vector2 movement = h * Vector2.right * speed;
        movement.y = this.body.velocity.y;

        if (jump)
        {
            if (this.IsGrounded())
            {
                movement.y = Mathf.Clamp(movement.y + this.jumpPower, 0, this.jumpPower);
            }
        }

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
