// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
// SPDX-License-Identifier: MIT

using UnityEngine;
using Netcode.Transports.MultipeerConnectivity;

public class StartPanel : MonoBehaviour
{
    public void OnNicknameChanged(string nickname)
    {
        MultipeerConnectivityTransport.Instance.Nickname = nickname;

        Debug.Log($"Nickname changed to {nickname}");
    }

    public void OnAutoAdvertiseToggled(bool value)
    {
        MultipeerConnectivityTransport.Instance.AutoAdvertise = value;

        Debug.Log($"AutoAdvertise changed to {value}");
    }

    public void OnAutoApproveConnectionRequestToggled(bool value)
    {
        MultipeerConnectivityTransport.Instance.AutoApproveConnectionRequest = value;

        Debug.Log($"AutoApproveConnectionRequest changed to {value}");
    }

    public void OnAutoBrowseToggled(bool value)
    {
        MultipeerConnectivityTransport.Instance.AutoBrowse = value;

        Debug.Log($"AutoBrowse changed to {value}");
    }

    public void OnAutoSendConnectionRequestToggled(bool value)
    {
        MultipeerConnectivityTransport.Instance.AutoSendConnectionRequest = value;

        Debug.Log($"AutoSendConnectionRequest changed to {value}");
    }
}
