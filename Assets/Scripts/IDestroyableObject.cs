using System;

public interface IDestroyableObject<T> where T : IDestroyableObject<T>
{
    public event Action<T> Destroyed;
}