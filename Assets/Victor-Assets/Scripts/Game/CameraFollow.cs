using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Settings Camera")]
    [SerializeField] private Transform player;
    [SerializeField] private float minX, minY, maxX, maxY;
    private void LateUpdate()
    {
        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(player.position.y, minY, maxY);

        Vector3 posX = new Vector3(clampedX, 0, -10);
        Vector3 posY = new Vector3(0, clampedY, 0);

        transform.position = new Vector3(clampedX, Mathf.Lerp(transform.position.y, clampedY, 0.1f), -10);
    }
}
