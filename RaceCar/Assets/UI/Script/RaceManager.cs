using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public Test Test;
    public EnemyRace EnemyRacePlayer;
    public EnemyRace EnemyRace;
    public Rigidbody EnemyRb;
    public Rigidbody PlayerRb;
    public GameObject BorderFinish;

    public Canvas Canvas;
    public GameObject Joistick;
    public GameObject Winner;
    public GameObject Lost;
    public Camera Camera;
    public CinemachineVirtualCamera VirtualCamera;

    private float Coldawn = 5;
    private float TimeStart;
    private bool isstart = false;
    private bool isFinish = false;

    public int RaceCountforWinn = 2;
    private int RaceCountPlayer = 0;
    public bool isCheckRacePlayer = true;
    private int RaceCountEnemy = 0;
    public bool isCheckRaceEnemy = true;

    public GameObject Spedometr;
    public GameObject Arrou;
    public GameObject StartObject;
    public GameObject[] StartLight;

    public GameObject winArrou;
    private float _targetRotation = 0.0f;
    private float rewardMoney = 1;
    public TextMeshProUGUI rewardMoneyTextWon;
    public TextMeshProUGUI rewardMoneyTextLost;

    public AudioSource StartAud;
    public AudioSource MeinAud;
    public AudioSource Winn;
    public AudioSource Lose;

    private void Start()
    {
        VirtualCamera.Priority = 3;
        TimeStart = Coldawn;
        StartObject.SetActive(true);

        if (PlayerPrefs.HasKey("MuteAudio"))
        {
            AudioMute();
        }
    }
    void Update()
    {
        if (Winner.activeSelf == true)
        {
            _targetRotation = Mathf.Repeat(winArrou.transform.localRotation.eulerAngles.z + 180f, 360f) - 180f;
        }

        if (!isFinish)
        {
            if (RaceCountPlayer > RaceCountforWinn)
            {
                Finish(true);
            }
            else if (RaceCountEnemy > RaceCountforWinn)
            {
                Finish(false);
            }
        }

        if (isstart) return;

        if (TimeStart > 0)
        {
            TimeStart = TimeStart - Time.deltaTime;

            if (TimeStart > 3)
            {

            }
            else if (TimeStart > 2)
            {
                if(StartAud.isPlaying == false)
                    StartAud.Play();
                Arrou.SetActive(true);
                VirtualCamera.Priority = 1;
                StartLight[0].SetActive(true);
                StartLight[1].SetActive(false);
                StartLight[2].SetActive(false);
            }
            else if (TimeStart > 1)
            {
                StartLight[0].SetActive(false);
                StartLight[1].SetActive(true);
                StartLight[2].SetActive(false);
            }
            else
            {
                StartLight[0].SetActive(false);
                StartLight[1].SetActive(false);
                StartLight[2].SetActive(true);
            }
        }
        else
        {
            isstart = true;
            EnemyRb.constraints = RigidbodyConstraints.None;
            PlayerRb.constraints = RigidbodyConstraints.None;

            if (StartObject.activeSelf == true)
            {
                StartObject.SetActive(false);
            }
        }
    }
    public void Finish(bool isWin)
    {
        if (isWin)
        {
            EnemyRacePlayer.enabled = true;
            Test.enabled = false;
            VirtualCamera.Priority = 3;
            isFinish = true;
            Canvas.planeDistance = 2;
            Joistick.SetActive(false);
            Winner.SetActive(true);
            rewardMoney = PlayerPrefs.GetFloat("PartsPrize") * 2;
            FormaterCount(Mathf.Round(rewardMoney), rewardMoneyTextWon);
        }
        else
        {
            EnemyRacePlayer.enabled = true;
            Test.enabled = false;
            VirtualCamera.Priority = 3;
            isFinish = true;
            Canvas.planeDistance = 2;
            Joistick.SetActive(false);
            Lost.SetActive(true);
            rewardMoney = PlayerPrefs.GetFloat("PartsPrize") * 2;
            FormaterCount(Mathf.Round(rewardMoney), rewardMoneyTextLost);
        }
        MeinAud.mute = true;
        Spedometr.SetActive(false);
        BorderFinish.SetActive(false);
    }
    public void RewardXmonney()
    {
        if (_targetRotation <= 15 && _targetRotation >= -15)
        {
            rewardMoney = rewardMoney * 4;
        }
        else if((_targetRotation > 15 && _targetRotation <= 65) || (_targetRotation >= -65 && _targetRotation < -15))
        {
            rewardMoney = rewardMoney * 2;
        }
        else
        {
            rewardMoney = rewardMoney * 3;
        }

        EventManager.DoReward();
        MeinMenu();
    }
    public void retryScene()
    {
        EventManager.DoReward();

        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name);
    }
    public void MeinMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetFloat("rewardMoney", rewardMoney);
        PlayerPrefs.DeleteKey("Race");
        PlayerPrefs.SetInt("RaceCuldawn", 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            if (isCheckRacePlayer)
            {
                RaceCountPlayer++;
                isCheckRacePlayer = false;
            }
        }
        else if (other.gameObject.layer == 11)
        {
            if (isCheckRaceEnemy)
            {
                RaceCountEnemy++;
                isCheckRaceEnemy = false;
            }
        }
    }
    private void FormaterCount(float Value, TextMeshProUGUI TextValue)
    {
        if (Value >= 1000000000)
        {
            TextValue.text = "REWARD: $" + (Value / 1000000000f).ToString("F1") + "B";
        }
        else if (Value >= 1000000)
        {
            TextValue.text = "REWARD: $" + (Value / 1000000f).ToString("F1") + "M";
        }
        else if (Value >= 1000)
        {
            TextValue.text = "$REWARD: $" + (Value / 1000f).ToString("F1") + "K";
        }
        else
        {
            TextValue.text = "REWARD: $" + Value.ToString();
        }
    }
    public void AudioMute()
    {
        MeinAud.mute = true;
        StartAud.mute = true;
        Winn.mute = true;
        Lose.mute = true;
    }
    public void AudioPlay()
    {
        MeinAud.mute = false;
        StartAud.mute = false;
        Winn.mute = false;
        Lose.mute = false;
    }
}
