// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
// SPDX-License-Identifier: MIT

using System;
using Unity.Netcode;
using Unity.Collections;
using Netcode.Transports.MultipeerConnectivity;
using System.Diagnostics;

public class Player : NetworkBehaviour
{
    public NetworkVariable<FixedString64Bytes> Nickname = new("my-name", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    public static event Action<Player> OnPlayerSpawned;

    public static event Action<Player> OnPlayerDespawned;

    public static event Action<Player> OnPlayerNicknameChanged;


    private void OnEnable()
    {
        Nickname.OnValueChanged += OnNicknameChanged;
    }

    private void OnDisable()
    {
        Nickname.OnValueChanged -= OnNicknameChanged;
    }

    public void OnNicknameChanged(FixedString64Bytes oldValue, FixedString64Bytes newValue)
    {
        OnPlayerNicknameChanged?.Invoke(this);
    }

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
