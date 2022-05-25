using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using TMPro;
using Unity.Netcode;
public class Getname : NetworkBehaviour
{
    private NetworkVariable<NetworkString> playersName = new NetworkVariable<NetworkString>();

    private bool overlaySet = false;
    //private bool isonetimeset = false;
    // Start is called before the first frame update
  
    public override void OnNetworkSpawn()
    {
        if (IsServer) { playersName.Value = $"Player {OwnerClientId}"; }
    }
    public void SetOverlay() { 
        var localPlayerOverlay = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        localPlayerOverlay.text = playersName.Value;
    }

    private void Update()
    {
        if (!overlaySet && !string.IsNullOrEmpty(playersName.Value)) { 
            SetOverlay();
            overlaySet = true;
        }
    }
}
