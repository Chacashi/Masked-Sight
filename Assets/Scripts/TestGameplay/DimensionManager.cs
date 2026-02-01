using System.Collections;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{
    [SerializeField] private GameObject glassMask;
    [SerializeField] private ParticleSystem effectChangueDimension;

    [Header("Animación")]
    [SerializeField] private float expansionSpeed = 5f;
    [SerializeField] private float maxScale = 15f;
    private Vector2 ScaleTo;
    private Coroutine currentAnimation;

    [Header("Grupos de Mundos")]
    [SerializeField] private GameObject groupWordNormal; 
    [SerializeField] private GameObject groupAlterWord;  

    [SerializeField] private InputReader inputReader;

    private bool isAlterWorld = false;

    private void OnEnable()
    {
        if (inputReader != null)
            inputReader.ChanguePortalEvent += ChangueDimension;
    }

    private void OnDisable()
    {
        if (inputReader != null)
            inputReader.ChanguePortalEvent -= ChangueDimension;
    }

    private void Start()
    {
       
        if (glassMask != null)
        {
            glassMask.SetActive(true); 
            glassMask.transform.localScale = Vector2.zero;
        }

        ActivateGroup(groupAlterWord, false); 
        ActivateGroup(groupWordNormal, true); 
    }

    private void ChangueDimension()
    {
        if (Time.timeScale == 0f) return;

        isAlterWorld = !isAlterWorld;

        
        if (effectChangueDimension != null)
        {
            effectChangueDimension.gameObject.SetActive(true);
            effectChangueDimension.Stop();
            effectChangueDimension.Play();
        }

       
        ActivateGroup(groupAlterWord, isAlterWorld);       
        ActivateGroup(groupWordNormal, !isAlterWorld);    

   
        if (isAlterWorld)
            ScaleTo = new Vector2(maxScale, maxScale);
        else
            ScaleTo = Vector2.zero;

     
        if (currentAnimation != null)
            StopCoroutine(currentAnimation);

        currentAnimation = StartCoroutine(AnimationMask());
    }

    private IEnumerator AnimationMask()
    {
        while (Vector3.Distance(glassMask.transform.localScale, ScaleTo) > 0.01f)
        {
            glassMask.transform.localScale = Vector3.Lerp(
                glassMask.transform.localScale,
                ScaleTo,
                Time.deltaTime * expansionSpeed
            );
            yield return null;
        }

        glassMask.transform.localScale = ScaleTo;
        currentAnimation = null;
    }

    private void ActivateGroup(GameObject group, bool state)
    {
        if (group == null) return; 

        Collider2D[] collisions = group.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in collisions)
        {
            collider.enabled = state;
        }
    }
}