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
		//���� aim - ���콺 ��Ŭ������ ���� �������� ����
		public bool aim;
		//���� shoot - ���콺 ��Ŭ�� �ѽ���ִ� �������� ����
		public bool shoot;
		//���� investigate - RŰ ������ �ش� ������Ʈ ����
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

		//���� - Aiminput�Լ��� ��ư�� ���ȴ��� �ȴ��ȴ��� �� �Ѱ��ִ� �Լ�
		public void OnAim(InputValue value)
		{
			AimInput(value.isPressed);
		}
		//���� - ShootInput �Լ��� ��ư�� ���ȴ��� �ȴ��ȴ��� �� �Ѱ��ִ� �Լ�
		public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}
		//���� - InvestigateInput �Լ��� ��ư�� ���ȴ��� �ȴ��ȴ��� �� �Ѱ��ִ� �Լ�
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

		//���� - Aiminput�Լ��߰�
		public void AimInput(bool newAimState)
		{
			aim = newAimState;
		}
		//���� -  ShootInput �Լ� �߰�
		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}
		//���� - �����ư �Լ� �߰�;
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