using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{
    [SerializeField] float showTextForSeconds;
    TextMeshProUGUI _textUI;
    string _text;
    float _timePerCharacters;

    float _timer;
    float _secondTimer;
    int _characterCount;
    bool _hasCompleted;

    private void Start()
    {
        _secondTimer = showTextForSeconds;
    }

    public void AddWriter(TextMeshProUGUI textUI, string text, float timePerCharacters)
    {
        _textUI = textUI;
        _text = text;
        _timePerCharacters = timePerCharacters;
        _characterCount = 0;
    }

    private void Update()
    {
        if (_textUI != null && !_hasCompleted)
        {
            _timer -= Time.deltaTime;
            while (_timer <= 0f)
            {
                _timer += _timePerCharacters;
                _characterCount++;
                _textUI.text = _text.Substring(0, _characterCount);

                if(_characterCount >= _text.Length)
                {
                    _hasCompleted = true;
                    return;
                }
            }
        }
        
        if(_hasCompleted)
        {
            _secondTimer -= Time.deltaTime;
            if (_secondTimer <= 0f)
            {
                _hasCompleted = false;
                _secondTimer = showTextForSeconds;
                _textUI.text = "";
                _textUI = null;
                return;
            }
        }
    }
}
