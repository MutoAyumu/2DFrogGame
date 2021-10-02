using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized] public bool isEnd;
    [SerializeField] UnityEvent m_event = default;
    bool isOn;

    private void Update()
    {
        if(isEnd && !isOn)
        {
            m_event.Invoke();
            isOn = true;
        }
    }
}
