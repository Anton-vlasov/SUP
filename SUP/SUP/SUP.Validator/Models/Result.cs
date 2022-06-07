using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUP.Validator.Models
{
    public class Result
    {
        public String[] Errors { get; set; }
        public Boolean IsSuccess => Errors.Length == 0;

        public Result(String[] errors)
        {
            Errors = errors;
        }

        public static Result Fail(IEnumerable<String> errors)
        {
            return new Result(errors.ToArray());
        }

        public static Result Fail(String error)
        {
            return new Result(new[] { error });
        }

        public static Result Success()
        {
            return new Result(new String[] { });
        }
    }
}
