using TMPro;
using UnityEngine;

public class CountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = Counter.StartCount.ToString("");
    }

    void OnEnable()
    {
        _counter.CountChanged += ChangeText;
    }

    void OnDisable()
    {
        _counter.CountChanged -= ChangeText;
    }

    private void ChangeText(int count)
    {
        _text.text = count.ToString("");
    }
}
