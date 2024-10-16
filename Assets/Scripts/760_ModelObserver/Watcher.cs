using System;
using System.Collections.Generic;


public class Watcher<T>
{
    private T _value;
    private event Action<T> _onValueChanged;

    public T Value
    {
        get => _value;
        set
        {
            if (!EqualityComparer<T>.Default.Equals(_value, value))
            {
                _value = value;
                _onValueChanged?.Invoke(_value);
            }
        }
    }

    public void Subscribe(Action<T> callback)
    {
        _onValueChanged += callback;
    }

    public void Unsubscribe(Action<T> callback)
    {
        _onValueChanged -= callback;
    }
}
