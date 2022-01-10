using UnityEngine;

public static class SplineMeshSamplingUtilities 
{
	public static SplineMeshBetterSample BetterSampleAtDistance(this SplineMesh.Spline spline, float d)
	{
		var curveSample = spline.GetSampleAtDistance(d);
		return ConstructBetterSample(spline, curveSample);
	}

	public static SplineMeshBetterSample BetterProject(this SplineMesh.Spline spline, Vector3 worldPos)
	{
		var localPos = spline.transform.InverseTransformPoint(worldPos);
		var curveSample = spline.GetProjectionSample(localPos);
		return ConstructBetterSample(spline, curveSample);
	}

	/// <summary>
	/// For SplineMesh. Returns the distance and time offsets of the <paramref name="curve"/> along the
	/// <paramref name="spline"/>. Offsets are for the beginning of the <paramref name="curve"/>.
	/// </summary>
	public static (float distanceOffset, float timeOffset) GetCurveOffsets(this SplineMesh.Spline spline, SplineMesh.CubicBezierCurve curve)
	{
		var curveDistOffset = 0f;
		var curveTimeOffset = 0f;

		var closestCurveIndex = spline.curves.IndexOf(curve);
		for (var i = 0; i < closestCurveIndex; i++)
		{
			var curveIt = spline.curves[i];
			curveDistOffset += curveIt.Length;
			curveTimeOffset += 1;
		}

		return (curveDistOffset, curveTimeOffset);
	}

	private static SplineMeshBetterSample ConstructBetterSample(SplineMesh.Spline spline, SplineMesh.CurveSample curveSample)
	{
		var transform = spline.transform;
		var transformRotation = transform.rotation;
		var worldLocation = transform.TransformPoint(curveSample.location);
		var worldRotation = transformRotation * curveSample.Rotation;

		var offsets = GetCurveOffsets(spline, curveSample.curve);
		var distanceInSpline = offsets.distanceOffset + curveSample.distanceInCurve;
		var timeInSpline = offsets.timeOffset + curveSample.timeInCurve;

		return new SplineMeshBetterSample(curveSample, worldLocation, worldRotation, distanceInSpline, timeInSpline);
	}
}