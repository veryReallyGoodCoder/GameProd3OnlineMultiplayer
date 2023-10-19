using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using System.Collections.Generic;


public class Options : MonoBehaviour
{
    public Slider volumeSlider;
    public Dropdown resolutionDropdown;
    public Slider fovSlider;


    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public GameObject canvasObject;
    private bool canvasActive = true;
    private InputAction toggleAction;

    private void Start()
    {
        toggleAction = new InputAction(binding: "<Keyboard>/escape");
        toggleAction.performed += ToggleCanvas;
        toggleAction.Enable();

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width +"x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void ToggleCanvas(InputAction.CallbackContext context)
    {
        canvasActive = !canvasActive;
        canvasObject.SetActive(canvasActive);
    }

    private void onDestroy()
    {
        toggleAction.Disable();
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetResolution()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFOV()
    {
        Camera.main.fieldOfView = fovSlider.value;
    }
}
