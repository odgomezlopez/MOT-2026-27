using TMPro;
using UnityEngine;

public class DistanceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;

    private void Start()
    {
        distanceText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceText.text = DistanceManager.Instance.Distance.ToString("F2") + " m";
    }
}
