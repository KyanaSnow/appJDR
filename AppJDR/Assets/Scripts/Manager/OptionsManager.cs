using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;

public sealed class VersionDeserializationBinder : SerializationBinder
{
    public override Type BindToType(string assemblyName, string typeName)
    {
        if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
        {
            Type typeToDeserialize = null;


            assemblyName = Assembly.GetExecutingAssembly().FullName;
            // The following line of code returns the type. 
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
            return typeToDeserialize;
        }
        return null;
    }
}

[Serializable]
public class SoundOption
{
    public float MusicVolume;
    public float VoiceVolume;
    public float UIVolume;
}

[Serializable]
public class ProfilOption
{
    public string pseudo;
}

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager _Instance;

    public SoundOption soundOption;

	void Awake ()
    {
        if (_Instance == null)
            _Instance = this;
        else if (_Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        LoadSoundOption();
	}


    #region SOUND OPTION
    public void SaveSoundOption(SoundOption tmp)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/optionsInfo.dat");

        SoundOption data = new SoundOption();
        data = tmp;

        bf.Serialize(file, data);
        file.Close();
        SoundManager._Instance.LoadSoundOption();
    }

    public void LoadSoundOption()
    {
        Debug.Log("Path : " + Application.persistentDataPath + "/optionsInfo.dat");

        if (File.Exists(Application.persistentDataPath + "/optionsInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/optionsInfo.dat", FileMode.Open);
            SoundOption data = (SoundOption)bf.Deserialize(file);
            file.Close();

            soundOption = data;
        }
        else
        {

            SoundOption tmp = new SoundOption();
            tmp.MusicVolume = 1;
            tmp.VoiceVolume = 1;
            tmp.UIVolume = 1;
            soundOption = tmp;
            SaveSoundOption(tmp);
        }

    }
    #endregion

    
}
