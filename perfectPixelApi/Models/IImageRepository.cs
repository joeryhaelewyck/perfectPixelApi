using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perfectPixelApi.Models
{
    interface IImageRepository
    {
        Image GetById(int id);
        Image GetByName(string name);
        IEnumerable<Image> GetAll();
        IEnumerable<Image> GetImagesByMonth(string month);
        void Add(Image image);
        void Delete(Image image);
        void Update(Image image);
        void SaveChanges();
    }
}
