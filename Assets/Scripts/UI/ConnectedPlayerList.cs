using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConnectedPlayerList : MonoBehaviour
{
    [SerializeField] private GameObject _playerSlotPrefab;

    [SerializeField] private RectTransform _root;

    private App _app;

    private readonly List<GameObject> _playerSlotList = new();

    private void Start()
    {
        _app = FindObjectOfType<App>();
    }

    private void Update()
    {
        foreach (var playerSlot in _playerSlotList)
        {
            Destroy(playerSlot);
        }
        _playerSlotList.Clear();

        foreach (var player in _app.PlayerDict.Values)
        {
            var playerSlotInstance = Instantiate(_playerSlotPrefab);
            playerSlotInstance.GetComponentInChildren<TMP_Text>().text = player.Nickname.Value.ToString();
            playerSlotInstance.transform.SetParent(_root);
        }
    }
}
