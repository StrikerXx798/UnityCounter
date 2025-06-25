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

    private void Update()
    {
        
    }

    private void ChangeText()
    {
        _text.text = _counter.Count.ToString("");
    }
}
