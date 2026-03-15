using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool grounded;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("YVelocity", rb.linearVelocity.y);
        animator.SetBool("Grounded", grounded);
    }

    public void SetGrounded(bool value)
    {
        grounded = value;
    }

    public void SetMask(bool value)
    {
        Debug.Log("Mask cambiado a: " + value);
        animator.SetBool("Mask", value);
    }
}