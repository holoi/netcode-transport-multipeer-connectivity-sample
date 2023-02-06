using System.Collections.Generic;
using UnityEngine;
using Netcode.Transports.MultipeerConnectivity;

public class ConnectionRequestList : MonoBehaviour
{
    [SerializeField] private ConnectionRequestSlot _connectionRequestSlotPrefab;

    [SerializeField] private RectTransform _root;

    private MultipeerConnectivityTransport _mpcTransport;

    public List<ConnectionRequestSlot> ConnectionRequestSlotList => _connectionRequestSlotList;

    private readonly List<ConnectionRequestSlot> _connectionRequestSlotList = new();

    private void Start()
    {
        // Get the reference of the MPC transport
        _mpcTransport = MultipeerConnectivityTransport.Instance;
    }

    private void Update()
    {
        // We destroy and instantiate every connection request slot in every frame.
        // This is wasteful and unnecessary. But it is less error-prone.
        // You can register callbacks instead.
        foreach (var slot in _connectionRequestSlotList)
        {
            Destroy(slot.gameObject);
        }
        _connectionRequestSlotList.Clear();

        foreach (var connectionRequestKey in _mpcTransport.ConnectionRequestDict.Keys)
        {
            var senderName = _mpcTransport.ConnectionRequestDict[connectionRequestKey];

            var connectionRequestSlotInstance = Instantiate(_connectionRequestSlotPrefab);
            connectionRequestSlotInstance.Init(connectionRequestKey, senderName);
            connectionRequestSlotInstance.transform.localScale = Vector3.one;
            connectionRequestSlotInstance.transform.SetParent(_root);

            _connectionRequestSlotList.Add(connectionRequestSlotInstance);
        }
    }
}
