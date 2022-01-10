using UnityEngine;

public readonly struct SplineMeshBetterSample
{
	/// The original sample.
	public readonly SplineMesh.CurveSample CurveSample;

	/// The sample's location in world space.
	/// CurveSample.location is in local space.
	public readonly Vector3 WorldLocation;

	/// The sample's rotation in world space.
	/// CurveSample.Rotation is in local space.
	public readonly Quaternion WorldRotation;

	/// The distance in the whole spline. Range: [0, spline length].
	/// CurveSample.distanceInCurve is in curve space.
	public readonly float DistanceInSpline;

	/// The time in the whole spline. Range: [0, node count - 1].
	/// CurveSample.timeInCurve is in curve space.
	public readonly float TimeInSpline;

	public SplineMeshBetterSample(SplineMesh.CurveSample curveSample, Vector3 worldLocation, Quaternion worldRotation, float distanceInSpline, float timeInSpline)
	{
		CurveSample = curveSample;
		DistanceInSpline = distanceInSpline;
		TimeInSpline = timeInSpline;
		WorldLocation = worldLocation;
		WorldRotation = worldRotation;
	}
}