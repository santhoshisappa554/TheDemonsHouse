using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    private Audio_Manager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        print(PlayerPrefsManager.GetMasterVolume());
        print(PlayerPrefsManager.GetDifficulty());
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        audioManager = GameObject.Find("AudioManager").GetComponent<Audio_Manager>();
        audioManager = GameObject.FindObjectOfType<Audio_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        audioManager.SetVolume("BG", volumeSlider.value);

    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        print(PlayerPrefsManager.GetMasterVolume());
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        print(PlayerPrefsManager.GetDifficulty());
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.3f;
        difficultySlider.value = 0.3f;
    }
}
