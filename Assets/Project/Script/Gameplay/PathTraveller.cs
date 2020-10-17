using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

namespace Starlighter.Gameplay
{
	public sealed class PathTraveller : MonoBehaviour
	{
		#region Fields
		[SerializeField] private float _speed = 1.0f;

		private VertexPath _path = null;
		private float _distanceTravelled = 0.0f;
		#endregion

		#region Properties
		public float Progress => _distanceTravelled / _path.length;
		#endregion

		#region Unity Callbacks
		private void Start()
		{
			// TODO : Change to Level settings
			_path = GameObject.Find("Path").GetComponent<PathCreator>().path;
		}

		private void FixedUpdate()
		{
			// Integrate the distance
			_distanceTravelled += _speed * Time.fixedDeltaTime;
			// Update this object's position and rotation to follow the path
			transform.position = _path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
			transform.rotation = _path.GetRotationAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
		}
		#endregion

	}
}
