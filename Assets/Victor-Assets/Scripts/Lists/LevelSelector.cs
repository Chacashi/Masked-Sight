using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    [Header("UI")]
    public Image levelImage;
    public TextMeshProUGUI levelTitle;

    [Header("Buttons")]
    public Button nextButton;
    public Button previousButton;

    [Header("Levels")]
    public LevelData[] levels;
    private int currentIndex = 0;

    void Start()
    {
        UpdateUI();
    }

    public void NextLevel()
    {
        if (currentIndex < levels.Length - 1)
        {
            currentIndex++;
            UpdateUI();
        }
    }

    public void PreviousLevel()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        levelImage.sprite = levels[currentIndex].image;
        levelTitle.text = levels[currentIndex].name;

        previousButton.interactable = currentIndex > 0;
        nextButton.interactable = currentIndex < levels.Length - 1;
    }

    public string GetCurrentSceneName()
    {
        return levels[currentIndex].sceneName;
    }
}
