using UnityEngine;
using UnityEngine.InputSystem;


namespace Starlighter.Gameplay
{
	public sealed class ShipController : MonoBehaviour
	{
		#region Fields
		[SerializeField] private float _speed = 1.0f;
		[SerializeField] private Vector2 _tilt = new Vector2(30.0f, 15.0f);
		[SerializeField] private float _tiltSpeed = 10.0f;

		private Vector2 _inputMovement = Vector2.zero;
		#endregion

		#region Input Events
		public void OnMove(InputAction.CallbackContext ctx)
		{
			_inputMovement = ctx.ReadValue<Vector2>();
		}
		#endregion

		#region Unity Callbacks
		private void FixedUpdate()
		{
			Move();
			ClampPosition();
			Rotate();
		}
		#endregion

		private void Move()
		{
			// Move the player in the local XY plane.
			transform.localPosition += (Vector3)_inputMovement * _speed * Time.fixedDeltaTime;
		}

		private void ClampPosition()
		{
			// Clamp position in camera bounds
			var position = Camera.main.WorldToViewportPoint(transform.position);
			position.x = Mathf.Clamp01(position.x);
			position.y = Mathf.Clamp01(position.y);
			transform.position = Camera.main.ViewportToWorldPoint(position);
		}

		private void Rotate()
		{
			var localRotation = transform.localRotation;
			var targetRotation = Quaternion.Euler(-_inputMovement.y * _tilt.y, 0.0f, -_inputMovement.x * _tilt.x);
			transform.localRotation = Quaternion.Lerp(localRotation, targetRotation, Time.deltaTime * _tiltSpeed);
		}

	}
}
