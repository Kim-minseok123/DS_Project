using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using BackEnd;
public class lobby : MonoBehaviour
{
    public GameObject UI;
    public GameObject SettingUI;
    public GameObject SettingSound;
    public GameObject RankUI;
    public GameObject loUI;
    public GameObject CurUI;
    public Slider audioSlider;
    public AudioSource audioSource;

    public GameObject StoreBack;
    public GameObject StoreFront;
    public GameObject StoreUI;
    public Camera getCamera;
    private RaycastHit hit;

    public TextMeshProUGUI CoinTxt;
    public TextMeshProUGUI LanternTxt;
    public TextMeshProUGUI CoinTxtCur;
    public TextMeshProUGUI LanternTxtCur;
    public int Coin;
    public int Lantern;

    public GameObject GameRoomBack;
    public GameObject GameRoomFront;

    public TMP_InputField wishInput;
    public string Wish = null;
    public TextMeshProUGUI BoardWishTxt;
    public GameObject LanternBoardBox;
    public GameObject LanternBoardUI;
    string inDate = "";
    public int wishnum = 0;

    private static lobby instance = null;
    private void Awake()
    {
        if (instance != null) {
            Destroy(instance);
        }
        instance = this;
        //��, ���� ���� �ʱ�ȭ(�����ͺ��̽� ����)
        Where where = new Where();
        var bro = Backend.GameData.GetMyData("user", where);
        
        if (bro.Rows().Count > 0)
        {
            inDate = bro.Rows()[0]["inDate"]["S"].ToString();
        }
        Coin = int.Parse(bro.Rows()[0]["Money"]["S"].ToString());
        Lantern = int.Parse(bro.Rows()[0]["Lantern"]["S"].ToString());
    }
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        UI.gameObject.SetActive(false);

        wishnum = 0;
        CoinTxt.text = ": " + Coin.ToString();
        LanternTxt.text = ": " + Lantern.ToString();
        CoinTxtCur.text = ": " + Coin.ToString();
        LanternTxtCur.text = ": " + Lantern.ToString();
        BoardWishTxt.text = ": " + wishnum.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StoreUI.activeSelf == false && LanternBoardUI.activeSelf == false && Input.GetKeyUp(KeyCode.Escape))
        {
            if (UI.activeSelf == true)
            {
                UI.gameObject.SetActive(false);
                loUI.SetActive(true);
                CurUI.SetActive(true);
            }

            else if (UI.activeSelf == false && SettingUI.activeSelf == false)
            { 
                UI.gameObject.SetActive(true);
                loUI.SetActive(false);
                CurUI.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                string objectName = hit.collider.gameObject.name;

                // Store UI Ȱ��ȭ
                if (hit.collider.gameObject == StoreBack || hit.collider.gameObject == StoreFront && SettingSound.activeSelf == false && UI.activeSelf == false && SettingUI.activeSelf == false && LanternBoardUI.activeSelf == false)
                {
                    Debug.Log("������ ���� ��ǰ�� �����մϴ�.");
                    StoreUI.gameObject.SetActive(true);
                    CurUI.gameObject.SetActive(false);
                    CoinTxt.text = ": " + Coin.ToString();
                    LanternTxt.text = ": " + Lantern.ToString();
                    CoinTxtCur.text = ": " + Coin.ToString();
                    LanternTxtCur.text = ": " + Lantern.ToString();
                }

                if (hit.collider.gameObject == GameRoomBack || hit.collider.gameObject == GameRoomFront && SettingSound.activeSelf == false && UI.activeSelf == false && SettingUI.activeSelf == false && StoreUI.activeSelf == false && LanternBoardUI.activeSelf == false)
                {
                    Debug.Log("���� ��Ī ������ �̵��մϴ�.");
                    GameObject.FindWithTag("FadeController").GetComponent<FadeInOut>().FadeToNext();
                }
            }
        }
    }
    public static lobby GetInstance() {
        if(!instance)
        {
            return null;
        }
        return instance;
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
            CurUI.gameObject.SetActive(true);
        }

        else if (LanternBoardUI.activeSelf == true)
        {
            LanternBoardUI.gameObject.SetActive(false);
            CurUI.gameObject.SetActive(true);
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
            Coin = Coin - 5;
            Lantern = Lantern + 1;
            Param param = new Param();
            param.Add("Money", Coin.ToString());
            param.Add("Lantern", Lantern.ToString());
            Backend.GameData.Update("user", inDate, param);
            Debug.Log("���� 1���� �����Ͽ����ϴ�.");
            
            CoinTxt.text = ": " + Coin.ToString();
            LanternTxt.text = ": " + Lantern.ToString();
            CoinTxtCur.text = ": " + Coin.ToString();
            LanternTxtCur.text = ": " + Lantern.ToString();

            StoreUI.gameObject.SetActive(false);
            LanternBoardUI.gameObject.SetActive(true);
            BoardWishTxt.text = ": " + Lantern.ToString();
        }
        else
        {
            Debug.Log("������ �����Ͽ� ������ ������ �� �����ϴ�.");
        }
    }

    public void WriteWish()
    {
        Wish = wishInput.text;
        if (Wish.Length > 0)
        {
            Debug.Log("��� �ҿ��� �������ϴ�.");
            wishInput.text = "";
            StoreUI.gameObject.SetActive(true);
            LanternBoardUI.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("�ҿ��� �Է��ϼ���.");
        }
    }
    public void updateLantern() { 
        Lantern = Lantern -1;
        Param param = new Param();
        param.Add("Lantern", Lantern.ToString());
        Backend.GameData.Update("user", inDate, param);
        LanternTxt.text = ": " + Lantern.ToString();
        LanternTxtCur.text = ": " + Lantern.ToString();
    }
    public bool IsLanternGet()
    {
        if(Lantern > 0)
            return true;
        else
            return false;
    }
}
