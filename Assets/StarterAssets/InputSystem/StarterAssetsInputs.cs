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
		//김기범 aim - 마우스 좌클릭으로 에임 상태인지 결정
		public bool aim;
		//김기범 shoot - 마우스 우클릭 총쏘고있는 상태인지 결정
		public bool shoot;
		//김기범 investigate - R키 누르면 해당 오브젝트 조사
		public bool investigate;
	

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
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		//김기범 - Aiminput함수에 버튼이 눌렸는지 안눌렸는지 값 넘겨주는 함수
		public void OnAim(InputValue value)
		{
			AimInput(value.isPressed);
		}
		//김기범 - ShootInput 함수에 버튼이 눌렸는지 안눌렸는지 값 넘겨주는 함수
		public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}
		//김기범 - InvestigateInput 함수에 버튼이 눌렸는지 안눌렸는지 값 넘겨주는 함수
		public void OnInvestigate(InputValue value)
		{
			InvestigateInput(value.isPressed);
		}

#endif


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
		
		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		//김기범 - Aiminput함수추가
		public void AimInput(bool newAimState)
		{
			aim = newAimState;
		}
		//김기범 -  ShootInput 함수 추가
		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}
		//김기범 - 조사버튼 함수 추가;
		public void InvestigateInput(bool newInvestigateState)
		{
			investigate = newInvestigateState;
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