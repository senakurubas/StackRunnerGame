using DG.Tweening;
using UnityEngine;

namespace Core.DoorSystem
{
    public class DoorIdleMovement: MonoBehaviour
    {
        [SerializeField] private float MoveDuration;
        [SerializeField] private float XAxisMove;
        
        
        void Start()
        {
            transform.DOMoveX(XAxisMove, MoveDuration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}