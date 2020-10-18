using UnityEngine;
using UnityEngine.InputSystem;


namespace Starlighter.Gameplay
{
	public sealed class CameraFollow : MonoBehaviour
	{
		#region Fields
		[SerializeField] private Transform _target = null;
		[SerializeField] private Vector2 _offset = Vector2.zero;
		[SerializeField] private Rect _limits = new Rect(-5, -3, 10, 6);
		[SerializeField] [Range(0, 1)] private float _damping = 0.5f;

		private Vector3 _dampVelocity = Vector3.zero;
		#endregion

		#region Unity Callbacks
		private void FixedUpdate()
		{
			FollowTarget();
			ClampPosition();
		}
		#endregion

		private void FollowTarget()
		{
			var localPos = transform.localPosition;
			var localTargetPos = _target.transform.localPosition + (Vector3) _offset;
			var targetPos = new Vector3(localTargetPos.x, localTargetPos.y, localPos.z);
			transform.localPosition = Vector3.SmoothDamp(localPos, targetPos, ref _dampVelocity, _damping, Mathf.Infinity, Time.fixedDeltaTime);
		}

		private void ClampPosition()
		{
			var localPos = transform.localPosition;
			localPos.x = Mathf.Clamp(localPos.x, _limits.xMin, _limits.xMax);
			localPos.y = Mathf.Clamp(localPos.y, _limits.yMin, _limits.yMax);
			transform.localPosition = localPos;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.matrix = transform.parent.localToWorldMatrix * Matrix4x4.Translate(new Vector3(0, 0, transform.localPosition.z));
			Gizmos.DrawWireCube(_limits.center, _limits.size);
		}

	}
}
