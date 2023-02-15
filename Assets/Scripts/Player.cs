// SPDX-FileCopyrightText: Copyright 2023 Holo Interactive <dev@holoi.com>
//
// SPDX-FileContributor: Yuchen Zhang <yuchen@holoi.com>
//
// SPDX-License-Identifier: MIT

using System;
using UnityEngine;
using Unity.Netcode;
using Unity.Collections;
using Netcode.Transports.MultipeerConnectivity;

public class Player : NetworkBehaviour
{
    public NetworkVariable<FixedString64Bytes> Nickname = new("yuchen", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public static event Action<Player> OnPlayerSpawned;

    public static event Action<Player> OnPlayerDespawned;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            Nickname.Value = MultipeerConnectivityTransport.Instance.Nickname;
        }

        OnPlayerSpawned?.Invoke(this);
    }

    public override void OnNetworkDespawn()
    {
        OnPlayerDespawned?.Invoke(this);
    }
}
