using UnityEngine;
using Unity.Netcode;

public class App : MonoBehaviour
{
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void Shutdown()
    {
        NetworkManager.Singleton.Shutdown();
    }
}
