using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField] private GameObject _scrollBar;
    private float _scrollPos = 0;
    private float _distance;
    private float[] _pos;
    [SerializeField] private bool _isSwiping = false;
    [SerializeField] private bool _isStart;

    private void Start()
    {
        GetButtonDistance();
        StartCoroutine(WhenStart());
    }

    private void Update()
    {
        if(_isStart)
            ScaleButton();
        else
            Swiping();
    }

    private void Swiping()
    {
        if (Input.GetMouseButton(0))
        {
            _scrollPos = _scrollBar.GetComponent<Scrollbar>().value;
            _isSwiping = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isSwiping = false;
        }
        else
        {
            ChangeButton();
        }

        if (!_isSwiping) return;
        ScaleButton();
    }

    private void GetButtonDistance()
    {
        _pos = new float[transform.childCount];
        _distance = 1f / (_pos.Length - 1f);
        for (int i = 0; i < _pos.Length; i++)
        {
            _pos[i] = _distance * i;
        }
    }

    private void ChangeButton()
    {
        for (int i = 0; i < _pos.Length; i++)
        {
            if (_scrollPos < _pos[i] + (_distance / 2) && _scrollPos > _pos[i] - (_distance / 2))
            {
                _scrollBar.GetComponent<Scrollbar>().value =
                Mathf.Lerp(_scrollBar.GetComponent<Scrollbar>().value, _pos[i], 0.1f);
            }
        }
    }

    private void ScaleButton()
    {
        for (int i = 0; i < _pos.Length; i++)
        {
            if (_scrollPos < _pos[i] + (_distance / 2) && _scrollPos > _pos[i] - (_distance / 2))
            {
                transform.GetChild(i).localScale =
                Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < _pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale =
                        Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

    private IEnumerator WhenStart()
    {
        _isStart = true;
        yield return new WaitForSeconds(1f);
        _isStart = false;
    }
}
