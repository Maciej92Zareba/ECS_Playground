using Unity.Entities;
using UnityEngine;

public class SpeedAuthoring : MonoBehaviour
{
    public float value;
}

public struct Speed : IComponentData
{
    public float value;
}

public class SpeedBaker : Baker<SpeedAuthoring>
{
    public override void Bake (SpeedAuthoring authoring)
    {
        Speed speed = new Speed
        {
            value = authoring.value
        };

        Entity entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, speed);
    }
}
