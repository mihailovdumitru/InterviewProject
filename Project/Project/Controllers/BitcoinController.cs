using Model.Elements;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.Controllers
{
    /// <summary>
    /// Controller for handling HTTP calls for bitcoin data
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BitcoinController : ApiController
    {
        private readonly IBitcoinService bitcoinService;

        public BitcoinController(IBitcoinService service)
        {
            this.bitcoinService = service;
        }

        [AllowAnonymous]
        // GET api/<controller>
        public async Task<BitcoinRealTimeData> Get()
        {
            return await bitcoinService.GetBitcoinRealData();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}