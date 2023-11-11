using Newtonsoft.Json;

namespace DataAccess
{
    public class FileHelper
    {
        private readonly string _path;

        public FileHelper()
        {
            _path = "fileDb.json";
        }

        public void SaveToFile(List<ConcertData> data) 
        {
            string concertDataJson = JsonConvert.SerializeObject(data);
            File.WriteAllText(_path,concertDataJson);
        }

        public List<ConcertData> LoadFromFile() 
        {
            if(!File.Exists(_path))
            {
                return new List<ConcertData> { };
            }

            string concertDataJson = File.ReadAllText(_path);

            List<ConcertData> concertData = JsonConvert.DeserializeObject<List<ConcertData>>(concertDataJson);
            return concertData;
        }
    }
}
