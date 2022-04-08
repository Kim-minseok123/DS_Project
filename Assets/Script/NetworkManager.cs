using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    string networkState; // ��Ʈ��ũ ���¸� Ȯ�� �ϱ����� ���ڿ�

    void Start() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() =>
        PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby() =>
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 5 }, null);

    // Update is called once per frame
    void Update()
    {
        string curNetworkState = PhotonNetwork.NetworkClientState.ToString();
        if (networkState != curNetworkState) {
            networkState = curNetworkState;
            print(networkState);
        }
    }
}
