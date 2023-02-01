using UnityEngine;
using Unity.Netcode;

public class NetworkStateLogger : MonoBehaviour
{
    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"[NetworkStateLogger] OnClientConnected with clientId {clientId}");
    }

    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log($"[NetworkStateLogger] OnClientDisconnected with clientId {clientId}");
    }
}
