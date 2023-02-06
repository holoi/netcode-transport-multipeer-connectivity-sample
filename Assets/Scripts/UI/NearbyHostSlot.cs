using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Netcode.Transports.MultipeerConnectivity;

public class NearbyHostSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text _nickname;

    [SerializeField] private Button _joinButton;

    public void Init(int nearbyHostKey, string nickname)
    {
        _nickname.text = nickname;
        _joinButton.onClick.AddListener(() =>
        {
            MultipeerConnectivityTransport.Instance.SendConnectionRequest(nearbyHostKey);
        });
    }
}
