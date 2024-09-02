// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
// SPDX-License-Identifier: MIT

using UnityEngine;
using Unity.Netcode;

public class RttCounter : NetworkBehaviour
{
    public float Rtt => _rtt;

    private float _rtt = 0f;

    private void Update()
    {
        if (IsSpawned && !IsServer)
        {
            RequestRttServerRpc(Time.time);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void RequestRttServerRpc(float clientTimestamp, ServerRpcParams serverRpcParams = default)
    {
        // NOTE! In case you know a list of ClientId's ahead of time, that does not need change,
        // Then please consider caching this (as a member variable), to avoid Allocating Memory every time you run this function
        ClientRpcParams clientRpcParams = new ClientRpcParams
        {
            Send = new ClientRpcSendParams
            {
                TargetClientIds = new ulong[] { serverRpcParams.Receive.SenderClientId }
            }
        };
        RespondRttClientRpc(clientTimestamp, clientRpcParams);
    }

    [ClientRpc]
    private void RespondRttClientRpc(float clientTimestamp, ClientRpcParams _ = default)
    {
        _rtt = (Time.time - clientTimestamp) * 1000f;
    }
}
