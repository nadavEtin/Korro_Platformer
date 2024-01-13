using UnityEngine;

namespace Assets.GameCore.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        public float MoveSpeed, JumpForce, RotationSpeed;
    }
}
