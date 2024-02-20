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

    public TextMeshProUGUI RaceTime;

    public TextMeshProUGUI SaleText;
    public TextMeshProUGUI RaceText;

    public Toggle TogglAudio;
    private bool isMuteAudio;
    public AudioSource A0;
    public AudioSource A1;

    public TextMeshProUGUI RaceStart;
    private int culdawn = 5;
    private float RaceStartTime;
    private bool isRace = false;

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
    private void Update()
    {
        if (!isRace) return;

        if(RaceStartTime > 0)
        {
            RaceStartTime = RaceStartTime - Time.deltaTime;
            RaceStart.text = "0:0" + Mathf.Round(RaceStartTime).ToString();
        }
        else
        {
            RaceLoad();
        }
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
    public void Race(bool Race)
    {
        isRace = Race;
        RaceStartTime = culdawn;
    }
    public void RaceLoad()
    {
        SceneManager.LoadScene(Random.Range(1, 3)); 
        //SceneManager.LoadScene(3);
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
        A1.mute = true;
    }
    public void AudioPlay()
    {
        A0.mute = false;
        A1.mute = false;
    }
}
