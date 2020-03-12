//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(DB))]
//public class InventarioEditor : Editor
//{
    
//    private DB database;
//    private string searchString = "";
//    private bool shouldSearch;
//    private void OnEnable()
//    {
//        database = (DB)target;
//    }

//    public override void OnInspectorGUI()
//    {
     
//        if (database)
//        {
//            EditorGUILayout.BeginHorizontal("Box");
//            GUILayout.Label("Items en DataBase: " + database.items.Count);
//            EditorGUILayout.EndHorizontal();
//            if(database.items.Count>0 )
//            {
//                EditorGUILayout.BeginHorizontal("Box");
//                GUILayout.Label("Search: ");
//                searchString = GUILayout.TextField(searchString);
//                EditorGUILayout.EndHorizontal();
//            }
           
//            if(GUILayout.Button("Add Item"))
//            {
//                ItemWindow.ShowEmptyWindow(database);
//            }

//            if(System.String.IsNullOrEmpty(searchString))
//            {
//                shouldSearch = false;   
//            }
//            else
//            {
//                shouldSearch = true;

//            }

//            foreach (Objeto item in database.items)
//            {
//                //dibujar representacion de item
//                if(shouldSearch)
//                {
//                    if(searchString == item.name || item.name.Contains(searchString) || item.id.ToString() == searchString)
//                    {
//                        DisplayItem(item);
//                    }
//                }
//                else
//                     DisplayItem(item);
//            }

//            if(deletedItem != null)
//                database.items.Remove(deletedItem);
//        }
        
//    }

//    private Objeto deletedItem;
   
//    private void DisplayItem(Objeto item)
//    {
//        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
//        labelStyle.wordWrap = true;

//        GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
//        labelStyle.wordWrap = true;
//        valueStyle.alignment = TextAnchor.MiddleLeft;
//        valueStyle.fixedWidth = 50;
//        valueStyle.margin = new RectOffset(0, 50, 0, 0);

//        EditorGUILayout.BeginVertical("Box");

//        Sprite itemSprite = item.itemImage;
//        if (itemSprite != null)
//        {
//            EditorGUILayout.BeginHorizontal();
//            EditorGUILayout.LabelField("Image: " + item.itemImage.ToString());
//            EditorGUILayout.EndHorizontal();
//        }

//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Id: ");
//        GUILayout.Label(item.id.ToString(),valueStyle);
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Name: ");
//        GUILayout.Label(item.name , valueStyle);
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Cost:  ");
//        GUILayout.Label(item.cost.ToString(), valueStyle);
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Stackable:  ");
//        GUILayout.Label(item.isStackable.ToString(), valueStyle);
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.BeginHorizontal();
//        GUILayout.Label("Description: ");
//        item.scrollPos = EditorGUILayout.BeginScrollView(item.scrollPos, GUILayout.MinHeight(3),GUILayout.MinHeight(100));       
//        GUILayout.Label(item.description, labelStyle);
//        EditorGUILayout.EndScrollView();
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.BeginHorizontal();

//        if (GUILayout.Button("Modify"))
//        {
//            ModifyWindow.ShowItemWindow(database, item);
//        }

//        if (GUILayout.Button("Delete"))
//        {
//            deletedItem = item;

//        }
//        else
//            deletedItem = null;

      
//        EditorGUILayout.EndHorizontal();
//        EditorGUILayout.EndVertical();
//    }
//}
