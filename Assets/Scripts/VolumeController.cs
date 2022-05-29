using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    // [SerializeField] Slider volumeSlider = null;
    // [SerializeField] TextMeshProUGUI volumeText = null;

    // private void Start() 
    // {
    //     LoadValues();
    // }

    // public void VolumeSlider(float volume)
    // {
    //     volumeText.text = volume.ToString("0.0");
    // }

    // public void SaveVolumeButton()
    // {
    //     float volumeValue = volumeSlider.value;
    //     PlayerPrefs.SetFloat("VolumeValue", volumeValue);
    //     LoadValues();
    // }

    // void LoadValues()
    // {
    //     float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
    //     volumeSlider.value = volumeValue;
    //     AudioListener.volume = volumeValue;
    // }
}
