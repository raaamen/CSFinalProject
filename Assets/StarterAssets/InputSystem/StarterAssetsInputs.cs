using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool camswitch;

		public Vector2 cameramove;

		public float zoom;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{	
			LookInput(value.Get<Vector2>());
		}

		public void OnCameraLook(InputValue value){
			CameraLookInput(value.Get<Vector2>());
			Debug.Log("camera value:"+value.Get<Vector2>());
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnZoom(InputValue value){
			ZoomInput(value.Get<float>());
		}

		public void OnMoveCameraPos(InputValue value){

			Debug.Log("Camera Pos Moved: "+value.isPressed);
			MoveCameraInput(value.isPressed);
			
		}

        
#endif

		private void MoveCameraInput(bool isPressed)
        {
			Debug.Log("isPressed: " +isPressed);
            camswitch = isPressed;
        }

        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void CameraLookInput(Vector2 newLook){
			cameramove = newLook;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void ZoomInput(float newZoomLength){
			zoom = newZoomLength;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}