using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.StackSystem
{
    public class BaseCollectible : MonoBehaviour, ICollectible
    {
        [Title("References")]
        [SerializeField] private Transform transForm;
        [SerializeField] private MeshRenderer collectibleMesh;

        [Title("Scale Settings")]
        [SerializeField] private float doScaleDuration = .5f;

        [Title("Color Settings")]
        [SerializeField] private float switchDuration;

        public Transform TransForm => transForm;

        public void GetCollected()
        {
            collectibleMesh.transform.DOScale(Vector3.one, doScaleDuration).From(Vector3.zero);
        }

        public void SwitchColor(Color color)
        {
            collectibleMesh.material.DOColor(color, switchDuration);
        }
    }
}