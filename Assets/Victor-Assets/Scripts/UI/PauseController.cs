using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private UIPanelManager panelManager;
    [SerializeField] private int optionsPanelIndex = 0;
    [SerializeField] private InputReader inputReader;
    public void Pause()
    {
        Time.timeScale = 0f;
        panelManager.ShowPanel(optionsPanelIndex);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        panelManager.HidePanel(optionsPanelIndex);
    }

    private void Awake()
    {
        inputReader.SetGameplay();
    }

    private void OnEnable()
    {
        inputReader.PauseEvent += Pause;

        inputReader.ResumeEvent += Resume;
    }


    private void OnDisable()
    {
        inputReader.PauseEvent -= Pause;
        inputReader.ResumeEvent -= Resume;
    }

}
