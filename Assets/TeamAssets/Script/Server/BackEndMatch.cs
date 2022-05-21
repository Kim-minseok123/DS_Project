using UnityEngine;
using UnityEngine.UI;
using BackEnd;
using UnityEngine.SceneManagement;

public partial class BackEndMatch : MonoBehaviour
{
    private static BackEndMatch instance = null; // �ν��Ͻ�
    public Text nickName;
    string mynickName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        OnBackendUserInfo();
        SetNickName();
    }
    public static BackEndMatch GetInstance()
    {
        if (!instance)
        {
            //Debug.LogError("BackEndMatchManager �ν��Ͻ��� �������� �ʽ��ϴ�.");
            return null;
        }

        return instance;
    }
    // Update is called once per frame
    void Update()
    {
        Backend.Match.Poll();
    }

    void OnBackendUserInfo() {
        BackendReturnObject bro = Backend.BMember.GetUserInfo();
        mynickName = bro.GetReturnValuetoJSON()["row"]["nickname"].ToString();
    }

    void SetNickName() {
        nickName.text = mynickName;
    }

    public void GoLobby() {
        Backend.BMember.Logout();
        SceneManager.LoadScene("Title_DS");
    }
}
