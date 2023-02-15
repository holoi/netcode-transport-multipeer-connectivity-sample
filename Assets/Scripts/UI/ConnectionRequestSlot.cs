// SPDX-FileCopyrightText: Copyright 2023 Holo Interactive <dev@holoi.com>
//
// SPDX-FileContributor: Yuchen Zhang <yuchen@holoi.com>
//
// SPDX-License-Identifier: MIT

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Netcode.Transports.MultipeerConnectivity;

public class ConnectionRequestSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text _nickname;

    [SerializeField] private Button _approveButton;

    public void Init(int connectionRequestKey, string nickname)
    {
        _nickname.text = nickname;
        _approveButton.onClick.AddListener(() =>
        {
            MultipeerConnectivityTransport.Instance.ApproveConnectionRequest(connectionRequestKey);
        });
    }
}
