using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ExitPannel;
    public string thisScene;

    // Use this for initialization
    void Start()
    {
        thisScene = SceneManager.GetActiveScene().name;  // ���� ���� ���� �̸��� �����´�
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))   // EscŰ�� ������
        {
            Time.timeScale = 0f;
            ExitPannel.SetActive(true);
        }
    }

    public void ����ϱ�()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadSceneAsync("MainGame");
        ExitPannel.SetActive(false);
    }

    public void ��������()

    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();   // �����Ѵ�
#endif
    }

}