using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class lobby : MonoBehaviour
{
    public GameObject UI;
    public GameObject SettingUI;
    public GameObject SettingSound;
    public GameObject RankUI;

    public Slider audioSlider;
    public AudioSource audioSource;

    public GameObject StoreBox;
    public GameObject StoreUI;
    public Camera getCamera;
    private RaycastHit hit;

    public TextMeshProUGUI CoinTxt;
    public TextMeshProUGUI LanternTxt;
    public int Coin;
    public int Lantern;

    public GameObject GameRoomBox;

    public TMP_InputField wishInput;
    public string Wish = null;
    public TextMeshProUGUI BoardLanternTxt;
    public TextMeshProUGUI ScrollViewTxt;
    public GameObject LanternBoardBox;
    public GameObject LanternBoardUI;

    public GameObject LanternOriginal;
    public int LanternNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UI.gameObject.SetActive(false);
        Coin = 10;
        Lantern = 100;
        CoinTxt.text = ": " + Coin.ToString();
        LanternTxt.text = ": " + Lantern.ToString();
        BoardLanternTxt.text = ": " + Lantern.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (StoreUI.activeSelf == false && LanternBoardUI.activeSelf == false && Input.GetKeyUp(KeyCode.Escape))
        {
            if (UI.activeSelf == true)
            {
                UI.gameObject.SetActive(false);
            }

            else if (UI.activeSelf == false && SettingUI.activeSelf == false)
            {
                UI.gameObject.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // string objectName = hit.collider.gameObject.name;
                
                // Store UI Ȱ��ȭ
                if (hit.collider.gameObject == StoreBox && SettingSound.activeSelf == false && UI.activeSelf == false && SettingUI.activeSelf == false && LanternBoardUI.activeSelf == false)
                {
                    Debug.Log("������ ���� ��ǰ�� �����մϴ�.");
                    StoreUI.gameObject.SetActive(true);
                    CoinTxt.text = ": " + Coin.ToString();
                    LanternTxt.text = ": " + Lantern.ToString();
                }

                if (hit.collider.gameObject == GameRoomBox && SettingSound.activeSelf == false && UI.activeSelf == false && SettingUI.activeSelf == false && StoreUI.activeSelf == false && LanternBoardUI.activeSelf == false)
                {
                    Debug.Log("���� ��Ī ������ �̵��մϴ�.");
                    GameObject.FindWithTag("FadeController").GetComponent<FadeInOut>().FadeToNext();
                }

                if (hit.collider.gameObject == LanternBoardBox && SettingSound.activeSelf == false && UI.activeSelf == false && SettingUI.activeSelf == false && StoreUI.activeSelf == false)
                {
                    Debug.Log("��� �ҿ��� ����, ������ ��ġ�մϴ�.");
                    LanternBoardUI.gameObject.SetActive(true);
                    BoardLanternTxt.text = ": " + Lantern.ToString();
                }
            }
        }
    }

    public void SettingUIOn()
    {
        if (SettingSound.activeSelf == true && UI.activeSelf == false)
        {
            SettingSound.gameObject.SetActive(false);
            UI.gameObject.SetActive(true);
        }
    }

    public void SettingSoundOn()
    {
        if (UI.activeSelf == true)
        {
            UI.gameObject.SetActive(false);
            SettingSound.gameObject.SetActive(true);
        }
    }

    public void SettingSoundClick()
    {
        if (SettingUI.activeSelf == true && UI.activeSelf == false)
        {
            SettingUI.gameObject.SetActive(false);
            SettingSound.gameObject.SetActive(true);
        }
    }

    public void SettingGraphicOn()
    {
        if (SettingSound.activeSelf == true && UI.activeSelf == false)
        {
            SettingSound.gameObject.SetActive(false);
            SettingUI.gameObject.SetActive(true);
        }
    }

    public void CheckButtonClick()
    {
        if (SettingUI.activeSelf == true && UI.activeSelf == false)
        {
            SettingUI.gameObject.SetActive(false);
            UI.gameObject.SetActive(true);
        }

        else if (SettingSound.activeSelf == true && UI.activeSelf == false)
        {
            SettingSound.gameObject.SetActive(false);
            UI.gameObject.SetActive(true);
        }

        else if (RankUI.activeSelf == true && UI.activeSelf == false)
        {
            RankUI.gameObject.SetActive(false);
            UI.gameObject.SetActive(true);
        }

        else if (StoreUI.activeSelf == true)
        {
            StoreUI.gameObject.SetActive(false);
        }

        else if (LanternBoardUI.activeSelf == true)
        {
            LanternBoardUI.gameObject.SetActive(false);
        }
    }

    public void AudioControl()
    {
        audioSource.volume = audioSlider.value;
    }

    public void Camera()
    {
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        string fileName = "DONGSIM-SCREENSHOT-" + timestamp + ".png";

        if (UI.activeSelf == true)
        {
            UI.gameObject.SetActive(false);
        }

        ScreenCapture.CaptureScreenshot(fileName);

        UI.gameObject.SetActive(true);
    }

    public void RankButtonClick()
    {
        if (UI.activeSelf == true)
        {
            RankUI.gameObject.SetActive(true);
            UI.gameObject.SetActive(false);
        }
    }

    public void LanternBuy()
    {
        if (Coin >= 5)
        {
            Debug.Log("���� 1���� �����Ͽ����ϴ�.");
            Coin = Coin - 5;
            Lantern = Lantern + 1;
            CoinTxt.text = ": " + Coin.ToString();
            LanternTxt.text = ": " + Lantern.ToString();
        }
        else
        {
            Debug.Log("������ �����Ͽ� ������ ������ �� �����ϴ�.");
        }
    }

    public void WriteWish()
    {
        if (Lantern > 0)
        {
            Wish = wishInput.text;

            if (Wish.Length > 0)
            {
                Debug.Log("��� �ҿ��� ����, ������ ��ġ�Ͽ����ϴ�.");
                Lantern = Lantern - 1;
                BoardLanternTxt.text = ": " + Lantern.ToString();
                ScrollViewTxt.text = ScrollViewTxt.text + "\n" + wishInput.text;
                wishInput.text = "";

                int x = Random.Range(0, 30);
                int z = Random.Range(0, 5);
                GameObject LanternClone = Instantiate(LanternOriginal, new Vector3(x, 25, z), Quaternion.identity);
                LanternClone.name = "LanternClone" + (LanternNum + 1);
                LanternNum = LanternNum + 1;
            }

            else
            {
                Debug.Log("�ҿ��� �Է��ϼ���.");
            }
        }
        else
        {
            Debug.Log("������ ������ ���� �ʾ� ��� �ҿ��� ���� �� �����ϴ�. ������ ���� ������ �����ϼ���.");
        }
    }
}
