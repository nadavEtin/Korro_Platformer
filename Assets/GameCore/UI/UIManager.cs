using Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.GameCore.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI CoinsDisplay;

        private int _coinsCount = 0;

        private void Awake()
        {
            EventBus.Subscribe(GameplayEvent.CoinPickUp, CoinPickUp);
        }

        private void CoinPickUp(BaseEventParams eventParams)
        {
            _coinsCount++;
            CoinsDisplay.text = _coinsCount.ToString();
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe(GameplayEvent.CoinPickUp, CoinPickUp);
        }
    }
}
