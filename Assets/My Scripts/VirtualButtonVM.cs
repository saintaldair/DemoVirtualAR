using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonVM : MonoBehaviour, IVirtualButtonEventHandler
{
    #region PUBLIC_MEMBERS
    public GameObject NotaMusical;
    public AudioSource Nota;

    #endregion // PUBLIC_MEMBERS

    #region PRIVATE_MEMBERS
    VirtualButtonBehaviour[] virtualButtonBehaviours;
    #endregion // PRIVATE_MEMBERS

    #region MONOBEHAVIOUR_METHODS
    void Start()
    {

        // Register with the virtual buttons TrackableBehaviour
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
        {
            virtualButtonBehaviours[i].RegisterEventHandler(this);
        }
    }

    #endregion // MONOBEHAVIOUR_METHODS


    #region PUBLIC_METHODS
    /// <summary>
    /// Called when the virtual button has just been pressed:
    /// </summary>
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
 
        Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);
        Debug.Log("Entre");
        if (!NotaMusical.activeSelf)
        {
            NotaMusical.SetActive(true);
        }
        else
        {
            NotaMusical.SetActive(false);
        }

        StopAllCoroutines();

        BroadcastMessage("HandleVirtualButtonPressed", SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// Called when the virtual button has just been released:
    /// </summary>
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("OnButtonReleased: " + vb.VirtualButtonName);


    }
    #endregion //PUBLIC_METHODS


    #region PRIVATE_METHODS
    void SetVirtualButtonMaterial(Material material)
    {
        // Set the Virtual Button material
        for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
        {
            if (material != null)
            {
                virtualButtonBehaviours[i].GetComponent<MeshRenderer>().sharedMaterial = material;
            }
        }
    }

    IEnumerator DelayOnButtonReleasedEvent(float waitTime, string buttonName)
    {
        yield return new WaitForSeconds(waitTime);

        BroadcastMessage("HandleVirtualButtonReleased", SendMessageOptions.DontRequireReceiver);
    }
    #endregion // PRIVATE METHODS



}
