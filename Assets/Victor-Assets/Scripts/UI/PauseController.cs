using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private UIPanelManager panelManager;
    [SerializeField] private int optionsPanelIndex = 0;

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
}
