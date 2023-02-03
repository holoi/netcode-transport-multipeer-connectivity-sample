using UnityEngine;
using Unity.Netcode;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;

    [SerializeField] private GameObject _hostPanel;

    [SerializeField] private GameObject _clientPanel;

    private void Update()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            _startPanel.SetActive(false);
            _hostPanel.SetActive(true);
            _clientPanel.SetActive(false);
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            _startPanel.SetActive(false);
            _hostPanel.SetActive(false);
            _clientPanel.SetActive(true);
        }
        else
        {
            _startPanel.SetActive(true);
            _hostPanel.SetActive(false);
            _clientPanel.SetActive(false);
        }
    }
}
