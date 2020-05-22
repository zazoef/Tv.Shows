using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;

using TvShows.Interfaces.Repository;

namespace TvShows.Repository
{
    public class FileRepository<T> : IFileRepository<T> where T : class
    {
        private readonly string _fileName = "shows.json";

        public List<T> Read()
        {
            if (!File.Exists(_fileName))
            {
                return null;
            }
            var json = File.ReadAllText(_fileName);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public void Write(List<T> data)
        {
            string json = JsonConvert.SerializeObject(data.ToArray());
            File.WriteAllText(_fileName, json);
        }
    }
}
