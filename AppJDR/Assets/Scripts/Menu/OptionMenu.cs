using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider VoiceSlider;
    [SerializeField] private Slider UISlider;
    [SerializeField] private Text MusicText;
    [SerializeField] private Text VoiceText;
    [SerializeField] private Text UIText;

    private SoundOption option;

    public void LoadOption()
    {
        option = OptionsManager._Instance.soundOption;
        MusicSlider.value = option.MusicVolume;
        VoiceSlider.value = option.VoiceVolume;
        UISlider.value = option.UIVolume;
        ChangeText();
    }

    public void SaveOption()
    {
        OptionsManager._Instance.SaveSoundOption(option);
    }

    void Update()
    {
        if (MusicSlider.value != option.MusicVolume ||
            VoiceSlider.value != option.VoiceVolume ||
            UISlider.value != option.UIVolume)
        {
            option.MusicVolume = MusicSlider.value;
            option.VoiceVolume = VoiceSlider.value;
            option.UIVolume = UISlider.value;
            ChangeText();
        }
    }

    void ChangeText()
    {
        MusicText.text = ((int)(option.MusicVolume*100)).ToString();
        VoiceText.text = ((int)(option.VoiceVolume * 100)).ToString();
        UIText.text = ((int)(option.UIVolume * 100)).ToString();

    }
}
