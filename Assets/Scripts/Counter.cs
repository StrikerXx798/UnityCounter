using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    const float Delay = 0.5f;
    const string StartButtonText = "Start";
    const string PauseButtonText = "Pause";
    
    [SerializeField] private TextMeshProUGUI _buttonText;

    private bool _isActive;
    public static int StartCount
    {
        get { return 0; }
    }
    public int Count { get; private set; }
    
    public event Action CountChanged;

    private void Start()
    {
        _isActive = false;
        Count = StartCount;
        _buttonText.text = StartButtonText;
    }

    private IEnumerator CountCoroutine()
    {
        const bool isRunning = true;

        while (isRunning)
        {
            var wait = new WaitForSeconds(Delay);
            Count++;
            CountChanged?.Invoke();
            yield return wait;
            
        }
    }

    public void OnButtonClick()
    {
        if (_isActive == false)
        {
            _buttonText.text = PauseButtonText;
            StartCoroutine(CountCoroutine());
        }
        else
        {
            _buttonText.text = StartButtonText;
            StopAllCoroutines();
        }
        
        _isActive = !_isActive;
    }
}
