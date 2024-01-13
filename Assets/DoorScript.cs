using Assets.Scripts.Utility;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DoorScript : MonoBehaviour
{
    private bool _playerHasKey = false;

    private void Start()
    {
        EventBus.Subscribe(GameplayEvent.KeyPickUp, KeyPickedUp);
    }

    private void KeyPickedUp(BaseEventParams eventParams)
    {
        _playerHasKey = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_playerHasKey)
            EventBus.Publish(GameplayEvent.DoorReached, BaseEventParams.Empty);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(GameplayEvent.KeyPickUp, KeyPickedUp);
    }
}
