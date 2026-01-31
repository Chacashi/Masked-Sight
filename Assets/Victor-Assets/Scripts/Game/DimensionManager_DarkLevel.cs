using System.Collections;
using UnityEngine;

public class DimensionManager_DarkLevel : MonoBehaviour
{
    [Header("Darkness Mask")]
    [SerializeField] private GameObject glassMask;
    [SerializeField] private ParticleSystem effectChangueDimension;

    [SerializeField] private float expansionSpeed = 8f;
    [SerializeField] private float maxScale = 6f;

    private Vector2 scaleTo;
    private Coroutine currentAnimation;

    [SerializeField] private InputReader inputReader;

    private bool isAlterWorld = false; 

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
            glassMask.transform.localScale = Vector2.one * maxScale;
        }

        isAlterWorld = false;
    }

    private void ChangueDimension()
    {
        isAlterWorld = !isAlterWorld;

        if (effectChangueDimension != null)
        {
            effectChangueDimension.Stop();
            effectChangueDimension.Play();
        }

        scaleTo = isAlterWorld ? Vector2.zero : Vector2.one * maxScale;

        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
        }

        currentAnimation = StartCoroutine(AnimationMask());
    }

    private IEnumerator AnimationMask()
    {
        while (Vector3.Distance(glassMask.transform.localScale, scaleTo) > 0.01f)
        {
            glassMask.transform.localScale = Vector3.Lerp(glassMask.transform.localScale, scaleTo, Time.deltaTime * expansionSpeed);

            yield return null;
        }

        glassMask.transform.localScale = scaleTo;
        currentAnimation = null;
    }

    public bool IsAlterWorld => isAlterWorld;
}
