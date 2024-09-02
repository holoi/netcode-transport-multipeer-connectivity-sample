// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
// SPDX-License-Identifier: MIT

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
