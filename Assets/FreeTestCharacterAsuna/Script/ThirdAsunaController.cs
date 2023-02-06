using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using StarterAssets;

//���� - Asuna�뵵 ��Ʈ�ѷ� Ŭ����
public class ThirdAsunaController : MonoBehaviour
{

    //���ӻ����϶� �ó׸ӽ�ī�޶�
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    // ������ �����϶� ī�޶� �ΰ���
    [SerializeField] private float normalSensitivity;
    // ���� �����ϋ� ī�޶� �ΰ���
    [SerializeField] private float aimSensitivity;
    //ī�޶� 
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    //������ ��ü
    [SerializeField] private Transform debugTransform;
    //�Ѿ� transform ��ü
    [SerializeField] private Transform bullet;
    //�Ѿ� ������ġ (�ӽ�) 
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
        //ȭ�� �߾� 2���� ���Ͱ�
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);

        //ray������Ʈ ī�޶󿡼� ���콺�� ����Ű�� ȭ������Ʈ�� ray��ü�� �Ҵ�
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
        // if ���콺 ��Ŭ�� ����
        if (asunaInputs.aim)
        {

            //���ػ��� ī�޶� Ȱ��ȭ
            aimVirtualCamera.gameObject.SetActive(true);

            //���� �����϶� Ȱ��ȭ ( ���ػ��¸� ũ�ν��� ����)
            crosshair.SetActive(true);

            //���� �����϶� ī�޶� �ΰ����� aimSenstivitity�� Set
            thirdPersonController.SetSensitivity(aimSensitivity);

            //���� �����϶� asunaȸ�� false�� set
            thirdPersonController.SetRotateOnMove(false);

            //�ִϸ��̼�
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 5f));
            animator.SetBool("Aiming", true);

            //���� �����϶� asuna�� ������ �������� ���ϵ��� ���ִ� �ڵ�
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            Shoot();
        }
        // if �����ػ����ϋ�, (���콺 ��Ŭ�� �ȴ������ִ� ����)
        else
        {
            //���ػ��� ī�޶� ��Ȱ��ȭ
            aimVirtualCamera.gameObject.SetActive(false);

            //�Ϲ� �����ϋ� ��Ȱ��ȭ( �����ػ��� ũ�ν��� �Ⱥ���)
            crosshair.SetActive(false);

            //������ �����ϋ� ī�޶� �ΰ����� �Ϲݻ��·� �ٲ�
            thirdPersonController.SetSensitivity(normalSensitivity);

            //������ �����϶� asunaȸ�� true�� set
            thirdPersonController.SetRotateOnMove(true);

            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 2f));
            animator.SetBool("Aiming", false);
        }
    }

    }

