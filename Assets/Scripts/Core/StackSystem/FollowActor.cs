using UnityEngine;

namespace Core.StackSystem
{
    public class FollowActor : MonoBehaviour
    {
        public Transform Target { get; set; }
        public Vector3 DifferenceFromTarget { get; set; }

        public float SpeedX { get; set; }
        public float SpeedZ { get; set; }

        private void Update()
        {
            FollowMethod();
        }

        private void FollowMethod()
        {
            if (Target != null)
            {
                Vector3 currentPosition = transform.position;
                Vector3 targetPosition = Target.transform.position + DifferenceFromTarget;

                float ZPos = Vector3.MoveTowards(currentPosition, targetPosition, SpeedZ * Time.deltaTime).z;
                float XPos = Vector3.MoveTowards(currentPosition, targetPosition, SpeedX * Time.deltaTime).x;
                float YPos = targetPosition.y;

                this.transform.position = new Vector3(XPos, YPos, ZPos);

            }
        }
    }
}