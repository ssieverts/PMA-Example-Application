using System;
using System.Collections.Generic;
using System.Web.Http;
using PMADesktop.Models;

namespace PMADesktop.Controllers
{
    public class DateTimeValueController : ApiController
    {
        //get offset to previous Sunday
        private static readonly int offset = DateTimeValue.GetOffSet();

        // Create data Array
        private readonly DateTimeValue[] _dateTimeValues =
        {
            new DateTimeValue {DayStr = "0. Sunday", UrlParams = false, CalDate = DateTime.Now.AddDays(offset)},
            new DateTimeValue {DayStr = "1. Monday", UrlParams = false, CalDate = DateTime.Now.AddDays(offset+1)},
            new DateTimeValue {DayStr = "2. Tuesday", UrlParams = false, CalDate = DateTime.Now.AddDays(offset+2)},
            new DateTimeValue {DayStr = "3. Wednesday", UrlParams = false, CalDate = DateTime.Now.AddDays(offset+3)},
            new DateTimeValue {DayStr = "4. Thursday", UrlParams = false, CalDate = DateTime.Now.AddDays(offset+4)},
            new DateTimeValue {DayStr = "5. Friday", UrlParams = false, CalDate = DateTime.Now.AddDays(offset+5)},
            new DateTimeValue {DayStr = "6. Saturday", UrlParams = false, CalDate = DateTime.Now.AddDays(offset+6)}
        };

        /// <summary>
        ///     GET api/<controller>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DateTimeValue> Get()
        {
            return _dateTimeValues;
        }


        /// <summary>
        /// POST api/<controller>
        /// </summary>
        /// <param name="newDate"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<DateTimeValue> Post([FromBody] NewDate[] newDate)
        {
            if (newDate.Length != 7)
                throw new ArgumentException("newDate must have 7 elements.", nameof(newDate));
            var idx = 0;
            //manipulate the array
            foreach (var val in _dateTimeValues)
            {
                val.CalDate = newDate[idx].CalDate;
                idx++;
            }

            return _dateTimeValues;
        }
    }
}