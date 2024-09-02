// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
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
