using GameCore.ScriptableObjects;
using UnityEngine;

namespace GameCore.UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private AssetRefs _assetRefs;
        
        private void Construct(AssetRefs assetRefs)
        {
            _assetRefs = assetRefs;
        }
    }
}
