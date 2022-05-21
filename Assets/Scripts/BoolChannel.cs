using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/BoolChannel")]
public class BoolChannel : ScriptableObject
{
    private event Action<bool> OnInvoke;
    public void AddListener(Action<bool> action)
    {
        OnInvoke += action;
    }
    public void RemoveListener(Action<bool> action)
    {
        OnInvoke -= action;
    }
    public void BoolInvoke(bool state)
    {
        OnInvoke?.Invoke(state);
    }
}