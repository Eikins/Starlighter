using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
	[SerializeField] private bool debug_display = false;
	
	private PlayerInputAction inputActions;
	
	private Vector2 inScreenPosition; 	//Position of the Ship in the orthogonal plane 
	public Rect movementLimits; 		//The ship can't go out of this rectangle (-8/-1/16/8 for 16:9)
	
	[SerializeField] private float speedX = 5;
	[SerializeField] private float speedY = 3;
	
	private void Awake(){
		inputActions = new PlayerInputAction();
		inScreenPosition = new Vector2(0,0);
	}
	
	private void OnEnable(){
		inputActions.Enable();
	}
	
	private void OnDisable(){
		inputActions.Disable();
	}
	
    void Start(){
		
	}
	
	void Update(){
		Vector2 movementInput = inputActions.Player.Move.ReadValue<Vector2>(); //Fetch Input
		

		Vector3 currentPos = transform.InverseTransformPoint(transform.position);
		
		currentPos.x += movementInput.x * speedX * Time.deltaTime;
		inScreenPosition.x += movementInput.x * speedX * Time.deltaTime;
		
		if(inScreenPosition.x < movementLimits.xMin || inScreenPosition.x > movementLimits.xMax){ //Out of Range X
			currentPos.x -= movementInput.x * speedX * Time.deltaTime;
			inScreenPosition.x -= movementInput.x * speedX * Time.deltaTime;
			Debug.Log("Correction horizontale");
		}
		
		currentPos.y += movementInput.y * speedY * Time.deltaTime; 
		inScreenPosition.y += movementInput.y * speedY * Time.deltaTime;
		
		if(inScreenPosition.y < movementLimits.yMin || inScreenPosition.y > movementLimits.yMax ){ //Out of Range Y
			currentPos.y -= movementInput.y * speedY * Time.deltaTime;
			inScreenPosition.y -= movementInput.y * speedY * Time.deltaTime;
			Debug.Log("Correction verticale");
		}
		
		if(debug_display){
			Debug.Log(currentPos);
			Debug.Log(inScreenPosition);
		}
		
		
		transform.position = transform.TransformPoint(currentPos.x,currentPos.y,currentPos.z);
		
	}
}
