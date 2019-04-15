using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//public class EditorPreferenceItem
//{
//    // Have we loaded the prefs yet
//    private static bool prefsLoaded = false;

//    // The Preferences
//    public static bool boolPreference = false;

//    [PreferenceItem("My Preferences")]
//    public static void PreferencesGUI()
//    {
//        // Load the preferences
//        if (!prefsLoaded)
//        {
//            boolPreference = EditorPrefs.GetBool("BoolPreferenceKey", false);
//            prefsLoaded = true;
//        }

//        // Preferences GUI
//        boolPreference = EditorGUILayout.Toggle("Bool Preference", boolPreference);

//        // Save the preferences
//        if (GUI.changed)
//            EditorPrefs.SetBool("BoolPreferenceKey", boolPreference);
//    }
//}
