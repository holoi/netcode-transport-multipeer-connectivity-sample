// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
// SPDX-License-Identifier: MIT

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Netcode.Transports.MultipeerConnectivity;

public class HostPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _advertisingStatusText;

    [SerializeField] private Button _startAdvertisingButton;

    [SerializeField] private Button _stopAdvertisingButton;

    private MultipeerConnectivityTransport _mpcTransport;

    private const string ADVERTISING_STATUS_PREFIX = "Advertising Status: ";

    private void Start()
    {
        _mpcTransport = MultipeerConnectivityTransport.Instance;
    }

    private void Update()
    {
        if (_mpcTransport.IsAdvertising)
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
