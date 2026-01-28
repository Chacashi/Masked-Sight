using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed;

    [Header("Input")]
    [SerializeField] private InputReader inputReader;


    private Rigidbody2D rb;

    private float inputValue;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        inputReader.MovementEvent += SetMovementValue;
    }

    private void OnDisable()
    {
        inputReader.MovementEvent -= SetMovementValue;
    }


    private void SetMovementValue(float value)
    {
        inputValue = value;
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(  inputValue * speed, rb.linearVelocity.y );
    }


}
