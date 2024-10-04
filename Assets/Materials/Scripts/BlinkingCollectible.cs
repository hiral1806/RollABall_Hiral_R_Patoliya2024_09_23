using System;
using System.Collections;
using UnityEngine;

public class BlinkingCollectible : MonoBehaviour


{

    public float blinkDuration = 1.0f;
    public int blinkCount = 5;

    private Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer == null)
        {
            Debug.LogError("Renderer not found on this GameObject.");
            return;
        }
        StartIEnumerable(Blink());
        
    }

    private void StartIEnumerable(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    private IEnumerable Blink()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            _renderer.enabled = false;
            yield return new WaitForSeconds(blinkDuration / 2);
            _renderer.enabled = true;
            yield return new WaitForSeconds(blinkDuration / 2);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    void Update()
    {
        
    }
}
