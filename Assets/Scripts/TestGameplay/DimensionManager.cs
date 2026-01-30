using System.Collections;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{

    [SerializeField] private GameObject glassMask;
    [SerializeField] private ParticleSystem effectChangueDimension;

    [SerializeField] private float expansionSpeed;
    [SerializeField] private float maxScale;
    private Vector2 ScaleTo;
    private Coroutine currentAnimation;



    [SerializeField] private GameObject groupWordNormal;


    [SerializeField] private GameObject groupAlterWord;

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
        if(glassMask != null)
        {
            glassMask.SetActive(true);
            glassMask.transform.localScale = Vector2.zero;
        }

        ActivateGroup(groupAlterWord,false);    
    }

    private void ChangueDimension()
    {
        isAlterWorld = !isAlterWorld;

        if(effectChangueDimension!= null)
        {
            effectChangueDimension.gameObject.SetActive(true);
            effectChangueDimension.Stop();
            effectChangueDimension.Play();
        }

        if(glassMask != null)
            glassMask.SetActive(isAlterWorld);

        ActivateGroup(groupAlterWord, isAlterWorld);    

        if(isAlterWorld)
            ScaleTo = new Vector2(maxScale, maxScale);
        else
            ScaleTo = Vector2.zero;

        if(currentAnimation!= null) 
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

        // Asegurar que llegue exactamente al final
        glassMask.transform.localScale = ScaleTo;
        currentAnimation = null; 
    }


    private void ActivateGroup(GameObject group , bool state)
    {
        Collider2D[] collisions = group.GetComponentsInChildren<Collider2D>();



        foreach(Collider2D collider in collisions)
        {
            collider.enabled = state;
        }


    }
}
