using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameTest : MonoBehaviour
{
    [SerializeField] private SoundData menuMusic;
    [SerializeField] private LevelSelector levelSelector;

    private void Start()
    {
        AudioManager.Instance.Play(menuMusic);
    }

    public void LoadGame()
    {
        string sceneToLoad = levelSelector.GetCurrentSceneName();
        SceneManager.LoadScene(sceneToLoad);
    }
}
