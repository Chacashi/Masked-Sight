using UnityEngine;
using DG.Tweening;
public class UIPanelManager : MonoBehaviour
{
    [System.Serializable]
    public class PanelData
    {
        public RectTransform panel;
        public Vector3 hiddenPosition;
        public Vector3 visiblePosition = Vector3.zero;
        [HideInInspector] public bool isVisible;
        public float duration = 0.4f;
        public Ease ease = Ease.OutCubic;
    }
    [SerializeField] private PanelData[] panels;

    private void Start()
    {
        for (int i = 0; i < panels.Length; ++i)
        {
            panels[i].panel.anchoredPosition = panels[i].hiddenPosition;
            panels[i].isVisible = false;
        }
    }

    public void ShowPanel(int index)
    {
        if (index < 0 || index >= panels.Length) return;

        PanelData panel = panels[index];

        panel.isVisible = true;
        panel.panel.DOAnchorPos(panel.visiblePosition, panel.duration).SetEase(panel.ease);
    }

    public void HidePanel(int index)
    {
        if (index < 0 || index >= panels.Length) return;

        PanelData panel = panels[index];

        panel.isVisible = false;
        panel.panel.DOAnchorPos(panel.hiddenPosition, panel.duration).SetEase(panel.ease);
    }

    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
