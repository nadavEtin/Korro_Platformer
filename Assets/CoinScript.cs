using Assets.Scripts.Utility;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CoinScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        EventBus.Publish(GameplayEvent.CoinPickUp, BaseEventParams.Empty);
    }
}
