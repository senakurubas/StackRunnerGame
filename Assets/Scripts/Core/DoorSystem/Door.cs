using UnityEngine;

namespace Core.DoorSystem
{
    public class Door : MonoBehaviour, ISwitchTrigger
    {
        [field: SerializeField] public Color MyColor { get; set; }
    }
}