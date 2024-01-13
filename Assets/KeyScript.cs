using Assets.Scripts.Utility;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        EventBus.Publish(GameplayEvent.KeyPickUp, BaseEventParams.Empty);
        transform.parent.gameObject.SetActive(false);
    }
}
