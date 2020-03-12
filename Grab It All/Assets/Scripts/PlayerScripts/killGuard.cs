using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killGuard : MonoBehaviour
{
    public objetivosController objetivoscontroller;
    [SerializeField]
    protected GameObject PanelText;
    [SerializeField]
    protected TMPro.TextMeshProUGUI TextToUse;
    private bool _alive = true;
    private bool _pickable = false;
    public bool PlayerContact = false;

    private void Start()
    {
        PanelText.SetActive(false);
        TextToUse.text = "Pulsa[E] para Matar.";
    }

    private void Update()
    {
        Debug.Log("alive" + _alive);
        Debug.Log("pickable" + _pickable);

        if (PlayerContact)
        {
            if (_alive)
            {
                TextToUse.text = "Pulsa[E] para Matar.";
            }
            else if(!_alive && _pickable)
            {
                TextToUse.text = "Pulsa[F] para Recoger Cadaver.";
            }
            else if (!_alive && !_pickable)
            {
                TextToUse.text = "Pulsa[G] para Dejar Cadaver.";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="enemyBack")
        {
            enemyScript e;
            e = other.gameObject.GetComponentInParent<enemyScript>();

            _alive = e.alive;
            _pickable = e.pickable;
            PlayerContact = true;
            PanelText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Animator anim;
                anim = gameObject.GetComponent<Animator>();
                
                if (e.alive)
                {
                    anim.SetTrigger("Kill");
                    e.die();
                    if (objetivoscontroller.numeroObjetivo == 5)
                        objetivoscontroller.numeroObjetivo++;
                }

            }
            if (Input.GetKeyDown(KeyCode.F))
            {            
                if (e.pickable)
                {
                    e.pick(gameObject);
                    e.pickable = false;
                }

            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (!e.pickable)
                { 
                    e.drop(gameObject);
                    e.pickable = true;
                }
            }
        }
        else
        {
            PlayerContact = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemyBack")
        {
            PanelText.SetActive(false);
        }
    }
}
