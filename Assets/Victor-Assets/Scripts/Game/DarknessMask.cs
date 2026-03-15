using UnityEngine;

public class DarknessMask : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Transform player;

    [SerializeField] private float smallRadius = 2f;
    [SerializeField] private float bigRadius = 25f; 

    [SerializeField] private float expandSpeed = 8f;

    private float targetRadius;
    private float currentRadius;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        targetRadius = smallRadius;
        currentRadius = smallRadius;
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        currentRadius = Mathf.Lerp(currentRadius, targetRadius, expandSpeed * Time.deltaTime);

        transform.localScale = Vector3.one * currentRadius;
    }

    public void SetMask(bool activeMask)
    {
        if (activeMask)
        {
            targetRadius = bigRadius;
            spriteRenderer.enabled = false;
        }
        else
        {
            targetRadius = smallRadius;
            spriteRenderer.enabled = true;
        }
    }
}