using TMPro;
using UnityEngine;

public class DiscanceRecordUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;

    private void Start()
    {
        string key = "Distance";

        distanceText = GetComponent<TextMeshProUGUI>();
        distanceText.text = PlayerPrefs.GetFloat(key, 0f).ToString("F2") + " m";
    }
}
