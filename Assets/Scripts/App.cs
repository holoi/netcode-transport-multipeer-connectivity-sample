using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Netcode.Transports.MultipeerConnectivity;

public class App : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;

    public Dictionary<ulong, Player> PlayerDict => _playerDict;

    private readonly Dictionary<ulong, Player> _playerDict = new();

    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
        Player.OnPlayerSpawned += OnPlayerSpawned;
        Player.OnPlayerDespawned += OnPlayerDespawned;
    }

    private void OnDestroy()
    {
        // Static events must be unregistered, otherwise the app will crash
        Player.OnPlayerSpawned -= OnPlayerSpawned;
        Player.OnPlayerDespawned -= OnPlayerDespawned;
    }

    private void OnClientConnected(ulong clientId)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            SpawnPlayer(clientId);
        }
    }

    private void OnClientDisconnected(ulong clientId)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            if (_playerDict.ContainsKey(clientId))
            {
                var player = _playerDict[clientId];
                if (player != null)
                {
                    Destroy(_playerDict[clientId].gameObject);
                }
            }
        }
    }

    private void SpawnPlayer(ulong clientId)
    {
        var playerInstance = Instantiate(_playerPrefab);
        playerInstance.GetComponent<NetworkObject>().SpawnWithOwnership(clientId);
    }

    private void OnPlayerSpawned(Player player)
    {
        _playerDict.Add(player.OwnerClientId, player);
    }

    private void OnPlayerDespawned(Player player)
    {
        if (_playerDict.ContainsKey(player.OwnerClientId))
        {
            _playerDict.Remove(player.OwnerClientId);
        }
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void StartAdvertising()
    {
        MultipeerConnectivityTransport.Instance.StartAdvertising();
    }

    public void StopAdvertising()
    {
        MultipeerConnectivityTransport.Instance.StopAdvertising();
    }

    public void StartBrowsing()
    {
        MultipeerConnectivityTransport.Instance.StartBrowsing();
    }

    public void StopBrowsing()
    {
        MultipeerConnectivityTransport.Instance.StopBrowsing();
    }

    public void Shutdown()
    {
        NetworkManager.Singleton.Shutdown();
    }
}
