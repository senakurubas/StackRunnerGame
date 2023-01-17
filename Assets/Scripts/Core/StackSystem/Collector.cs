using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Core.AudioSystem;
using Core.DoorSystem;
using DG.Tweening;
using Sirenix.OdinInspector;
using Twenty.SOGameEvents;
using UnityEngine;

namespace Core.StackSystem
{
    public class Collector : MonoBehaviour
    {
        [Title("References")]
        [SerializeField] private SkinnedMeshRenderer playerRenderer;
        
        [Title("Collect Move Settings")]
        [SerializeField] private Vector3 firstCollectiblePosition;
        [SerializeField] private float speedX;
        [SerializeField] private float speedZ;
        [SerializeField] private float countDecreaseAmount = 5;

        [Title("Color Switch Settings")]
        [SerializeField] private float timeBetweenColorSwitches;

        [Title("Collected Event")]
        [SerializeField] private IntGameEvent eventToBroadcast;

        private List<ICollectible> collectibleList = new();

        private int count;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IdleMovement idleMovement))
            {
                idleMovement.transform.DOKill();
                Destroy(idleMovement);
            }
            
            if (other.TryGetComponent(out ICollectible collectible))
            {
                collectible.GetCollected();
                AddToStack(collectible);
                eventToBroadcast.Raise(count);
                FindObjectOfType<AudioManager>().Play("Collect");
            }

            if (other.TryGetComponent(out ISwitchTrigger switchTrigger))
            {
                FindObjectOfType<AudioManager>().Play("Door");
                StartCoroutine(SwitchColors(switchTrigger.MyColor));
                ChangePlayerClothColor(switchTrigger.MyColor);
                ScaleEffect();
                
            }

            
        }

        public IEnumerator LevelEndOrder(Vector3 triggerPosition)
        {
            int levelEndCounter = 0;

            foreach (ICollectible collectible in collectibleList)
            {
                if (collectible.TransForm.TryGetComponent(out FollowActor followActor))
                {
                    Destroy(followActor);
                }

                collectible.TransForm.DOMove(triggerPosition + Vector3.up * levelEndCounter, .5f);
                levelEndCounter++;
                yield return new WaitForSeconds(.5f);

            }
        }

        private void AddToStack(ICollectible collectibleToAdd)  
        {
            // check if collectible already has "Follow Actor" script
            FollowActor _actor;

            if (collectibleToAdd.TransForm.TryGetComponent(out FollowActor actor))
            {
                _actor = actor;
            }
            else
            {
                _actor = collectibleToAdd.TransForm.gameObject.AddComponent<FollowActor>();
            }

            if (collectibleList.Any())
            {
                _actor.Target = collectibleList[^1].TransForm;
                _actor.DifferenceFromTarget = new Vector3(0, _actor.Target.localScale.y, 0);
            }
            else
            {
                // list is empty
                _actor.Target = this.transform;
                _actor.DifferenceFromTarget = firstCollectiblePosition;
            }

            _actor.SpeedX = speedX - (count/2f * countDecreaseAmount);
            _actor.SpeedZ = speedZ;

            // adding to array
            collectibleList.Add(collectibleToAdd);
            
            // increasing count
            count++;
        }
        
        private void RemoveFromStack()
        {
            ICollectible collectibleToDrop = collectibleList[^1]; 
            collectibleList.Remove(collectibleToDrop);
            
            collectibleToDrop.TransForm.SetParent(null);

            count--;
        }

        private IEnumerator SwitchColors(Color newColor)
        {
            List<ICollectible> copyList = new List<ICollectible>(collectibleList);
            
            foreach (ICollectible collectible in copyList)
            {
                collectible.SwitchColor(newColor);
                yield return new WaitForSeconds(timeBetweenColorSwitches);
            }
        }

        private void ChangePlayerClothColor(Color newColor)
        {
            playerRenderer.materials[0].DOColor(newColor, .5f);
        }

        private void ScaleEffect()
        {
            transform.DOScale(Vector3.one * 1.1f, .1f).SetLoops(2, LoopType.Yoyo);
        }
    }
}