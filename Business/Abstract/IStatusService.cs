using Business.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStatusService
    {
        public IDataResult<List<Status>> GetAll();
        public IResult Create(Status status);
        public IDataResult<Status> GetById(int id);
        public IResult Update(Status status);
        public IResult Delete(int id);
    }
}
