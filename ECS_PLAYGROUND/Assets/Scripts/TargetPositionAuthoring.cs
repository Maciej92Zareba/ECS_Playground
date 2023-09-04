using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TargetPositionAuthoring : MonoBehaviour
{
	public float3 value;
}

public struct TargetPosition : IComponentData
{
	public float3 value;
}

public class TargetPositionBaker : Baker<TargetPositionAuthoring>
{
	public override void Bake (TargetPositionAuthoring authoring)
	{
		TargetPosition targetPosition = new TargetPosition
		{
			value = authoring.value
		};
		
		Entity entity = GetEntity(TransformUsageFlags.Dynamic);
		AddComponent(entity, targetPosition);
	}
}
