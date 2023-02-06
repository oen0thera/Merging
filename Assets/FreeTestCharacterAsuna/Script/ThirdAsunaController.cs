using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using StarterAssets;

//김기범 - Asuna용도 컨트롤러 클래스
public class ThirdAsunaController : MonoBehaviour
{

    //에임상태일때 시네머신카메라
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    // 비조준 상태일때 카메라 민감도
    [SerializeField] private float normalSensitivity;
    // 조준 상태일떄 카메라 민감도
    [SerializeField] private float aimSensitivity;
    //카메라 
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    //디버깅용 객체
    [SerializeField] private Transform debugTransform;
    //총알 transform 객체
    [SerializeField] private Transform bullet;
    //총알 생성위치 (임시) 
    [SerializeField] private Transform spawnBulletPosition;

    private StarterAssetsInputs asunaInputs;
    private ThirdPersonController thirdPersonController;
    private GameObject crosshair;
    private Animator animator;

    Vector3 mouseWorldPosition = Vector3.zero;
    private void Awake()
    {
        asunaInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //화면 중앙 2차원 벡터값
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);

        //ray오브젝트 카메라에서 마우스가 가르키는 화면포인트를 ray객체에 할당
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        //raycast ??
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        Aim();

    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "EventObj")
        {
            if (asunaInputs.investigate)
            {
                other.GetComponent<EventObject>().getEventUI().SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EventObj")
        {
            other.GetComponent<EventObject>().getEventUI().SetActive(false);
        }
    }
    private void Shoot()
    {
        if (asunaInputs.shoot)
        {
            animator.SetBool("Shoot", true);
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(bullet, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
        }
        else if (!asunaInputs.shoot)
        {
            animator.SetBool("Shoot", false);
        }
    }

    private void Aim()
    {
        // if 마우스 우클릭 눌림
        if (asunaInputs.aim)
        {

            //조준상태 카메라 활성화
            aimVirtualCamera.gameObject.SetActive(true);

            //조준 상태일때 활성화 ( 조준상태면 크로스헤어가 보임)
            crosshair.SetActive(true);

            //조준 상태일때 카메라 민감도를 aimSenstivitity로 Set
            thirdPersonController.SetSensitivity(aimSensitivity);

            //조준 상태일때 asuna회전 false로 set
            thirdPersonController.SetRotateOnMove(false);

            //애니메이션
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 5f));
            animator.SetBool("Aiming", true);

            //에임 상태일때 asuna가 조준점 방향으로 향하도록 해주는 코드
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            Shoot();
        }
        // if 비조준상태일떄, (마우스 우클릭 안누르고있는 상태)
        else
        {
            //조준상태 카메라 비활성화
            aimVirtualCamera.gameObject.SetActive(false);

            //일반 상태일떄 비활성화( 비조준상태 크로스헤어가 안보임)
            crosshair.SetActive(false);

            //비조준 상태일떄 카메라 민감도를 일반상태로 바꿈
            thirdPersonController.SetSensitivity(normalSensitivity);

            //비조준 상태일때 asuna회전 true로 set
            thirdPersonController.SetRotateOnMove(true);

            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 2f));
            animator.SetBool("Aiming", false);
        }
    }

    }

