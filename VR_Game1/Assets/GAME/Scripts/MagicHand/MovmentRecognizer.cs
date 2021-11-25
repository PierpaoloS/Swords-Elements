using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using PDollarGestureRecognizer;
using System.IO;
using UnityEngine.Events;
using System.Xml;
using System.Xml.Serialization;
using System.Data;


public class MovmentRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    public float newPositionThresholdDistance = 0.5f;
    public GameObject debugCubePrefab;
    public bool creationMode = true;
    public string newGestureName;
    private List<Gesture> trainingSet = new List<Gesture>();
    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();
    public Transform movementSource;
    
    //agg variabili per la build
    /*public TextAsset XMLObject;
    private StringReader xml;
    public Data data = new Data();
    data
    */
    public XmlDocument Wave;
    public XmlDocument Triangle;
    public XmlDocument InvertedTriangle;
    public XmlDocument Square;

    //riconoscimento Gesture Test
    public float recognitionThreshold = 0.9f;
    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string>{} //per cercare la stringa ovvero il nome della gesture
    public UnityStringEvent OnRecognize;
    
    /*
     TextAsset textAsset = (TextAsset)Resources.Load("FileNameWhitoutFileExtention", typeof(TextAsset));
    XmlDocument xmldoc = new XmlDocument ();
    xmldoc.LoadXml ( textAsset.text );
    
    C:/Users/amministratore/Desktop/Swords&Elements/Swords-Elements/VR_Game1/Assets/Resources
    
    Application.persistentDataPath
    */
    
    
    void Start()
    {
        //cerca tutti i file con estensione xml
        //file sarà salvato in Windows(C:)/Users/MSI GE/ AppData/LocalLow/DefaultCompany/MovementRecognizer
        // Nel mio caso :  C:\Users\amministratore\AppData\LocalLow\DefaultCompany\VR_Game
        //string[] gestureFiles = Directory.GetFiles(Application.persistentDataPath, "*.xml");
        Wave = new XmlDocument();
        Triangle = new XmlDocument();
        InvertedTriangle = new XmlDocument();
        Square = new XmlDocument();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0 & System.IO.File.Exists(Application.persistentDataPath + "/Resources/Wave.xml"))
            {
                Wave.Load(Application.persistentDataPath + "/Resources/Wave.xml");
                trainingSet.Add(GestureIO.ReadGestureFromXML(Wave.InnerXml));

            }
            else
            {
                TextAsset waveXml = (TextAsset) Resources.Load("Wave", typeof(TextAsset));
                trainingSet.Add(GestureIO.ReadGestureFromXML(waveXml.ToString()));
            }
            if (i == 1 & System.IO.File.Exists(Application.persistentDataPath + "/Resources/Triangle.xml"))
            {
                Triangle.Load(Application.persistentDataPath + "/Resources/Triangle.xml");
                trainingSet.Add(GestureIO.ReadGestureFromXML(Triangle.InnerXml));
            }
            else
            {
                TextAsset triangleXml = (TextAsset) Resources.Load("Triangle", typeof(TextAsset));
                trainingSet.Add(GestureIO.ReadGestureFromXML(triangleXml.ToString()));
            }
            if (i == 2 & System.IO.File.Exists(Application.persistentDataPath + "/Resources/InverseTriangle.xml"))
            {
                InvertedTriangle.Load(Application.persistentDataPath + "/Resources/InverseTrinangle.xml");
                trainingSet.Add(GestureIO.ReadGestureFromXML(InvertedTriangle.InnerXml));
            }
            else
            {
                TextAsset invertedTriangleXml = (TextAsset) Resources.Load("InvertedTriangle", typeof(TextAsset));
                trainingSet.Add(GestureIO.ReadGestureFromXML(invertedTriangleXml.ToString()));
            }
            if (i == 3 & System.IO.File.Exists(Application.persistentDataPath + "/Resources/Square.xml"))
            {
                Square.Load(Application.persistentDataPath + "/Resources/Square.xml");
                trainingSet.Add(GestureIO.ReadGestureFromXML(Square.InnerXml));
            }
            else
            {
                TextAsset squareXml = (TextAsset) Resources.Load("Square", typeof(TextAsset));
                trainingSet.Add(GestureIO.ReadGestureFromXML(squareXml.ToString()));
            }
        }
        
        
        

        //string[] gestureFiles = Directory.GetFiles(Application.persistentDataPath, "*.xml");
        //string[] gestureFiles = Directory.GetFiles(Application.streamingAssetsPath,"*.xml");
        //xml = new StringReader(XMLObject.text);
        //data = data.Load(xml);
        
        /*foreach (var item in gestureFiles)
        {
            Debug.Log(item);
            trainingSet.Add(GestureIO.ReadGestureFromFile(item));
        } */
        
    }

    /*void DataLoad(StringReader xml)
    {
        var serializer = new XmlSerializer(typeof(Data));
        return serializer.Deserialize(xml) as Data;
    }
    */
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
       
        //Start The Movement
        if (!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending The Movement
        else if (isMoving && !isPressed)
        {
            EndMovement();
        }
        else if (isMoving && isPressed)
        {
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movementSource.position);
        if (debugCubePrefab)
        {
            Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
        }
    }

    void EndMovement()
    {
        Debug.Log("End Movement");
        isMoving = false;
        
        //Create the gesture from position list
        Point[] pointArray = new Point[positionsList.Count];

        for (int i = 0; i < positionsList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionsList[i]);
            pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);
        }
        Gesture newGesture = new Gesture(pointArray);
        //Add New Gesture to Training Set
        if (creationMode)
        {
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);
            //scrittura e salvataggio delle gesture nel file name .xml
            string fileName = Application.persistentDataPath + "/" + newGestureName + ".xml";
            GestureIO.WriteGesture(pointArray, newGestureName, fileName);
        }
        //riconoscimento
        else
        {
            Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
            Debug.Log(result.GestureClass + result.Score);
            if (result.Score > recognitionThreshold)
            {
                OnRecognize.Invoke(result.GestureClass);
            }
        }
    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
        Vector3 lastPosition = positionsList[positionsList.Count - 1]; 
        if (Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);
            if (debugCubePrefab)
            {
                Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
            }
        }
    }
}
