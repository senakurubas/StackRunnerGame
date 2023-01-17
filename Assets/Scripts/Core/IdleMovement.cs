using DG.Tweening;
using UnityEngine;


namespace Core
{
    public class IdleMovement : MonoBehaviour
    {
        [SerializeField] private float MoveDuration;
        [SerializeField] private float YAxisMove;
        
        
        void Start()
        {
            transform.DOMoveY(YAxisMove, MoveDuration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}

