﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuControlScriptBGMSFX : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] Button buttonStart;
    [SerializeField] Button buttonOptions;
    [SerializeField] Button buttonHelp;
    [SerializeField] Button buttonExit;
    [SerializeField] Button buttonSoundTestingScene;
    

    AudioSource audiosourceButtonUI;
    [SerializeField] AudioClip audioclipHoldOver;
    void Start()
    {
        this.audiosourceButtonUI = this.gameObject.AddComponent<AudioSource>();
        this.audiosourceButtonUI.outputAudioMixerGroup = SingletonSoundManager.Instance.Mixer
       .FindMatchingGroups("UI")[0];

        SetupButtonsDelegate();

        if (!SingletonSoundManager.Instance.BGMSource.isPlaying)
            SingletonSoundManager.Instance.BGMSource.Play();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audiosourceButtonUI.isPlaying)
            audiosourceButtonUI.Stop();
        audiosourceButtonUI.PlayOneShot(audioclipHoldOver);
    }
    void SetupButtonsDelegate()
    {
        buttonStart.onClick.AddListener(delegate { StartButtonClick(buttonStart); });
        buttonOptions.onClick.AddListener(delegate { OptionsButtonClick(buttonOptions); });
        buttonHelp.onClick.AddListener(delegate { HelpButtonClick(buttonHelp); });
        buttonExit.onClick.AddListener(delegate { ExitButtonClick(buttonExit); });
        buttonSoundTestingScene.onClick.AddListener(delegate {SoundTestingButtonClick(buttonSoundTestingScene);   });
        
    }
    public void StartButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneStageSelect");
        if (SingletonSoundManager.Instance.BGMSource.isPlaying)
            SingletonSoundManager.Instance.BGMSource.Stop();
    }
    public void OptionsButtonClick(Button button)
    {
        if (!SingletonGameApplicationManager.Instance.IsOptionMenuActive)
        {
            SceneManager.LoadScene("SceneOptions", LoadSceneMode.Additive);
            SingletonGameApplicationManager.Instance.IsOptionMenuActive = true;
        }
    }
    public void HelpButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneHelp");
        if (SingletonSoundManager.Instance.BGMSource.isPlaying)
            SingletonSoundManager.Instance.BGMSource.Stop();
    }
    public void SoundTestingButtonClick(Button button)
    {
        if (SingletonSoundManager.Instance.BGMSource.isPlaying)
            SingletonSoundManager.Instance.BGMSource.Stop();

        SceneManager.LoadScene("SceneSoundTesting");
    }
    public void ExitButtonClick(Button button)
    {
        Application.Quit();
    }
    
}


