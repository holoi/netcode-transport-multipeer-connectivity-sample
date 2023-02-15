// SPDX-FileCopyrightText: Copyright 2023 Holo Interactive <dev@holoi.com>
//
// SPDX-FileContributor: Yuchen Zhang <yuchen@holoi.com>
//
// SPDX-License-Identifier: MIT

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using Netcode.Transports.MultipeerConnectivity;

public class ClientPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _browsingStatusText;

    [SerializeField] private Button _startBrowsingButton;

    [SerializeField] private Button _stopBrowsingButton;

    private MultipeerConnectivityTransport _mpcTransport;

    private const string BROWSING_STATUS_PFEFIX = "Browsing Status: ";

    private void Start()
    {
        _mpcTransport = MultipeerConnectivityTransport.Instance;
    }

    private void Update()
    {
        // The client can no longer browse after connected to the network
        if (NetworkManager.Singleton.IsConnectedClient)
        {
            _browsingStatusText.text = BROWSING_STATUS_PFEFIX + "Not Browsing";
            _startBrowsingButton.interactable = false;
            _stopBrowsingButton.interactable = false;
            return;
        }

        if (_mpcTransport.IsBrowsing)
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
