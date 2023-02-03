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
