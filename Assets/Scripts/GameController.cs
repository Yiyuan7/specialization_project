namespace ARVRAssignments
{
    using UnityEngine;
    using System.Collections.Generic;
    using Vuforia;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class GameController : MonoBehaviour
    {

        public enum GameState
        {
            AddingMarkers,
           
        };

        [SerializeField]
        public ContentPositioningBehaviour m_ContentPositioningBhvr;

        [SerializeField]
        public GameObject imagetarget;


        private GameState m_nowState;

        private List<Vector3> marker;

        private List<Vector3> relativeDistances;

        private void Start()
        {
            m_nowState = GameState.AddingMarkers;
            //TODO: Initalise the class members and event listeners.
            m_ContentPositioningBhvr.OnContentPlaced.AddListener(x => SpawnNewMarker(x));
            marker = new List<Vector3>();
            relativeDistances = new List<Vector3>();

        }

        private void SpawnNewMarker(GameObject newMarker)
        {

            newMarker.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            marker.Add(newMarker.transform.position);

            Debug.Log("Marker position = " + newMarker.transform.position);
            Debug.Log("Image position = " + imagetarget.transform.position);

            Vector3 relativeDistance = newMarker.transform.position - imagetarget.transform.position;
            relativeDistances.Add(relativeDistance);
            Debug.Log("relativeDistance = " + relativeDistance);

        }

    }
}