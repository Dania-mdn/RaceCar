using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Money;
    public TextMeshProUGUI MoneyInSecond;

    public Slider SliderAutotap;
    public Slider SliderIncomX2;

    public GameObject Income;
    public TextMeshProUGUI IncomePrice;

    public GameObject SaleButtonFalse;
    public TextMeshProUGUI PartsSale;

    public TextMeshProUGUI PartsPrice;
    public GameObject BuyBlock;
    public TextMeshProUGUI PartsPriceBlock;

    public TextMeshProUGUI SaleText;

    public Toggle TogglAudio;
    private bool isMuteAudio;
    public AudioSource A0;

    private void OnEnable()
    {
        EventManager.OnClickDown += OnclickDown;
        EventManager.SetAvalebleIncpmMoney += AvalebleIncpmMoney;
        EventManager.MuteAudio += AudioMute;
        EventManager.PlayAudio += AudioPlay;
    }
    private void OnDisable()
    {
        EventManager.OnClickDown -= OnclickDown;
        EventManager.SetAvalebleIncpmMoney -= AvalebleIncpmMoney;
        EventManager.MuteAudio -= AudioMute;
        EventManager.PlayAudio -= AudioPlay;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("MuteAudio"))
            TogglAudio.isOn = true;
    }
    private void OnclickDown(bool isClick)
    {
        if (isClick)
        {
            SaleButtonFalse.SetActive(true);
        }
        else
        {
            SaleButtonFalse.SetActive(false);
        }
    }
    private void AvalebleIncpmMoney(float AvalableCount)
    {
        if (AvalableCount >= 4)
        {
            Income.SetActive(false);
        }
        else
        {
            Income.SetActive(true);
        }
    }
    public void RaceLoad()
    {
        SceneManager.LoadScene(Random.Range(1, 3)); 
        PlayerPrefs.SetInt("Race", 1);
    }
    public void Audio()
    {
        if (isMuteAudio == false)
        {
            isMuteAudio = true;
            EventManager.DoMuteAudio();
            PlayerPrefs.SetInt("MuteAudio", 1);
        }
        else
        {
            isMuteAudio = false;
            EventManager.DoPlayAudio();
            PlayerPrefs.DeleteKey("MuteAudio");
        }
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        EventManager.DoDeleteAll();
    }
    public void AudioMute()
    {
        A0.mute = true;
    }
    public void AudioPlay()
    {
        A0.mute = false;
    }
}
