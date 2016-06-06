using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


public interface IUsable : IEntity
{
    void Use();
}

public interface IDamageable : IEntity
{
    void Damage(float amount);
}

public interface IKillable : IEntity
{
    void Die();
}

public interface IHealable : IEntity
{
    void Heal(float amount);
}

public interface IEntity
{
    GameObject gameObject { get; }
    Transform transform { get; }
}

public static class GameObjectExtension
{
    public static T CopyComponent<T>(this GameObject gameObject, T original) where T : Component
    {
        System.Type type = original.GetType();
        var dst = gameObject.AddComponent(type) as T;
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            if (field.IsStatic) continue;
            field.SetValue(dst, field.GetValue(original));
        }
        var props = type.GetProperties();
        foreach (var prop in props)
        {
            if (!prop.CanWrite || !prop.CanWrite || prop.Name == "name") continue;
            prop.SetValue(dst, prop.GetValue(original, null), null);
        }
        return dst;
    }
}