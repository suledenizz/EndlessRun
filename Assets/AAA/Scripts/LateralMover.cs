using System;
using System.Collections;
using System.Collections.Generic;
using Sule.BoatStack.InputManagement;
using UnityEngine;

public class LateralMover : MonoBehaviour
{
    [SerializeField] private float extraSideBufferWidth;
    [SerializeField] private float ballHalfWidth;
    [SerializeField] private float platformHalfWidth;
    [SerializeField] private Transform lateralMover;

    public static LateralMover instance;

    private void Start()
    {
        instance = this;
    }

    private float MaxMovementLimit => platformHalfWidth - ballHalfWidth - extraSideBufferWidth;

    void Update()
    {
        var swipeDeltaX01 = InputController.Instance.SwipeDelta01.x;
        var currentLateralX = lateralMover.transform.localPosition.x;
        var newLateralX = currentLateralX + swipeDeltaX01 * MaxMovementLimit;
        var clampedNewLateralX = Mathf.Clamp(newLateralX, -MaxMovementLimit, MaxMovementLimit);
        transform.localPosition = new Vector3(clampedNewLateralX, 0, 0);
    }
}
