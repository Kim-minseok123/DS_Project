using System;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using BackEnd.Tcp;
using System.Linq;


public partial class BackEndMatch : MonoBehaviour
{
    public class MatchInfo
    {
        public string title;                // ��Ī ��
        public string inDate;               // ��Ī inDate (UUID)
        public MatchType matchType;         // ��ġ Ÿ��
        public MatchModeType matchModeType; // ��ġ ��� Ÿ��
        public string headCount;            // ��Ī �ο�
        public bool isSandBoxEnable;        // ����ڽ� ��� (AI��Ī)
    }
    private static BackEndMatch instance = null; // �ν��Ͻ�

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
        joinmatchserver();


    }

    // Update is called once per frame
    void Update()
    {
        Backend.Match.Poll();
    }

    void joinmatchserver() {
        ErrorInfo errorInfo;
        Backend.Match.JoinMatchMakingServer(out errorInfo);
        Backend.Match.OnJoinMatchMakingServer = (JoinChannelEventArgs args) =>
        {
            Debug.Log("��Ī ���� ���� �Ϸ�");
        };
    }
}