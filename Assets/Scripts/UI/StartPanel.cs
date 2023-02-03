using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netcode.Transports.MultipeerConnectivity;

public class StartPanel : MonoBehaviour
{
    public void OnNicknameChanged(string nickname)
    {
        Debug.Log($"[StartPanel] OnNicknameChanged {nickname}");

        MultipeerConnectivityTransport.Instance.Nickname = nickname;
    }
}
