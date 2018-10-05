using Unity.Entities;
using UnityEngine;
using Unity.Collections;

public class PlayerMovementSystem : ComponentSystem {

    [ReadOnly] public float WalkSpeed = 3;

    private struct Filter
    {
        public Rigidbody Rigidbody;
        public InputComponent InputComponent;
    }

    protected override void OnUpdate()
    {
        var deltaTime = Time.deltaTime;

        foreach(var entity in GetEntities<Filter>())
        {
            var moveVector = new Vector3(entity.InputComponent.Horizontal,
                0,
                entity.InputComponent.Vertical);
            var movePosition = entity.Rigidbody.position + moveVector.normalized * WalkSpeed * deltaTime;

            entity.Rigidbody.MovePosition(movePosition);
        }
    }
}
