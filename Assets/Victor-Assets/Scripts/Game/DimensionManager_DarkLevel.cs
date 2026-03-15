using System.Collections;
using UnityEngine;

public class DimensionManager_DarkLevel : MonoBehaviour
{
    [Header("Player Animation")]
    [SerializeField] private PlayerAnimations playerAnimations;

    [Header("Darkness Mask")]
    [SerializeField] private GameObject glassMask;
    [SerializeField] private ParticleSystem effectChangueDimension;

    [Header("Animation")]
    [SerializeField] private float expansionSpeed = 8f;
    [SerializeField] private float maxScale = 6f;

    private Vector2 scaleTo;
    private Coroutine currentAnimation;

    [Header("Normal World Objects")]
    [SerializeField] private GameObject groupWordNormal;

    [SerializeField] private InputReader inputReader;

    private bool isAlterWorld = true;

    private void OnEnable()
    {
        inputReader.ChanguePortalEvent += ChangueDimension;
    }

    private void OnDisable()
    {
        inputReader.ChanguePortalEvent -= ChangueDimension;
    }

    private void Start()
    {
        if (glassMask != null)
        {
            glassMask.SetActive(true);
            glassMask.transform.localScale = Vector2.zero;
        }

        if (playerAnimations != null)
            playerAnimations.SetMask(false);

        ActivateGroup(groupWordNormal, true);
    }

    private void ChangueDimension()
    {
        if (Time.timeScale == 0f) return;

        isAlterWorld = !isAlterWorld;

        if (playerAnimations != null)
            playerAnimations.SetMask(!isAlterWorld);

        if (effectChangueDimension != null)
        {
            effectChangueDimension.Stop();
            effectChangueDimension.Play();
        }

        ActivateGroup(groupWordNormal, isAlterWorld == false);

        scaleTo = isAlterWorld ? Vector2.zero : Vector2.one * maxScale;

        if (currentAnimation != null)
            StopCoroutine(currentAnimation);

        currentAnimation = StartCoroutine(AnimationMask());
    }

    private IEnumerator AnimationMask()
    {
        while (Vector3.Distance(glassMask.transform.localScale, scaleTo) > 0.01f)
        {
            glassMask.transform.localScale = Vector3.Lerp(
                glassMask.transform.localScale,
                scaleTo,
                Time.deltaTime * expansionSpeed
            );

            yield return null;
        }

        glassMask.transform.localScale = scaleTo;
        currentAnimation = null;
    }

    private void ActivateGroup(GameObject group, bool state)
    {
        if (group == null) return;

        Collider2D[] collisions = group.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in collisions)
        {
            collider.enabled = !state;
        }

        SpriteRenderer[] renderers = group.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.enabled = !state;
        }
    }

    public bool IsAlterWorld => isAlterWorld;
}