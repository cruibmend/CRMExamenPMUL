using System.Collections.Generic;

[System.Serializable] 

public class RecordData
{
    List<int> records;

    public RecordData(List<int> records)
    {
         this.records = records;
    }

    public List<int> GetRecords()
    {
        return records;
    }

    public void SetRecord(List<int> records)
    {
        this.records = records;
    }
}
