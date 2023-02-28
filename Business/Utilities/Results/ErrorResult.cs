using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Results
{
    public class ErrorDataResult : Result
    {
        public ErrorDataResult(string message) : base(false, message)
        {

        }

        public ErrorDataResult() : base(false)
        {

        }

    }
}
