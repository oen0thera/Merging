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

		//����� interaction - EŰ ������ �ش� ������Ʈ�� ��ȣ�ۿ�
		public bool interaction;

		//����� inventory - IŰ ������ Inventory UI Ȱ��ȭ
		public bool inventory;

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

		//����� - InteractionInput �Լ��� ��ư�� ���ȴ��� �ȴ��ȴ��� �� �Ѱ��ִ� �Լ�
		public void OnInteraction(InputValue value)
		{
			InteractionInput(value.isPressed);
		}

		//����� - InventoryInput �Լ��� ��ư�� ���ȴ��� �ȴ��ȴ��� �� �Ѱ��ִ� �Լ�
		public void OnInventory(InputValue value)
		{
			InventoryInput(value.isPressed);
		}


#endif

		//����� - �κ��丮 ���½� ĳ���� ���� �Ұ� ���� Ȱ��ȭ
		public void MoveInput(Vector2 newMoveDirection)
		{
			if (inventory==false)
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
            if (inventory == false)
            look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
            if (inventory == false)
			jump = newJumpState;
		}
		
		public void SprintInput(bool newSprintState)
		{
            if (inventory == false)
			sprint = newSprintState;
		}

		//���� - Aiminput�Լ��߰�
		public void AimInput(bool newAimState)
		{
            if (inventory == false)
			aim = newAimState;
		}
		//���� -  ShootInput �Լ� �߰�
		public void ShootInput(bool newShootState)
		{
            if (inventory == false)
                shoot = newShootState;
		}
		//���� - �����ư �Լ� �߰�;
		public void InvestigateInput(bool newInvestigateState)
		{
            if (inventory == false)
            investigate = newInvestigateState;
			
		}

		//����� - ��ȣ�ۿ� �Լ� �߰�;
		public void InteractionInput(bool newInteractionState)
		{
            if (inventory == false)
            interaction = newInteractionState;
            
        }

		//����� - �κ��丮 �Լ� �߰�;
		//����� - �κ��丮�� ���������� ������ �������� ��
		public void InventoryInput(bool newInventoryState)
		{
			if (inventory == false)
			{
				move = new Vector2(0,0);
                inventory = newInventoryState;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
            }
			else
			{
                Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				inventory = false;
            }
			
			 
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