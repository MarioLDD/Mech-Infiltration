using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public abstract string powerUpName { get; }
    public abstract void Activate(PlayerController playerControllert);

}








//public class BuildManager : MonoBehaviour
//{
//    [SerializeField] private ObjectFactory factory;
//    [SerializeField] private Transform factoryPoint;
//    private bool isBuilded;

//    private void Start()
//    {
//        isBuilded = false;
//    }
//    public void BuildRock()
//    {
//        if (!isBuilded)
//        {
//            factory.CreateObject("Rock", factoryPoint);
//            isBuilded = true;
//        }
//    }
//    public void BuildShrub()
//    {
//        if (!isBuilded)
//        {
//            factory.CreateObject("Shrub", factoryPoint);
//            isBuilded = true;
//        }
//    }

//    public void BuildTree()
//    {
//        if (!isBuilded)
//        {
//            factory.CreateObject("Tree", factoryPoint);
//            isBuilded = true;
//        }
//    }
//}
