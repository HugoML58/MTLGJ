using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{
    TextMeshProUGUI _textUI;
    string _text;
    float _timePerCharacters;

    float _timer;
    int _characterCount;

    public void AddWriter(TextMeshProUGUI textUI, string text, float timePerCharacters)
    {
        _textUI = textUI;
        _text = text;
        _timePerCharacters = timePerCharacters;
        _characterCount = 0;
    }

    private void Update()
    {
        if (_textUI != null)
        {
            _timer -= Time.deltaTime;
            while (_timer <= 0f)
            {
                _timer += _timePerCharacters;
                _characterCount++;
                _textUI.text = _text.Substring(0, _characterCount);

                if(_characterCount >= _text.Length)
                {
                    _textUI = null;
                    return;
                }
            }
        }
    }
}
