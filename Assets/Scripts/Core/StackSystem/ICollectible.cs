using UnityEngine;

namespace Core.StackSystem
{
    public interface ICollectible
    {
        public Transform TransForm { get; }
        void GetCollected();
        void SwitchColor(Color color);
    }
}