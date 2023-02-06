using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Netcode.Transports.MultipeerConnectivity;

public class HostPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _advertisingStatusText;

    [SerializeField] private Button _startAdvertisingButton;

    [SerializeField] private Button _stopAdvertisingButton;

    private const string ADVERTISING_STATUS_PREFIX = "Advertising Status: ";

    private void Update()
    {
        var mpcTransport = MultipeerConnectivityTransport.Instance;

        if (mpcTransport.IsAdvertising)
        {
            _advertisingStatusText.text = ADVERTISING_STATUS_PREFIX + "Advertising";
            _startAdvertisingButton.interactable = false;
            _stopAdvertisingButton.interactable = true;
        }
        else
        {
            _advertisingStatusText.text = ADVERTISING_STATUS_PREFIX + "Not Advertising";
            _startAdvertisingButton.interactable = true;
            _stopAdvertisingButton.interactable = false;
        }
    }
}
