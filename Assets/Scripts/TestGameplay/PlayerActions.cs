using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputReader inputReader;


    [Header("Movimiento")]
    [SerializeField] private float speed;



    [Header("Salto")]
    [SerializeField] private float forceJump;
    private bool canJump = true;



    private Rigidbody2D rb;

    private float inputValue;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        inputReader.MovementEvent += SetMovementValue;
        inputReader.JumpEvent += Jump;
    }

    private void OnDisable()
    {
        inputReader.MovementEvent -= SetMovementValue;
        inputReader.JumpEvent -= Jump;
    }


    #region Movimiento
    private void SetMovementValue(float value)
    {
        inputValue = value;
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(  inputValue * speed, rb.linearVelocity.y );
    }
    #endregion



    #region Salto
    private void Jump()
    {
        if(!canJump)
            return;
        rb.AddForce(Vector2.up * forceJump,ForceMode2D.Impulse);
        canJump= false;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        canJump = true;
    }

    #endregion
}
