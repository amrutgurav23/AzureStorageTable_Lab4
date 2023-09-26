// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.Data.Tables;


//https://storageaccountazuretable.table.core.windows.net/Patient
//9nmTPnoykje12RuXTPoYJmSGWTWOhIeC1Eq1+wJbm97PUwtycGOe56JtQcHIwoO8+K4iq50wP24f+AStnoN1Xg==

//Connect Azure table online
var tableClient = new TableClient(new Uri("https://storageaccountazuretable.table.core.windows.net/Patient"),
    "Patient", new TableSharedKeyCredential("storageaccountazuretable", "9nmTPnoykje12RuXTPoYJmSGWTWOhIeC1Eq1+wJbm97PUwtycGOe56JtQcHIwoO8+K4iq50wP24f+AStnoN1Xg=="));

#region New Patient Entry into Azure Table

//Patient patientObj = new Patient();
//patientObj.PatientName = "Shyam";
//patientObj.PatientAddress = "Pune";
//patientObj.PartitionKey = "IP";
//patientObj.RowKey = "R1002";

//tableClient.AddEntity(patientObj); 

#endregion

#region Query and Fetch Table record using OData

//Pageable<Patient> query = tableClient.Query<Patient>(filter: $"RowKey eq 'R1002'");
//foreach (Patient p in query)
//{

//} 
#endregion

//Update Record: Fetch Table record using Point Query(using Partition Key & Row Key to avoid Partion Scan)
Patient entity = tableClient.GetEntity<Patient>("OP", "P1001");
entity.PatientAddress = "Updating Address";
tableClient.UpdateEntity(entity, ETag.All, TableUpdateMode.Replace);

Console.WriteLine("Hello, World!");
public class Patient : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    public string PatientName { get; set; }
    public string PatientAddress { get; set; }
}
