// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
// SPDX-License-Identifier: MIT

using UnityEngine;
using Unity.Netcode;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;

    [SerializeField] private GameObject _hostPanel;

    [SerializeField] private GameObject _clientPanel;

    private void Start()
    {
        UpdateCurrentPanel();
    }

    private void Update()
    {
        UpdateCurrentPanel();
    }

    private void UpdateCurrentPanel()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            _startPanel.SetActive(false);
            _hostPanel.SetActive(true);
            _clientPanel.SetActive(false);
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            _startPanel.SetActive(false);
            _hostPanel.SetActive(false);
            _clientPanel.SetActive(true);
        }
        else
        {
            _startPanel.SetActive(true);
            _hostPanel.SetActive(false);
            _clientPanel.SetActive(false);
        }
    }
}
