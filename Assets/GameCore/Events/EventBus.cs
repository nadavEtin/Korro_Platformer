using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utility
{
    public enum GameplayEvent
    {
        GameStart, GameEnd, Error, CoinPickUp, KeyPickUp, DoorReached
    }

    public static class EventBus
    {
        private static readonly Dictionary<GameplayEvent, List<Action<BaseEventParams>>> _subscription = new();

        public static void Subscribe(GameplayEvent eventType, Action<BaseEventParams> handler)
        {
            if (_subscription.ContainsKey(eventType) == false)
                _subscription.Add(eventType, new List<Action<BaseEventParams>>());

            var handlerList = _subscription[eventType];
            if (handlerList.Contains(handler) == false)
                handlerList.Add(handler);
        }

        public static void Unsubscribe(GameplayEvent eventType, Action<BaseEventParams> handler)
        {
            if (_subscription.ContainsKey(eventType))
                _subscription[eventType]?.Remove(handler);
        }

        public static void Publish(GameplayEvent eventType, BaseEventParams eventParams)
        {
            if (_subscription.ContainsKey(eventType) == false)
                return;

            var handlerList = _subscription[eventType];
            foreach (var handler in handlerList)
                handler?.Invoke(eventParams);
        }
    }
}
