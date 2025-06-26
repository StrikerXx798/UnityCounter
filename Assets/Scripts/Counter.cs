using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private bool _isActive;
    private IEnumerator _coroutine;
    public const int StartCount = 0;
    
    private int _count;
    public event Action<int> CountChanged;

    private void Start()
    {
        _coroutine = CountCoroutine();
        _isActive = false;
        _count = StartCount;
    }

    private IEnumerator CountCoroutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _count++;
            CountChanged?.Invoke(_count);
            yield return wait;
        }
    }

    private void OnMouseDown()
    {
        if (_coroutine == null)
            return;
        
        if (_isActive == false)
            StartCoroutine(_coroutine);
        else
            StopCoroutine(_coroutine);

        _isActive = !_isActive;
    }
}
