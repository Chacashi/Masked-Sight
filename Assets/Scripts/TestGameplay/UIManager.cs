using UnityEngine;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelStop;
    [SerializeField] private InputReader inputReader;



    private void Awake()
    {
        inputReader.SetGameplay();
    }
    private void OnEnable()
    {
        inputReader.PauseEvent += SetPause;

        inputReader.ResumeEvent += SetResume;
    }


    private void OnDisable()
    {
        inputReader.PauseEvent -= SetPause;
        inputReader.ResumeEvent -= SetResume;
    }



    private void SetPause()
    {
        Time.timeScale = 0.0f;
        panelStop.alpha = 1.0f;
        panelStop.interactable= true;
        panelStop.blocksRaycasts= true;
    }


    private void SetResume()
    {
        Time.timeScale = 1.0f;
        panelStop.alpha = 0.0f;
        panelStop.interactable= false;
        panelStop.blocksRaycasts= false;
    }


}
