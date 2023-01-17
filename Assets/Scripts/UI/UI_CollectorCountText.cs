using TMPro;
using UnityEngine;

namespace UI
{
    public class UI_CollectorCountText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmp;

        public void SetCollectedText(int newCollectedCount)
        {
            tmp.text = newCollectedCount.ToString();
        }
    }
}