using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        [Route("{TopEnd}")]
        [HttpGet]
        public String Get(int TopEnd)
        {
            string FizzBuzzStr ="[";
            if (TopEnd < 1 || TopEnd > 100)
            {
                FizzBuzzStr += "Error out of bounds";
            }
            else
            {
                for (int i = 1; i < TopEnd + 1; i++)
                {
                    FizzBuzzStr += "\"";
                    if ((i % 3) != 0 && (i % 5) != 0) FizzBuzzStr += i.ToString();

                    if ((i % 3) == 0)
                    {
                        FizzBuzzStr += "Fizz";
                    }

                    if ((i % 5) == 0)
                    {
                        FizzBuzzStr += "Buzz";
                    }
                    FizzBuzzStr += "\"";
                    if (i < TopEnd) FizzBuzzStr += ",";
                }
            }
            FizzBuzzStr += "]";
            return FizzBuzzStr;
        }
    }
}
