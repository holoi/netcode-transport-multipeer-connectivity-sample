// SPDX-FileCopyrightText: Copyright 2023 Holo Interactive <dev@holoi.com>
//
// SPDX-FileContributor: Yuchen Zhang <yuchen@holoi.com>
//
// SPDX-License-Identifier: MIT

using UnityEngine;
using Unity.Netcode;

public class SimpleMessager : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        Debug.Log("[SimpleMessager] OnNetworkSpawn");
    }

    private void Update()
    {
        if (IsSpawned && IsServer)
        {
            HowAreYouClientRpc();
        }
    }

    [ClientRpc]
    private void HowAreYouClientRpc()
    {
        if (!IsServer)
        {
            Debug.Log($"[SimpleMessager] How are you? {Time.time}");
            IAmFineThankYouServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void IAmFineThankYouServerRpc(ServerRpcParams serverRpcParams = default)
    {
        Debug.Log($"[SimpleMessager] I am fine thank you! from clientId {serverRpcParams.Receive.SenderClientId} {Time.time}");
    } 
}
