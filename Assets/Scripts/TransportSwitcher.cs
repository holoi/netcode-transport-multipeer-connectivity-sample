using UnityEngine;
using Unity.Netcode;
using Netcode.Transports.MultipeerConnectivity;
using Unity.Netcode.Transports.UTP;

/// <summary>
/// When running in Unity Editor, switch to Unity Transport.
/// When running on iOS, switch to MPCTransport.
/// </summary>
public class TransportSwitcher : MonoBehaviour
{
    private void Start()
    {
        var networkManager = NetworkManager.Singleton;
        var mpcTransport = MultipeerConnectivityTransport.Instance;
        var unityTransport = GetComponent<UnityTransport>();

        if (MultipeerConnectivityTransport.IsRuntime)
        {
            networkManager.NetworkConfig.NetworkTransport = mpcTransport;
        }
        else
        {
            networkManager.NetworkConfig.NetworkTransport = unityTransport;
            Debug.Log("You cannot test MPCTransport in Unity Editor. Now the app is using Unity Transport instead.");
        }
    }
}
