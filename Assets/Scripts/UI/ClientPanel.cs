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
        if (mpcTransport.AutoBrowse)
        {
            _browsingStatusText.text = BROWSING_STATUS_PFEFIX + "Auto Browsing";
            _startBrowsingButton.interactable = false;
            _stopBrowsingButton.interactable = false;
        }
        else
        {
            _startBrowsingButton.interactable = true;
            _stopBrowsingButton.interactable = true;
            if (mpcTransport.IsBrowsing)
            {
                _browsingStatusText.text = BROWSING_STATUS_PFEFIX + "Browsing";
            }
            else
            {
                _browsingStatusText.text = BROWSING_STATUS_PFEFIX + "Not Browsing";
            }
        }
    }
}
