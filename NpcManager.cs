using Invector.vCharacterController;
using QuantumTek.QuantumDialogue.Demo;
using QuantumTek.SimpleMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcManager : MonoBehaviour
{
    private Animator anim;
    private int time;
    NavMeshAgent agent;

    #region Variables       
    [Header("- Range")]
    public Transform target;
    public float lookRadius;

    [Header("- Sound Conver")]
    public AudioSource _audioSource;
    public AudioClip ConverSound;
    public AudioClip CompSound;


    [Header("- Conversation")]
    public int conver; 
    public bool meetwith = false;
    public bool acceptQ = false;
    public bool leftKey5 = false;
    public bool nbegin = false;
    public bool afterdead = false;

    [Header("- Check KeyItem")]
    public bool Key1 = false;
    public bool Key2 = false;
    public bool Key3 = false;
    public bool Key4 = false;
    public bool Key5 = false;


    [HideInInspector] public static NpcManager instance;

    #endregion

    void Start()
    {
        target = vThirdPersonController.instance.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius && time == 0)
        {
            QD_DialogueDemo.instance.MessageUI.SetActive(true);
            time = 1;
        }
        else if (distance <= lookRadius && QD_DialogueDemo.instance.handler.currentMessageInfo.ID < 0)
        {
            QD_DialogueDemo.instance.MessageUI.SetActive(true);
            time = 1;
        }
        else if (distance >= lookRadius)
        {
            QD_DialogueDemo.instance.MessageUI.SetActive(false);
            time = 0;
        }
        else { }

        if (Key1 == true && Key2 == true && Key2 == true && Key4 == true) { conver = 2; }
        if (Key5 == true) { conver = 5; }

        if (conver == 0)
        {
            meetwith = true;
            acceptQ = false;
            leftKey5 = false;
            nbegin = false;
            afterdead = false;
        }
        else if (conver == 1)
        {
            acceptQ = true;
            meetwith = false;
            leftKey5 = false;
            nbegin = false;
            afterdead = false;
        }
        else if (conver == 2)
        {
            leftKey5 = true;
            meetwith = false;
            acceptQ = false;
            nbegin = false;
            afterdead = false;
        }
        else if (conver == 3 && !QD_DialogueDemo.instance.DialogueUI.activeSelf)
        {
            QD_DialogueDemo.instance.CompleteUI.SetActive(true);
            Invoke("compsound", 1f);
        }
        else if (conver == 4)
        {
            nbegin = true;
            leftKey5 = false;
            meetwith = false;
            acceptQ = false;
            afterdead = false;
        }
        else if (conver == 5)
        {
            afterdead = true;
            nbegin = false;
            leftKey5 = false;
            meetwith = false;
            acceptQ = false;
        }
        else if (conver == 6 && !QD_DialogueDemo.instance.DialogueUI.activeSelf)
        {
            QD_DialogueDemo.instance.CompleteUI.SetActive(true);
            Invoke("compsound", 1f);
        }

        if (Input.GetKeyUp(KeyCode.F) && distance <= lookRadius)
        {
            _audioSource.PlayOneShot(ConverSound);
        }
        if (Input.GetKeyUp(KeyCode.F) && distance <= lookRadius && meetwith == true)
        {
            QD_DialogueDemo.instance.MessageUI.SetActive(false);
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("Meeting with Wizard");
            QD_DialogueDemo.instance.SetText();
            conver = 1;
        }
        else if (Input.GetKeyUp(KeyCode.F) && distance <= lookRadius && acceptQ == true)
        {
            QD_DialogueDemo.instance.MessageUI.SetActive(false);
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("Accept Quest");
            QD_DialogueDemo.instance.SetText();
        }
        else if (Input.GetKeyUp(KeyCode.F) && distance <= lookRadius && leftKey5 == true)
        {
            QD_DialogueDemo.instance.MessageUI.SetActive(false);
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("LeftKeyItem5");
            QD_DialogueDemo.instance.SetText();
            Key1 = false; Key2 = false; Key3 = false; Key4 = false;
            conver = 3;
        }
        else if (Input.GetKeyUp(KeyCode.F) && distance <= lookRadius && nbegin == true)
        {
            QD_DialogueDemo.instance.MessageUI.SetActive(false);
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("NightBegin");
            QD_DialogueDemo.instance.SetText();
        }
        else if (Input.GetKeyUp(KeyCode.F) && distance <= lookRadius && afterdead == true)
        {
            QD_DialogueDemo.instance.MessageUI.SetActive(false);
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("After seen Thedead");
            QD_DialogueDemo.instance.SetText();
            Key5 = false;
            conver = 6;
        }
        else { }
    }

    void compsound()
    {
        _audioSource.PlayOneShot(CompSound);
    }
    private void Awake()
    {
        instance = this;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
