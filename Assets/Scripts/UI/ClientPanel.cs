using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Netcode.Transports.MultipeerConnectivity;

public class ClientPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _browsingStatusText;

    [SerializeField] private Button _startBrowsingButton;

    [SerializeField] private Button _stopBrowsingButton;

    private const string BROWSING_STATUS_PFEFIX = "Browsing Status: ";

    private void Start()
    {
        var mpcTransport = MultipeerConnectivityTransport.Instance;
        if (mpcTransport.IsBrowsing)
        {
            _browsingStatusText.text = BROWSING_STATUS_PFEFIX + "Browsing";
            _startBrowsingButton.interactable = false;
            _stopBrowsingButton.interactable = true;
        }
        else
        {
            _browsingStatusText.text = BROWSING_STATUS_PFEFIX + "Not Browsing";
            _startBrowsingButton.interactable = true;
            _stopBrowsingButton.interactable = false;
        }
    }
}
