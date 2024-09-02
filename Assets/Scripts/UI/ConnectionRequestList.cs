// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
// SPDX-License-Identifier: MIT

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

        _mpcTransport.OnAdvertiserReceivedConnectionRequest += OnAdvertiserReceivedConnectionRequest;
        _mpcTransport.OnAdvertiserApprovedConnectionRequest += OnAdvertiserApprovedConnectionRequest;
        UpdateConnectionRequestList();
    }

    private void OnAdvertiserReceivedConnectionRequest(int _, string senderName)
    {
        UpdateConnectionRequestList();
    }

    private void OnAdvertiserApprovedConnectionRequest(int _)
    {
        UpdateConnectionRequestList();
    }

    private void UpdateConnectionRequestList()
    {
        foreach (var slot in _connectionRequestSlotList)
        {
            Destroy(slot.gameObject);
        }
        _connectionRequestSlotList.Clear();

        foreach (var connectionRequestKey in _mpcTransport.PendingConnectionRequestDict.Keys)
        {
            var senderName = _mpcTransport.PendingConnectionRequestDict[connectionRequestKey];

            var connectionRequestSlotInstance = Instantiate(_connectionRequestSlotPrefab);
            connectionRequestSlotInstance.Init(connectionRequestKey, senderName);
            connectionRequestSlotInstance.transform.SetParent(_root, false);

            _connectionRequestSlotList.Add(connectionRequestSlotInstance);
        }
    }
}
