/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
	public class target_13_7 : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
        public GameObject canvas1;
		public GameObject fbx;



        void Start()
        {
            // intially false these buttons
			//ButtonElectronFlow.gameObject.SetActive (false);

            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
			canvas1.gameObject.SetActive (false);
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
			try
			{
	            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
	            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

	            // Enable rendering:
	            foreach (Renderer component in rendererComponents)
	            {
	                component.enabled = true;


					canvas1.gameObject.SetActive (true);
	            }

	            // Enable colliders:
	            foreach (Collider component in colliderComponents)
	            {
	                component.enabled = true;
	                
	            }

	            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			}
			catch(System.Exception e)
			{
				print ("Something Wrong with Your Device");
			}
        }


        private void OnTrackingLost()
        {
			try
			{
	            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
	            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

	            // Disable rendering:
	            foreach (Renderer component in rendererComponents)
	            {
	                component.enabled = false;
	            }

	            // Disable colliders:
	            foreach (Collider component in colliderComponents)
	            {
	                component.enabled = false;
	            }

	            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

				canvas1.gameObject.SetActive (false);
				fbx.gameObject.GetComponent<AudioSource>().Stop();
				fbx.gameObject.transform.localPosition = new Vector3 (0.031f,0.056f, 1.8931e-05f);
				fbx.gameObject.transform.localScale = new Vector3 (2.691833f, 2.691833f, 2.691833f);
				fbx.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}
			catch(System.Exception e)
			{
				print ("Something Wrong with Your Device");
			}
        }
      

        #endregion // PRIVATE_METHODS
    }
}
