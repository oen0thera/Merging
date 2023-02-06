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

		//김원진 interaction - E키 누르면 해당 오브젝트와 상호작용
		public bool interaction;

		//김원진 inventory - I키 누르면 Inventory UI 활성화
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

		//김원진 - InteractionInput 함수에 버튼이 눌렸는지 안눌렸는지 값 넘겨주는 함수
		public void OnInteraction(InputValue value)
		{
			InteractionInput(value.isPressed);
		}

		//김원진 - InventoryInput 함수에 버튼이 눌렸는지 안눌렸는지 값 넘겨주는 함수
		public void OnInventory(InputValue value)
		{
			InventoryInput(value.isPressed);
		}


#endif

		//김원진 - 인벤토리 상태시 캐릭터 조작 불가 상태 활성화
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

		//김기범 - Aiminput함수추가
		public void AimInput(bool newAimState)
		{
            if (inventory == false)
			aim = newAimState;
		}
		//김기범 -  ShootInput 함수 추가
		public void ShootInput(bool newShootState)
		{
            if (inventory == false)
                shoot = newShootState;
		}
		//김기범 - 조사버튼 함수 추가;
		public void InvestigateInput(bool newInvestigateState)
		{
            if (inventory == false)
            investigate = newInvestigateState;
			
		}

		//김원진 - 상호작용 함수 추가;
		public void InteractionInput(bool newInteractionState)
		{
            if (inventory == false)
            interaction = newInteractionState;
            
        }

		//김원진 - 인벤토리 함수 추가;
		//김원진 - 인벤토리가 열려있을때 누르면 닫히도록 함
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