using UnityEngine;

public class Slimewalk : MonoBehaviour
{
    public float hopForce = 5f;       // ความสูงในการกระโดด
    public float forwardForce = 3f;   // แรงไปข้างหน้า
    public float hopCooldown = 1.5f;  // หน่วงเวลาก่อนกระโดดอีกครั้ง

    private Rigidbody rb;
    private Animator anim;
    private bool canHop = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); // ต้องมี Animator ติดอยู่
    }

    void Update()
    {
        if (canHop && IsGrounded())
        {
            Hop();
        }
    }

    void Hop()
    {
        canHop = false;

        // รีเซ็ตความเร็วแกน Y ก่อนกระโดด
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        // กระโดดขึ้น + ไปข้างหน้า
        Vector3 hopDirection = transform.forward * forwardForce + Vector3.up * hopForce;
        rb.AddForce(hopDirection, ForceMode.Impulse);

        // เล่นแอนิเมชันกระโดด
        if (anim != null)
        {
            anim.SetTrigger("Jump");
        }

        Invoke(nameof(ResetHop), hopCooldown);
    }

    void ResetHop()
    {
        canHop = true;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (anim != null)
            {
                anim.SetTrigger("Land");
            }
        }
    }
}
