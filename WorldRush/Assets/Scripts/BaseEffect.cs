using UnityEngine;

public abstract class BaseEffect : ScriptableObject
{
    public string Name;

    public GameObject Prefab;
    public abstract void ApplyEffect(BaseEntity TargetGameObject);
}
