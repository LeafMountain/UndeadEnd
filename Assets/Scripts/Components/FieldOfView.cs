using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

	public Transform origin;

	[Range(0, 30)]
	public float radius = 10;
	[Range(0, 360)]
	public float viewAngle = 90;

	public LayerMask obstacleMask;
	public LayerMask targetMask;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	public float scanFrequency = .5f;
	
	public float fovResolution = 4;
	public int edgeDetectionAccuracy = 5;
	public float edgeDistanceThreshold;


	public MeshFilter viewMeshFilter;
	Mesh viewMesh;

	void Start(){
		if(!origin){
			origin = transform;
		}
		
		viewMesh = new Mesh();
		viewMesh.name = "View mesh";
		viewMeshFilter.sharedMesh = viewMesh;

		StartCoroutine("FindTargetsWithDelay", scanFrequency);
	}

	void LateUpdate(){
		DrawFieldOfView();
	}

	IEnumerator FindTargetsWithDelay(float delay){
		while(true){
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}
	}

	void FindVisibleTargets(){
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(origin.position, radius, targetMask);

		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			Transform target = targetsInViewRadius [i].transform;
			Vector3 dirToTarget = (target.position - origin.position).normalized;

			if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2){
				float dstToTarget = Vector3.Distance(origin.position, target.position);

				if(!Physics.Raycast(origin.position, dirToTarget, dstToTarget, obstacleMask)){
					visibleTargets.Add(target);
				}
			}
		}
	}

	void DrawFieldOfView(){
		int stepCount = Mathf.RoundToInt(fovResolution);
		float stepAngleSize = viewAngle / stepCount;
		List<Vector3> viewPoints = new List<Vector3>();
		ViewCastInfo oldViewCast = new ViewCastInfo();

		for (int i = 0; i <= stepCount; i++) {
			float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
			ViewCastInfo newViewCast = ViewCast(angle);

			if(i > 0){
				bool edgeDistanceThresholdExceeded = Mathf.Abs(oldViewCast.distance - newViewCast.distance) > edgeDistanceThreshold;
				if(oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDistanceThresholdExceeded)){
					EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
					if(edge.pointA != Vector3.zero){
						viewPoints.Add(edge.pointA);
					}
					if(edge.pointB != Vector3.zero){
						viewPoints.Add(edge.pointB);						
					}
				}
			}

			viewPoints.Add(newViewCast.point);
			oldViewCast = newViewCast;
		}

		int vertexCount = viewPoints.Count + 1;
		Vector3[] vertices = new Vector3[vertexCount];
		int[] triangles = new int[(vertexCount - 2) * 3];

		vertices[0] = Vector3.zero;
		for (int i = 0; i < vertexCount - 1; i++) {
			vertices[i + 1] = transform.InverseTransformPoint(viewPoints [i]);

			if(i < vertexCount - 2){
				triangles[i * 3] = 0;
				triangles[i * 3 + 1] = i + 1;
				triangles[i * 3 + 2] = i + 2;
			}
		}

		viewMesh.Clear();
		viewMesh.vertices = vertices;
		viewMesh.triangles = triangles;
		viewMesh.RecalculateNormals();

		// viewPoints.ForEach(point => Debug.DrawLine(origin.position, point, Color.red));
	}

	ViewCastInfo ViewCast(float globalAngle){
		Vector3 dir = DirFromAngle(globalAngle, true);
		RaycastHit hit;

		if(Physics.Raycast(origin.position, dir, out hit, radius, obstacleMask)){
			return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
		}

		return new ViewCastInfo(false, origin.position + dir * radius, radius, globalAngle);
	}

	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

	EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast){
		float minAngle = minViewCast.angle;
		float maxAngle = maxViewCast.angle;
		Vector3 minPoint = Vector3.zero;
		Vector3 maxPoint = Vector3.zero;

		for (int i = 0; i < edgeDetectionAccuracy; i++) {
			float angle = (minAngle + maxAngle) / 2;
			ViewCastInfo newViewCast = ViewCast(angle);

			bool edgeDistanceThresholdExceeded = Mathf.Abs(minViewCast.distance - newViewCast.distance) > edgeDistanceThreshold;
			if(newViewCast.hit == minViewCast.hit && !edgeDistanceThresholdExceeded){
				minAngle = angle;
				minPoint = newViewCast.point;
			} else {
				maxAngle = angle;
				maxPoint = newViewCast.point;
			}
		}

		return new EdgeInfo(minPoint, maxPoint);
	}

	public struct ViewCastInfo{
		public bool hit;
		public Vector3 point;
		public float distance;
		public float angle;

		public ViewCastInfo(bool hit, Vector3 point, float distance, float angle){
			this.hit = hit;
			this.point = point;
			this.distance = distance;
			this.angle = angle;
		}
	}

	public struct EdgeInfo{
		public Vector3 pointA;
		public Vector3 pointB;

		public EdgeInfo(Vector3 pointA, Vector3 pointB){
			this.pointA = pointA;
			this.pointB = pointB;
		}
	}
}