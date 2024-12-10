using Newtonsoft.Json;

if (args.Length == 0)
{
    throw new Exception("File argument missing.");
}

string fileName = args[0];
if (!File.Exists(fileName))
{
    throw new Exception("File not found.");
}

string content = File.ReadAllText(fileName);
if(string.IsNullOrWhiteSpace(content))
{
    throw new Exception("No content.");
}

DateTime currentTime = DateTime.Now;
IEnumerable<Appointment> appointments = JsonConvert.DeserializeObject<List<Appointment>>(content);
foreach(var appointment in appointments)
{
    Console.WriteLine($"Appointment: {appointment.Id} ({appointment.State})");
    Console.WriteLine($"Provider: {appointment.ProviderId}");
    Console.WriteLine($"Patient: {appointment.PatientId}");
    Console.WriteLine($"Room: {appointment.RoomId}");
    Console.WriteLine($"Date: {appointment.Date.Add(TimeSpan.Parse(appointment.StartTime)).ToString()}");
    Console.WriteLine($"Procedures: {appointment.PatientProcedureIds}");
    Console.WriteLine("==============================");
}

Console.WriteLine($"Time elapsed: {DateTime.Now - currentTime}");

public class Appointment
{
    [JsonProperty("appointment_id")]
    public string Id { get; set; }
    [JsonProperty("provider_id")]
    public string ProviderId { get; set; }
    [JsonProperty("dentist_id")]
    public string DentistId { get; set; }
    [JsonProperty("patient_id")]
    public string PatientId { get; set; }
    public DateTime Date { get; set; }
    [JsonProperty("start_time")]
    public string StartTime { get; set; }
    public int Duration { get; set; }
    public string State { get; set; }
    public string Note { get; set; }
    [JsonProperty("room_id")]
    public string RoomId { get; set; }
    [JsonProperty("appointment_category_id")]
    public string AppointmentCategoryId { get; set; }
    [JsonProperty("patient_procedure_ids")]
    public string PatientProcedureIds { get; set; }

}