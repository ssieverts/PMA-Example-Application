using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PMA.Controllers
{
    public class DateTimeValueController : ApiController
    {
        private readonly DateTimeValue[] _dateTimeValues =
        {
            new DateTimeValue {DayStr = "0. Sunday", UrlParams = false, CalDate = DateTime.Now.AddDays(0)},
            new DateTimeValue {DayStr = "1. Monday", UrlParams = false, CalDate = DateTime.Now.AddDays(1)},
            new DateTimeValue {DayStr = "2. Tuesday", UrlParams = false, CalDate = DateTime.Now.AddDays(2)},
            new DateTimeValue {DayStr = "3. Wednesday", UrlParams = false, CalDate = DateTime.Now.AddDays(3)},
            new DateTimeValue {DayStr = "4. Thursday", UrlParams = false, CalDate = DateTime.Now.AddDays(4)},
            new DateTimeValue {DayStr = "5. Friday", UrlParams = false, CalDate = DateTime.Now.AddDays(5)},
            new DateTimeValue {DayStr = "6. Saturday", UrlParams = false, CalDate = DateTime.Now.AddDays(6)}
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
        ///     POST api/<controller>
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<DateTimeValue> Post([FromBody] NewDates[] newDates)
        {
            if (newDates.Length != 7)
                throw new ArgumentException("newDates must have 7 elements.", nameof(newDates));
            var idx = 0;
            //manipulate the array
            foreach (var val in _dateTimeValues)
            {
                val.CalDate = newDates[idx].CalDate;
                idx++;
            }

            return _dateTimeValues;
        }
    }
}