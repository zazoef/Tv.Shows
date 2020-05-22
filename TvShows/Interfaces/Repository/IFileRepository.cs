using System.Collections.Generic;

namespace TvShows.Interfaces.Repository
{
    public interface IFileRepository<T> where T : class
    {
        void Write(List<T> data);
        List<T>Read();
    }
}
