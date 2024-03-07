using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Unity.Profiling;

public static class SaveManager
{
    private static string path = Application.persistentDataPath + "/save.dat";
    private static List<int> records;

    public static void SaveRecord(int pooints)
    {
        /*if (pooints > record)
        {
            record = pooints;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            RecordData data = new RecordData(record);

            formatter.Serialize(stream, data);
            stream.Close();
        }*/
        if (records.Count == 0) {
            records[0] = pooints;
        }
        else
        {
            for (int i = 0; i < records.Count; i++)
            {
                if (pooints > records[i])
                {
                    records.Add(pooints);

                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream stream = new FileStream(path, FileMode.Create);

                    RecordData data = new RecordData(records);

                    formatter.Serialize(stream, data);
                    stream.Close();
                    break;
                }
            }
        }
    }

    public static List<int> LoadRecord()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RecordData data = formatter.Deserialize(stream) as RecordData;  // equivalent to (RecordData)formatter.Deserialize(stream);
            stream.Close();

            records = data.GetRecords();
        } else
        {
            for (int i = 0; i < records.Count; i++)
            {
                records[i] = 0;
            }
        }
        return records;
    }
}
