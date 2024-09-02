// SPDX-FileCopyrightText: Copyright 2024 Reality Design Lab <dev@reality.design>
// SPDX-FileContributor: Yuchen Zhang <yuchenz27@outlook.com>
// SPDX-FileContributor: Botao Amber Hu <botao@reality.design>
// SPDX-License-Identifier: MIT

using UnityEngine;
using TMPro;

public class RttDisplay : MonoBehaviour
{
    [SerializeField] private RttCounter _rttCounter;

    private TMP_Text _rttText;

    private void Start()
    {
        _rttText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _rttText.text = $"{_rttCounter.Rtt:F4} ms";
    }
}
