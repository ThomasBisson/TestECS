using Unity.Entities;
using UnityEngine;
using Unity.Collections;

public class PlayerJumpSystem : ComponentSystem
{

    [ReadOnly] public float JumpSpeed = 30;

    private struct Filter
    {
        public Rigidbody Rigidbody;
        public InputComponent InputComponent;
    }

    protected override void OnUpdate()
    {
        var deltaTime = Time.deltaTime;

        foreach (var entity in GetEntities<Filter>())
        {
            var jump = new Vector3(0,
                entity.InputComponent.IsJumping ? 10f : 0,
                0);

            entity.Rigidbody.AddForce(jump * JumpSpeed);
        }
    }
}
