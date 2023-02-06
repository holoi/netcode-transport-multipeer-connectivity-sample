using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Netcode.Transports.MultipeerConnectivity;

public class NearbyHostList : MonoBehaviour
{
    [SerializeField] private NearbyHostSlot _nearbyHostSlotPrefab;

    [SerializeField] private RectTransform _root;

    private MultipeerConnectivityTransport _mpcTransport;

    public List<NearbyHostSlot> NearbyHostSlotList => _nearbyHostSlotList;

    private readonly List<NearbyHostSlot> _nearbyHostSlotList = new();

    private void Start()
    {
        // Get the reference of the MPC transport
        _mpcTransport = MultipeerConnectivityTransport.Instance;

        _mpcTransport.OnBrowserFoundPeer += OnBrowserFoundPeer;
        _mpcTransport.OnBrowserLostPeer += OnBrowserLostPeer;
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        UpdateNearbyHostList();
    }

    private void OnBrowserFoundPeer(int _, string hostName)
    {
        UpdateNearbyHostList();
    }

    private void OnBrowserLostPeer(int _, string hostName)
    {
        UpdateNearbyHostList();
    }

    private void OnClientConnected(ulong _)
    {
        UpdateNearbyHostList();
    }

    private void UpdateNearbyHostList()
    {
        // We destroy and instantiate every connection request slot in every frame.
        // This is wasteful and unnecessary. But it is less error-prone.
        // You can register callbacks instead.
        foreach (var slot in _nearbyHostSlotList)
        {
            Destroy(slot.gameObject);
        }
        _nearbyHostSlotList.Clear();

        foreach (var nearbyHostKey in _mpcTransport.NearbyHostDict.Keys)
        {
            var hostName = _mpcTransport.NearbyHostDict[nearbyHostKey];

            var nearbyHostSlotInstance = Instantiate(_nearbyHostSlotPrefab);
            nearbyHostSlotInstance.Init(nearbyHostKey, hostName);
            nearbyHostSlotInstance.transform.localScale = Vector3.one;
            nearbyHostSlotInstance.transform.SetParent(_root);

            _nearbyHostSlotList.Add(nearbyHostSlotInstance);
        }
    }
}
