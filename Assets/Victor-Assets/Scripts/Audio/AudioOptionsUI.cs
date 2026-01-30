using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsUI : MonoBehaviour
{
    [SerializeField] private AudioSettingsSO settings;
    [SerializeField] private Slider master;
    [SerializeField] private Slider music;
    [SerializeField] private Slider sfx;

    private void Start()
    {
        settings.Load();

        master.onValueChanged.AddListener(settings.SetMaster);
        music.onValueChanged.AddListener(settings.SetMusic);
        sfx.onValueChanged.AddListener(settings.SetSFX);
    }
}
